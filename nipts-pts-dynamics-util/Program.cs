using System.Text.Json;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Security.KeyVault.Secrets;

namespace nipts_pts_dynamics_util;

/// <summary>
/// Standalone utility that moves PTS applications out of the "AWAITING VERIFICATION" state by
/// posting the same Service Bus status message the automated test suite uses in
/// <c>ApplicationData.ApproveApplication</c> / <c>SuspendApplication</c>.
///
/// There is no token-authenticated Dynamics REST endpoint in this solution for changing an
/// application's status: the backend consumes a message from the
/// <c>defra.trade.pts.application.update</c> queue and writes the new status back to Dynamics.
/// This tool drives that exact mechanism directly from a list of application Ids.
///
/// Auth: the Service Bus connection string is read from Key Vault using
/// <see cref="DefaultAzureCredential"/> (i.e. your local 'az login' identity must have Get
/// permission on the vault secret), mirroring how the test project resolves it.
///
/// Usage:
///   dotnet run -- [Authorised|Suspended] [--send] [applicationId ...]
///     - First positional arg (optional) is the target status. Default: Authorised.
///     - --send actually posts the messages. Without it the tool runs in DRY-RUN and only prints
///       what it would send, so real shared test data is never changed by accident.
///     - Any remaining args are application Ids. If none are given, the built-in list below is used.
/// </summary>
internal static class Program
{
    // Key Vault + queue coordinates. Defaults match appsettings.json; overridable via env vars so
    // nothing is hard-coded in a way that blocks a different environment.
    private const string DefaultVaultName = "TSTTRDINFKV1001";
    private const string DefaultSecretName = "Nipts-ServiceBus-ConnectionString";
    private const string DefaultQueueName = "defra.trade.pts.application.update";

    // The records supplied for this task (Id -> ReferenceNumber, for readable logging only).
    private static readonly (string Id, string Reference)[] DefaultApplications =
    [
        ("2058b05a-57b3-4f6b-d08e-08dedaf2924c", "L3XCGTT8"),
        ("6dc25fbe-f657-446c-d08d-08dedaf2924c", "KJ3PSFZ2"),
        ("bd192474-43e5-47b3-d08c-08dedaf2924c", "VB3I2O0F"),
        ("b77f4741-6ae5-4de4-d08b-08dedaf2924c", "CDVN6CL4"),
        ("269a4041-a3e7-4cbe-d08a-08dedaf2924c", "VBAJC77C"),
    ];

    private static async Task<int> Main(string[] args)
    {
        try
        {
            var send = args.Contains("--send", StringComparer.OrdinalIgnoreCase);
            var positional = args.Where(a => !a.StartsWith("--", StringComparison.Ordinal)).ToList();

            // Optional first positional arg = status.
            var status = "Authorised";
            if (positional.Count > 0 &&
                (positional[0].Equals("Authorised", StringComparison.OrdinalIgnoreCase) ||
                 positional[0].Equals("Suspended", StringComparison.OrdinalIgnoreCase)))
            {
                status = char.ToUpperInvariant(positional[0][0]) + positional[0][1..].ToLowerInvariant();
                positional.RemoveAt(0);
            }

            var applications = positional.Count > 0
                ? positional.Select(id => (Id: id, Reference: "(supplied)")).ToArray()
                : DefaultApplications;

            var vaultName = Environment.GetEnvironmentVariable("PTS_VAULT_NAME") ?? DefaultVaultName;
            var secretName = Environment.GetEnvironmentVariable("PTS_SB_SECRET_NAME") ?? DefaultSecretName;
            var queueName = Environment.GetEnvironmentVariable("PTS_SB_QUEUE_NAME") ?? DefaultQueueName;

            Console.WriteLine("=== PTS status update utility ===");
            Console.WriteLine($"Target status : {status}");
            Console.WriteLine($"Queue         : {queueName}");
            Console.WriteLine($"Key Vault     : {vaultName} (secret: {secretName})");
            Console.WriteLine($"Applications  : {applications.Length}");
            Console.WriteLine($"Mode          : {(send ? "SEND (messages will be posted)" : "DRY-RUN (nothing sent; pass --send to post)")}");
            Console.WriteLine("=================================");

            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var messages = applications
                .Select(app => (app, body: BuildMessageBody(app.Id, status, today)))
                .ToList();

            foreach (var (app, body) in messages)
            {
                Console.WriteLine($"[{app.Reference}] {app.Id}");
                Console.WriteLine($"    -> {body}");
            }

            if (!send)
            {
                Console.WriteLine();
                Console.WriteLine("DRY-RUN complete. Re-run with --send to actually post these messages.");
                return 0;
            }

            var connectionString = ResolveConnectionString(vaultName, secretName);

            await using var client = new ServiceBusClient(connectionString);
            await using var sender = client.CreateSender(queueName);

            var succeeded = 0;
            foreach (var (app, body) in messages)
            {
                try
                {
                    await sender.SendMessageAsync(new ServiceBusMessage(body));
                    succeeded++;
                    Console.WriteLine($"SENT   [{app.Reference}] {app.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED [{app.Reference}] {app.Id}: {ex.Message}");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Done. {succeeded}/{messages.Count} status messages posted to '{queueName}'.");
            Console.WriteLine("Note: the status change is applied asynchronously by the downstream Dynamics integration; " +
                              "allow a short delay before verifying.");
            return succeeded == messages.Count ? 0 : 1;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"ERROR: {ex.Message}");
            return 2;
        }
    }

    /// <summary>
    /// Builds the message body in the exact shape the test suite posts (note the trailing space in
    /// the "Application.Id" key is intentional and matches the consumer the backend expects).
    /// </summary>
    private static string BuildMessageBody(string applicationId, string status, string date)
    {
        var dynamicId = Guid.NewGuid().ToString();
        return $"{{ \"Application.Id \": \"{applicationId}\", \"Application.DynamicId\": \"{dynamicId}\", " +
               $"\"Application.StatusId\": \"{status}\", \"Application.DateAuthorised\": \"{date}\" }}";
    }

    private static string ResolveConnectionString(string vaultName, string secretName)
    {
        // Allow a direct override so the tool can run where Key Vault access is unavailable.
        var direct = Environment.GetEnvironmentVariable("PTS_SB_CONNECTION_STRING");
        if (!string.IsNullOrWhiteSpace(direct))
        {
            Console.WriteLine("Using Service Bus connection string from PTS_SB_CONNECTION_STRING.");
            return direct;
        }

        var vaultUri = new Uri($"https://{vaultName}.vault.azure.net/");
        var client = new SecretClient(vaultUri, new DefaultAzureCredential());
        var secret = client.GetSecret(secretName).Value;
        Console.WriteLine($"Resolved Service Bus connection string from Key Vault '{vaultName}'.");
        return secret.Value;
    }
}

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Defra.UI.Framework.Configuration;
using Microsoft.Extensions.Configuration;
using Reqnroll;
using TestExecutionContext = NUnit.Framework.Internal.TestExecutionContext;


namespace nipts_pts_automation_tests.Configuration
{
    [Binding]
    public class ConfigSetup
    {
        public static BaseConfiguration? BaseConfiguration { get; private set; }

        [BeforeTestRun(Order = (int)HookRunOrder.Configuration)]
        public static void SetupProjectConfig()
        {
            BaseConfiguration = LoadConfigurationFromAppSettings();
            ResolveSecretsFromKeyVault();
            UiFrameworkConfigurationBinding();
            DataSetupConfigurationBinding();
            DBSetupConfigurationBinding();
            ServiceBusConfigurationBinding();
        }

        private static BaseConfiguration LoadConfigurationFromAppSettings()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true);
            // Optional local overrides for developers (never committed - see .gitignore).
            builder.AddJsonFile("appsettings.local.json", true, true);
            // Allow secrets (e.g. BrowserStack credentials) to be supplied via environment
            // variables, e.g. AppSettings__BrowserStackConfiguration__CloudDeviceUserKey.
            builder.AddEnvironmentVariables();
            var settings = builder.Build();
            DebugAppSettings(settings);
            return settings.GetSection("AppSettings").Get<BaseConfiguration>();
        }

        // Config key fragments whose values must never be written to logs/console.
        private static readonly string[] _sensitiveKeyParts =
        [
            "Password", "UserKey", "AccessKey", "ConnString", "Connectionstring", "Secret", "Token"
        ];

        private static void DebugAppSettings(IConfigurationRoot configurationRoot)
        {
            Console.WriteLine("Appsettings.json >>>>>>>>>>");
            foreach (var keyValuePair in configurationRoot.GetSection("AppSettings").AsEnumerable())
            {
                var value = IsSensitive(keyValuePair.Key) ? "***REDACTED***" : keyValuePair.Value;
                Console.WriteLine($"{keyValuePair.Key} === {value}");
            }
        }

        private static bool IsSensitive(string key) =>
            !string.IsNullOrEmpty(key) &&
            _sensitiveKeyParts.Any(part => key.Contains(part, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Overlays sensitive values from Azure Key Vault on top of the bound configuration.
        /// Maps the configured secrets onto <see cref="TestConfiguration.EnvPassword"/> and the
        /// BrowserStack credentials. Authentication uses
        /// <see cref="DefaultAzureCredential"/>, so locally it relies on the developer's
        /// 'az login' (the signed-in account needs Get permission on the vault's secrets).
        /// Failures are non-fatal: the value already present in appsettings.json is kept.
        /// </summary>
        private static void ResolveSecretsFromKeyVault()
        {
            var kv = BaseConfiguration?.KeyVaultConfiguration;
            if (kv == null || string.IsNullOrWhiteSpace(kv.VaultName))
            {
                Console.WriteLine("Key Vault resolution skipped - no VaultName configured.");
                return;
            }

            SecretClient client;
            try
            {
                var vaultUri = new Uri($"https://{kv.VaultName}.vault.azure.net/");
                client = new SecretClient(vaultUri, new DefaultAzureCredential());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WARNING: could not connect to Key Vault '{kv.VaultName}': {ex.Message}. Falling back to the appsettings values.");
                return;
            }

            TryApplySecret(client, kv.VaultName,
                string.IsNullOrWhiteSpace(kv.EnvPasswordSecretName) ? "PTS-CP-MAGIC-PASSWORD" : kv.EnvPasswordSecretName,
                "TestConfiguration.EnvPassword",
                value => BaseConfiguration.TestConfiguration.EnvPassword = value);

            TryApplySecret(client, kv.VaultName, kv.BrowserStackUserNameSecretName,
                "BrowserStackConfiguration.CloudDeviceUserName",
                value => BaseConfiguration.BrowserStackConfiguration.CloudDeviceUserName = value);

            TryApplySecret(client, kv.VaultName, kv.BrowserStackAccessKeySecretName,
                "BrowserStackConfiguration.CloudDeviceUserKey",
                value => BaseConfiguration.BrowserStackConfiguration.CloudDeviceUserKey = value);

            TryApplySecret(client, kv.VaultName, kv.CommonSubscriptionKeySecretName,
                "BackendSetupConfig.CommonSubscriptionKey",
                value => BaseConfiguration.BackendSetupConfig.CommonSubscriptionKey = value);

            TryApplySecret(client, kv.VaultName, kv.CpClientIdSecretName,
                "B2CConfig.CPClientId",
                value => BaseConfiguration.B2CConfig.CPClientId = value);

            TryApplySecret(client, kv.VaultName, kv.ClientIdSecretName,
                "B2CConfig.ClientId",
                value => BaseConfiguration.B2CConfig.ClientId = value);

            TryApplySecret(client, kv.VaultName, kv.ClientSecretSecretName,
                "B2CConfig.ClientSecret",
                value => BaseConfiguration.B2CConfig.ClientSecret = value);

            TryApplySecret(client, kv.VaultName, kv.CpClientSecretSecretName,
                "B2CConfig.CPClientSecret",
                value => BaseConfiguration.B2CConfig.CPClientSecret = value);

            TryApplySecret(client, kv.VaultName, kv.ServiceIdSecretName,
                "B2CConfig.ServiceId",
                value => BaseConfiguration.B2CConfig.ServiceId = value);

            TryApplySecret(client, kv.VaultName, kv.PolicySecretName,
                "B2CConfig.Policy",
                value => BaseConfiguration.B2CConfig.Policy = value);

            TryApplySecret(client, kv.VaultName, kv.AutomationsUserNameSecretName,
                "B2CConfig.BackendUsername",
                value => BaseConfiguration.B2CConfig.BackendUsername = value);

            TryApplySecret(client, kv.VaultName, kv.AutomationsPasswordSecretName,
                "B2CConfig.BackendPassword",
                value => BaseConfiguration.B2CConfig.BackendPassword = value);

            TryApplySecret(client, kv.VaultName, kv.ServiceBusConnectionStringSecretName,
                "ServiceBusConnectionConfig.ServiceBusConnString",
                value => BaseConfiguration.ServiceBusConnectionConfig.ServiceBusConnString = value);

            TryApplySecret(client, kv.VaultName, kv.CpApimSubscriptionKeySecretName,
                "BackendSetupConfig.CheckerSubscriptionKey",
                value => BaseConfiguration.BackendSetupConfig.CheckerSubscriptionKey = value);
        }

        /// <summary>
        /// Fetches a single secret and applies it via <paramref name="apply"/>. When the secret
        /// name is not configured the step is skipped; any failure is logged and non-fatal so
        /// the existing appsettings value remains in place.
        /// </summary>
        private static void TryApplySecret(SecretClient client, string vaultName, string secretName, string targetDescription, Action<string> apply)
        {
            if (string.IsNullOrWhiteSpace(secretName))
            {
                return;
            }

            try
            {
                KeyVaultSecret secret = client.GetSecret(secretName);
                apply(secret.Value);
                Console.WriteLine($"{targetDescription} loaded from Key Vault '{vaultName}' secret '{secretName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WARNING: could not load {targetDescription} from Key Vault '{vaultName}' secret '{secretName}': {ex.Message}. Falling back to the appsettings value.");
            }
        }

        private static void UiFrameworkConfigurationBinding()
        {
            FrameworkConfiguration.Configuration = BaseConfiguration.UiFrameworkConfiguration;
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add("UiFrameworkConfiguration", BaseConfiguration.UiFrameworkConfiguration);
        }
        private static void DataSetupConfigurationBinding()
        {
            nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration = BaseConfiguration.BackendSetupConfig;
        }

        private static void DBSetupConfigurationBinding()
        {
            string dataDB = BaseConfiguration.AppConnectionString.DBConnectionstring;
            //BaseConfiguration.ApplicationCon = BaseConfiguration.ApplicationCon.DBConnect(BaseConfiguration.AppConnectionString.DBConnectionstring);
            //BaseConfiguration.ApplicationCon.DBConnect(BaseConfiguration.AppConnectionString.DBConnectionstring);
        }
        private static void ServiceBusConfigurationBinding()
        {
            nipts_pts_API_tests.Configuration.ServiceBusConnectionData.Configuration = BaseConfiguration.ServiceBusConnectionConfig;
        }

    }


}

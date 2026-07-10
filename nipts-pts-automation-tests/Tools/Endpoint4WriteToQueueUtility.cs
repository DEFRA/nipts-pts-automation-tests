using nipts_pts_API_tests.Application;
using nipts_pts_API_tests.Configuration;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace nipts_pts_automation_tests.Tools
{
    /// <summary>
    /// Manually-run utility (not part of the regression suite) that contacts the
    /// <c>dynamic-integration</c> API (ApiEndpoint4) and calls its <c>writetoqueue</c> endpoint for
    /// a fixed set of application Ids.
    ///
    /// This is the API-fronted equivalent of putting a message on the
    /// <c>defra.trade.pts.application.update</c> queue: <c>writetoqueue</c> enqueues the application
    /// (by id) so the downstream integration syncs it to Dynamics. The endpoint carries only the
    /// application id (see <see cref="ApplicationData.writeApplicationToQueue"/>) - it does not take
    /// a status value, so it re-syncs the application's current state rather than setting a new one.
    ///
    /// It is marked <see cref="ExplicitAttribute"/> and categorised so it never runs in CI: run it
    /// on demand from the Test Explorer or:
    ///   dotnet test --filter "FullyQualifiedName~Endpoint4WriteToQueueUtility"
    ///
    /// Prerequisites (same as a normal backend test):
    ///   * 'az login' with Get access to the Key Vault secrets (backend creds, subscription key).
    ///   * Network access to the internal gateway host in ApiEndpoint4.
    ///   * A Chrome browser will open to perform the backend B2C login that mints the token.
    /// </summary>
    [TestFixture]
    [Explicit("Manual utility - contacts the dynamic-integration API for specific application Ids.")]
    [Category("ManualUtility")]
    public class Endpoint4WriteToQueueUtility
    {
        // The application Ids to push through the dynamic-integration writetoqueue endpoint,
        // with their reference numbers for readable logging only.
        private static readonly (string Id, string Reference)[] Applications =
        [
            ("2058b05a-57b3-4f6b-d08e-08dedaf2924c", "L3XCGTT8"),
            ("6dc25fbe-f657-446c-d08d-08dedaf2924c", "KJ3PSFZ2"),
            ("bd192474-43e5-47b3-d08c-08dedaf2924c", "VB3I2O0F"),
            ("b77f4741-6ae5-4de4-d08b-08dedaf2924c", "CDVN6CL4"),
            ("269a4041-a3e7-4cbe-d08a-08dedaf2924c", "VBAJC77C"),
        ];

        [Test]
        public void WriteApplicationsToQueueViaDynamicIntegrationApi()
        {
            // 1. Load appsettings + overlay Key Vault secrets and bind the backend/data config so
            //    ApiEndpoint4, the subscription key and the token slot are all populated.
            ConfigSetup.SetupProjectConfig();

            var b2cConfig = ConfigSetup.BaseConfiguration?.B2CConfig
                ?? throw new Exception("B2CConfig unavailable - configuration failed to load.");

            ChromeDriver? driver = null;
            var results = new List<(string Reference, string Id, bool Success)>();

            try
            {
                // 2. Open a browser and land on a real page so the token flow's window.open works.
                driver = new ChromeDriver();
                var portalUrl = ConfigSetup.BaseConfiguration!.TestConfiguration.ComPortalUrl;
                if (!string.IsNullOrWhiteSpace(portalUrl))
                    driver.Navigate().GoToUrl(portalUrl);

                // 3. Mint the backend bearer token via the existing interactive B2C login flow and
                //    make it available to the API client (non-checker endpoints use BearerToken).
                var token = TokenAcquirer.GetBearerToken(b2cConfig, driver);
                DataSetupConfig.Configuration.BearerToken = token;
                Console.WriteLine("Backend bearer token acquired for the dynamic-integration call.");

                // 4. Call ApiEndpoint4/writetoqueue for each application id.
                var appData = new ApplicationData();
                foreach (var (id, reference) in Applications)
                {
                    appData.QueueId = id;
                    Console.WriteLine($"--- writetoqueue [{reference}] {id} ---");
                    bool ok;
                    try
                    {
                        ok = appData.writeApplicationToQueue();
                    }
                    catch (Exception ex)
                    {
                        ok = false;
                        Console.WriteLine($"writetoqueue [{reference}] {id} threw: {ex.Message}");
                    }
                    results.Add((reference, id, ok));
                    Console.WriteLine($"writetoqueue [{reference}] {id} => {(ok ? "SUCCESS" : "FAILED")}");
                }
            }
            finally
            {
                driver?.Quit();
                driver?.Dispose();
            }

            Console.WriteLine("=== dynamic-integration writetoqueue summary ===");
            foreach (var (reference, id, success) in results)
                Console.WriteLine($"  [{reference}] {id}: {(success ? "SUCCESS" : "FAILED")}");

            var failed = results.Where(r => !r.Success).ToList();
            Assert.That(failed, Is.Empty,
                "writetoqueue failed for: " + string.Join(", ", failed.Select(f => $"{f.Reference} ({f.Id})")));
        }
    }
}

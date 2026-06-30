using nipts_pts_automation_tests.Configuration;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.HelperMethods
{
    /// <summary>
    /// Ensures the backend / pts-pet-checker bearer tokens required by the backend
    /// approve/revoke/suspend steps are available. The tokens are normally minted by the CP
    /// "port route checker page" step, but applicant-only flows (e.g. InvalidDocuments) never
    /// visit that page, so the checker calls would otherwise go out with no Authorization header
    /// and fail with 401. This helper lazily acquires the tokens the first time a backend call
    /// needs them, regardless of which feature is running.
    /// </summary>
    public static class BackendTokenProvider
    {
        private static readonly object _lock = new object();

        /// <summary>
        /// Acquires the backend applicant token and the CP pet-checker token if they are not
        /// already set on <see cref="nipts_pts_API_tests.Configuration.DataSetupConfig"/>. Safe to
        /// call repeatedly: once a token is present the relevant acquisition is skipped.
        /// </summary>
        public static void EnsureTokens(IWebDriver? driver)
        {
            var config = nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration;
            if (config != null
                && !string.IsNullOrEmpty(config.BearerToken)
                && !string.IsNullOrEmpty(config.CheckerBearerToken))
            {
                return;
            }

            var b2cConfig = ConfigSetup.BaseConfiguration?.B2CConfig;
            if (b2cConfig == null || driver == null)
            {
                Console.WriteLine("WARNING: B2CConfig or WebDriver not available — backend bearer token not set.");
                return;
            }

            lock (_lock)
            {
                config = nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration;

                if (config != null && string.IsNullOrEmpty(config.BearerToken))
                {
                    var token = TokenAcquirer.GetBearerToken(b2cConfig, driver);
                    nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration.BearerToken = token;
                    Console.WriteLine("Bearer token acquired successfully via backend B2C login.");
                }

                if (config != null && string.IsNullOrEmpty(config.CheckerBearerToken))
                {
                    // The pts-pet-checker (CP) API rejects the applicant token, so mint a separate CP
                    // token for checker calls (search/get application/approve). Non-fatal: a failure
                    // here just leaves checker calls on the backend token, surfacing the 401 as before.
                    try
                    {
                        var checkerToken = TokenAcquirer.GetCheckerBearerToken(b2cConfig, driver);
                        nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration.CheckerBearerToken = checkerToken;
                        Console.WriteLine("CP pet-checker bearer token acquired successfully via B2C login.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"WARNING: CP pet-checker token not acquired: {ex.Message}");
                    }
                }
            }
        }
    }
}

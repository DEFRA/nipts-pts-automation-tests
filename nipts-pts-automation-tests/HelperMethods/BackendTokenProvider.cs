using System.Text;
using Newtonsoft.Json.Linq;
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

        // The most recent scenario WebDriver, captured on every EnsureTokens call so the 401 retry
        // handler (which runs deep inside the API client) can re-mint a token interactively without
        // the driver being passed down through every layer.
        private static IWebDriver? _currentDriver;

        static BackendTokenProvider()
        {
            // Register the recovery hook once so every backend/checker API call can self-heal from a
            // 401 (expired token) by re-minting and retrying, regardless of which step issued it.
            nipts_pts_API_tests.BaseClient.TokenRefreshHandler = RefreshToken;
        }

        /// <summary>
        /// Acquires the backend applicant token and the CP pet-checker token if they are not
        /// already set on <see cref="nipts_pts_API_tests.Configuration.DataSetupConfig"/>. Safe to
        /// call repeatedly: a token is (re)minted whenever it is missing or has expired, so a long
        /// regression run that outlives the ~1h B2C token lifetime does not reuse a stale token and
        /// fail checker calls with 401.
        /// </summary>
        public static void EnsureTokens(IWebDriver? driver)
        {
            if (driver != null)
                _currentDriver = driver;

            var config = nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration;
            if (config != null
                && IsTokenUsable(config.BearerToken)
                && IsTokenUsable(config.CheckerBearerToken))
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

                if (config != null && !IsTokenUsable(config.BearerToken))
                {
                    var token = TokenAcquirer.GetBearerToken(b2cConfig, driver);
                    nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration.BearerToken = token;
                    Console.WriteLine("Bearer token acquired successfully via backend B2C login.");
                }

                if (config != null && !IsTokenUsable(config.CheckerBearerToken))
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

        /// <summary>
        /// 401-recovery hook invoked by the API client. Forcibly re-mints the token the failing
        /// endpoint needs (CP-audience when <paramref name="isCheckerEndpoint"/> is true, otherwise
        /// the backend/applicant token) using the last known scenario WebDriver, then returns true
        /// if a fresh token was set. Returns false (so the caller stops retrying) when no driver is
        /// available or the interactive re-login fails.
        /// </summary>
        private static bool RefreshToken(bool isCheckerEndpoint)
        {
            var driver = _currentDriver;
            var b2cConfig = ConfigSetup.BaseConfiguration?.B2CConfig;
            if (driver == null || b2cConfig == null)
            {
                Console.WriteLine("WARNING: cannot refresh bearer token after 401 — WebDriver or B2CConfig unavailable.");
                return false;
            }

            lock (_lock)
            {
                try
                {
                    if (isCheckerEndpoint && !string.IsNullOrWhiteSpace(b2cConfig.CPClientId))
                    {
                        var checkerToken = TokenAcquirer.GetCheckerBearerToken(b2cConfig, driver);
                        nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration.CheckerBearerToken = checkerToken;
                        Console.WriteLine("CP pet-checker bearer token refreshed after 401.");
                    }
                    else
                    {
                        var token = TokenAcquirer.GetBearerToken(b2cConfig, driver);
                        nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration.BearerToken = token;
                        Console.WriteLine("Backend bearer token refreshed after 401.");
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"WARNING: bearer token refresh after 401 failed: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// A token is usable only if it is present and not expired (or about to expire). We decode
        /// the JWT <c>exp</c> claim and treat anything within <paramref name="bufferSeconds"/> of
        /// expiry as unusable so a token does not lapse mid-call. If the token cannot be parsed we
        /// assume it is usable and let the API be the final arbiter (surfacing a real 401 rather
        /// than looping on re-acquisition).
        /// </summary>
        private static bool IsTokenUsable(string? token, int bufferSeconds = 120)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            var exp = GetExpiry(token);
            if (exp == null)
                return true;

            return exp.Value > DateTimeOffset.UtcNow.AddSeconds(bufferSeconds);
        }

        private static DateTimeOffset? GetExpiry(string token)
        {
            try
            {
                var parts = token.Split('.');
                if (parts.Length < 2)
                    return null;

                var payload = JObject.Parse(Encoding.UTF8.GetString(Base64UrlDecode(parts[1])));
                var exp = payload.Value<long?>("exp");
                return exp.HasValue ? DateTimeOffset.FromUnixTimeSeconds(exp.Value) : (DateTimeOffset?)null;
            }
            catch
            {
                return null;
            }
        }

        private static byte[] Base64UrlDecode(string input)
        {
            var output = input.Replace('-', '+').Replace('_', '/');
            switch (output.Length % 4)
            {
                case 2: output += "=="; break;
                case 3: output += "="; break;
            }
            return Convert.FromBase64String(output);
        }
    }
}

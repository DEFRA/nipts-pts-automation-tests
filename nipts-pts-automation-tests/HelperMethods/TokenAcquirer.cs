using Newtonsoft.Json;
using System.Web;
using nipts_pts_automation_tests.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nipts_pts_automation_tests.HelperMethods
{
    public static class TokenAcquirer
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Acquires the backend access token via an interactive B2C authorization-code login as
        /// the backend (PTS/AP tenant) test user.
        ///
        /// Why interactive: the backend APIs (user-creator, application-creator, ...) only accept
        /// a B2C USER token whose audience is the backend ClientId AND whose issuer is
        /// {tenant}.b2clogin.com - exactly what nipts-pts-web sends. This was proven empirically:
        ///   * Entra client-credentials  -> correct aud but issuer login.microsoftonline.com -> 401.
        ///   * B2C client-credentials     -> no such policy exists on the tenant (404).
        ///   * B2C ROPC                   -> no such policy exists on the tenant (404).
        /// So the only way to mint the required token is a real login as a backend-enrolled user.
        ///
        /// The test browser is signed into the CP / port-checker app, so we open a separate tab
        /// and force a fresh login (prompt=login) against the backend app + serviceId using the
        /// configured backend credentials, then exchange the returned code for the token. The CP
        /// app session in the original tab is unaffected.
        /// </summary>
        public static string GetBearerToken(B2CConfig config, IWebDriver driver)
        {
            if (string.IsNullOrWhiteSpace(config.BackendUsername) || string.IsNullOrWhiteSpace(config.BackendPassword))
                throw new Exception("B2CConfig.BackendUsername/BackendPassword must be set to acquire the backend API token.");

            var authority = $"https://{config.TenantName}.b2clogin.com/{config.TenantName}.onmicrosoft.com/{config.Policy}";
            var scope = $"openid offline_access {config.ClientId}";

            var code = GetAuthorizationCodeViaBackendLogin(driver, authority, config, scope);
            return ExchangeCodeForToken(authority, config, scope, code);
        }

        /// <summary>
        /// Acquires a CP / port-checker access token. The pts-pet-checker API only trusts a token
        /// whose audience is the CP client (CPClientId), so the backend applicant token cannot be
        /// reused for checker calls. B2C has no client-credentials/ROPC policy on this tenant (those
        /// 404), so this uses the same interactive auth-code login as the backend token but with the
        /// CP client id/secret and the CP redirect uri (which must be registered on the CP client or
        /// the code exchange fails with invalid_grant). The resulting token has aud = CPClientId.
        /// </summary>
        public static string GetCheckerBearerToken(B2CConfig config, IWebDriver driver)
        {
            if (string.IsNullOrWhiteSpace(config.CPClientId) || string.IsNullOrWhiteSpace(config.CPClientSecret))
                throw new Exception("B2CConfig.CPClientId/CPClientSecret must be set to acquire the CP pet-checker token.");

            var cpConfig = new B2CConfig
            {
                TenantName = config.TenantName,
                Policy = config.Policy,
                ClientId = config.CPClientId,
                ClientSecret = config.CPClientSecret,
                ServiceId = !string.IsNullOrWhiteSpace(config.CPServiceId) ? config.CPServiceId : config.ServiceId,
                RedirectUri = !string.IsNullOrWhiteSpace(config.CPRedirectUri) ? config.CPRedirectUri : config.RedirectUri,
                BackendUsername = config.BackendUsername,
                BackendPassword = config.BackendPassword,
                BackendTotpSecret = config.BackendTotpSecret
            };

            var authority = $"https://{cpConfig.TenantName}.b2clogin.com/{cpConfig.TenantName}.onmicrosoft.com/{cpConfig.Policy}";
            var scope = !string.IsNullOrWhiteSpace(config.CPScope) ? config.CPScope : $"openid offline_access {cpConfig.ClientId}";

            var code = GetAuthorizationCodeViaBackendLogin(driver, authority, cpConfig, scope);
            return ExchangeCodeForToken(authority, cpConfig, scope, code);
        }

        private static string GetAuthorizationCodeViaBackendLogin(IWebDriver driver, string authority, B2CConfig config, string scope)
        {
            var originalWindow = driver.CurrentWindowHandle;
            var originalUrl = driver.Url;
            var existingWindows = driver.WindowHandles.ToHashSet();

            // prompt=login forces a fresh credential entry so B2C ignores the CP SSO session and
            // authenticates as the backend user. serviceId is a dedicated DEFRA custom-policy param.
            var authorizeUrl =
                $"{authority}/oauth2/v2.0/authorize" +
                $"?client_id={config.ClientId}" +
                $"&response_type=code" +
                $"&redirect_uri={Uri.EscapeDataString(config.RedirectUri)}" +
                $"&response_mode=query" +
                $"&scope={Uri.EscapeDataString(scope)}" +
                $"&serviceId={config.ServiceId}" +
                $"&prompt=login" +
                $"&state=apitest";

            // Prefer a background tab so the signed-in CP page is preserved. Desktop browsers open a
            // new WebDriver window handle for window.open, but mobile browsers (e.g. iOS/Android via
            // BrowserStack) do NOT expose one, so wait only briefly for the new handle and fall back
            // to driving the login in the current tab when it never appears. Without this fallback
            // the wait blocks for the full timeout and fails with "Timed out after 60 seconds" on
            // mobile. The backend B2C login redirects to a localhost URI and never establishes a CP
            // app session, so the CP session cookie in the current tab is unaffected and we can
            // safely navigate back to the CP page afterwards.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open(arguments[0], '_blank');", authorizeUrl);

            string? newWindow = null;
            try
            {
                var newWindowWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                newWindowWait.Until(d => d.WindowHandles.Count > existingWindows.Count);
                newWindow = driver.WindowHandles.First(h => !existingWindows.Contains(h));
            }
            catch (WebDriverTimeoutException)
            {
                // No separate tab was created (mobile): drive the login in the current tab instead.
            }

            var openedNewTab = newWindow != null;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            if (openedNewTab)
                driver.SwitchTo().Window(newWindow);
            else
                driver.Navigate().GoToUrl(authorizeUrl);

            try
            {
                Console.WriteLine("Acquiring backend API token: signing in as the backend test user via B2C...");

                // Capture the redirect URL at the instant login detects it. On some mobile browsers
                // the unreachable localhost redirect blanks the tab to data:text/html, moments later,
                // discarding the code - so re-reading driver.Url afterwards can lose it.
                var redirectUrl = DriveGovernmentGatewayLogin(driver, wait, config);

                // Fallback: login returned without capturing the redirect; wait for the address bar
                // to show the code/error as before.
                if (string.IsNullOrEmpty(redirectUrl))
                {
                    try
                    {
                        wait.Until(d =>
                        {
                            var redirect = ResolveRedirectUrl(d.Url, config);
                            return redirect.StartsWith(config.RedirectUri, StringComparison.OrdinalIgnoreCase)
                                   && (redirect.Contains("code=") || redirect.Contains("error="));
                        });
                    }
                    catch (WebDriverTimeoutException)
                    {
                        LogCurrentPage(driver, "Timed out waiting for the B2C redirect with the authorization code");
                        throw;
                    }

                    redirectUrl = ResolveRedirectUrl(driver.Url, config);
                }

                var queryParams = HttpUtility.ParseQueryString(new Uri(redirectUrl).Query);

                var error = queryParams.Get("error");
                if (!string.IsNullOrEmpty(error))
                    throw new Exception($"Backend authorize request failed: {error} - {queryParams.Get("error_description")}");

                var code = queryParams.Get("code");
                if (string.IsNullOrWhiteSpace(code))
                    throw new Exception($"Authorization code not found in redirect URL: {driver.Url}");

                return code;
            }
            finally
            {
                if (openedNewTab)
                {
                    // Close the throwaway login tab and return to the preserved CP page.
                    driver.Close();
                    driver.SwitchTo().Window(originalWindow);
                }
                else
                {
                    // Single-tab (mobile): navigate back to the CP page we left. The CP app session
                    // cookie is intact, so the route-checker page reloads as the signed-in CP user.
                    // Best-effort: this cleanup navigation must never discard an already-acquired
                    // token, so swallow a hung/redirected page load instead of failing the step.
                    try { driver.Navigate().GoToUrl(originalUrl); }
                    catch (WebDriverException ex) { Console.WriteLine("Post-login navigation back to CP page failed: " + ex.Message); }
                }
            }
        }

        /// <summary>
        /// Drives the DEFRA Government Gateway sign-in UI: optional cookie banner, optional
        /// "How do you want to sign in?" chooser, then the user id / password credential page.
        ///
        /// The pages load asynchronously after window.open, and the chooser page is only
        /// sometimes shown, so rather than checking once in a fixed order we poll for whichever
        /// page is currently rendered and react to it. This avoids the race where we inspect a
        /// still-blank tab, skip the chooser, then wait forever for a credential field that is
        /// hidden behind the un-clicked chooser.
        /// </summary>
        private static string? DriveGovernmentGatewayLogin(IWebDriver driver, WebDriverWait wait, B2CConfig config)
        {
            var userIdBy = By.Id("user_id");
            var chooserBy = By.XPath("//label[@for='scp']");
            var cookiesBy = By.XPath("//button[contains(text(),'Accept analytics cookies')] | //button[contains(text(),'Accept additional cookies')]");

            // Step 1: wait until the credential page is reachable, handling the cookie banner and
            // the optional sign-in-method chooser whenever they appear during loading.
            //
            // The Government Gateway flow re-renders/navigates between polls, so an element located
            // at the top of an iteration can go stale before we act on it. Ignore that transient
            // staleness (re-poll with fresh references) rather than aborting the whole wait.
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            try
            {
                wait.Until(d =>
                {
                    try
                    {
                        // Dismiss the cookie banner if present (best effort).
                        TryClick(d, cookiesBy);

                        // If the credential field is ready, we're done waiting.
                        var userFields = d.FindElements(userIdBy);
                        if (userFields.Count > 0 && userFields[0].Displayed)
                            return true;

                        // If the "How do you want to sign in?" chooser is showing, pick Government
                        // Gateway and continue, then keep polling for the credential page.
                        var chooser = d.FindElements(chooserBy);
                        if (chooser.Count > 0 && chooser[0].Displayed)
                        {
                            ClickJs(d, chooser[0]);
                            var continueBtn = d.FindElements(By.XPath("//button[@id='continueReplacement']")).FirstOrDefault()
                                              ?? d.FindElements(By.XPath("//button[normalize-space()='Continue']")).FirstOrDefault();
                            if (continueBtn != null)
                                ClickJs(d, continueBtn);
                        }

                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        // Page re-rendered between locating an element and acting on it; re-poll
                        // with fresh references on the next iteration instead of failing.
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                LogCurrentPage(driver, "Timed out waiting for the Government Gateway credential page");
                throw;
            }

            // Step 2: enter credentials and submit, mirroring the proven CP SignInCPPage flow
            // exactly (no Clear(), scrollIntoView both fields, deliberate settle pauses, JS click
            // on the id*='continue' submit button).
            //
            // The credential page hydrates/re-renders client-side after it first appears, which on
            // some browsers (notably Firefox) invalidates element references located here between
            // the FindElement calls and the SendKeys/click. Re-locate and retry on that transient
            // staleness instead of aborting the whole scenario.
            var signInBy = By.XPath("//button[contains(@id,'continue')]");
            var credentialAttempts = 0;
            while (true)
            {
                try
                {
                    var userId = driver.FindElement(userIdBy);
                    var password = driver.FindElement(By.Id("password"));
                    var signIn = driver.FindElement(signInBy);

                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", signIn);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", userId);
                    userId.SendKeys(config.BackendUsername);
                    password.SendKeys(config.BackendPassword);
                    Thread.Sleep(2000);
                    ClickJs(driver, signIn);
                    break;
                }
                catch (StaleElementReferenceException) when (credentialAttempts++ < 3)
                {
                    // Page re-rendered mid credential entry; let it settle then re-locate.
                    Thread.Sleep(500);
                }
            }

            // Step 3: handle whatever Government Gateway shows after the credentials are submitted
            // - a direct redirect back to the app (no 2SV), a benign interstitial that just needs
            // progressing, or a 2-Step Verification access-code page (the URL gains aoc=Y).
            return HandlePostCredentialPages(driver, config);
        }

        /// <summary>
        /// Handles whatever Government Gateway shows after the credentials are submitted: a direct
        /// redirect back to the app (success), a benign interstitial (e.g. "Continue" / "Stay
        /// signed in") that simply needs progressing, or a 2-Step Verification access-code page.
        ///
        /// Benign interstitials are clicked through automatically. A 2SV access-code page is
        /// completed when a TOTP secret is configured (<see cref="B2CConfig.BackendTotpSecret"/>);
        /// otherwise it fails fast with an actionable message instead of a mystery 60s timeout.
        /// </summary>
        private static void HandleAccessCodePage(IWebDriver driver, B2CConfig config, IWebElement accessCodeField, By continueBy)
        {
            if (TryEnterAccessCode(driver, config, accessCodeField, continueBy))
                return;

            LogLoginPageState(driver);
            throw new Exception(BuildTwoStepMessage(config));
        }

        private static string? HandlePostCredentialPages(IWebDriver driver, B2CConfig config)
        {
            var accessCodeBy = By.CssSelector(
                "#accessCode, #access-code, #access_code, #code, #otp, " +
                "input[name='accessCode'], input[name='code'], input[autocomplete='one-time-code']");
            var continueBy = By.XPath(
                "//button[contains(@id,'continue')] | //button[normalize-space()='Continue'] | " +
                "//button[normalize-space()='Yes'] | //input[@type='submit' and @value='Continue']");
            var errorBy = By.CssSelector(".govuk-error-summary, .error-summary, #error-summary-title, .govuk-error-message");
            var userIdBy = By.Id("user_id");

            var deadline = DateTime.UtcNow.AddSeconds(30);
            while (DateTime.UtcNow < deadline)
            {
                // Success: B2C is redirecting back to the app with the code/error. Capture the URL
                // now (poll fast) before an unreachable-redirect tab-blank can discard the code.
                var resolved = ResolveRedirectUrl(driver.Url, config);
                if (resolved.StartsWith(config.RedirectUri, StringComparison.OrdinalIgnoreCase)
                    && (resolved.Contains("code=") || resolved.Contains("error=")))
                    return resolved;

                // 2-Step Verification access-code page - needs the one-time code.
                var accessCodeField = FirstDisplayedOrDefault(driver, accessCodeBy);
                if (accessCodeField != null)
                {
                    HandleAccessCodePage(driver, config, accessCodeField, continueBy);
                    Thread.Sleep(2000);
                    continue;
                }

                // Rejected credentials - re-rendered creds page with an error summary.
                if (AnyDisplayed(driver, userIdBy) && AnyDisplayed(driver, errorBy))
                {
                    LogLoginPageState(driver);
                    throw new Exception(
                        $"Backend Government Gateway login was rejected for user '{config.BackendUsername}'. " +
                        "Check B2CConfig.BackendUsername / BackendPassword (and the appsettings.local.json override).");
                }

                // Benign interstitial (e.g. "Stay signed in?", a standalone "Continue") - progress
                // it, but never re-click while the credentials form is still showing.
                var next = FirstDisplayedOrDefault(driver, continueBy);
                if (next != null && !AnyDisplayed(driver, userIdBy))
                {
                    // The element can go stale between locating and clicking when B2C SSOs straight
                    // through to the redirect (e.g. CP flow reusing an existing session); that means
                    // the page already advanced, so re-poll instead of failing.
                    try { ClickJs(driver, next); }
                    catch (StaleElementReferenceException) { }
                    Thread.Sleep(2000);
                    continue;
                }

                Thread.Sleep(250);
            }

            // Nothing progressed within the window. If it is a 2SV page we could not complete, say
            // so explicitly; otherwise surface the captured page state for the next run.
            LogLoginPageState(driver);
            if (driver.Url.Contains("aoc=Y", StringComparison.OrdinalIgnoreCase)
                || AnyDisplayed(driver, accessCodeBy))
                throw new Exception(BuildTwoStepMessage(config));

            return null;
        }

        // The B2C login pages re-render mid-poll, so an element found by FindElements can go stale
        // before its .Displayed is read. These helpers treat a stale element as "not displayed" so
        // the polling loop simply retries instead of throwing StaleElementReferenceException.
        private static bool AnyDisplayed(IWebDriver driver, By by)
        {
            foreach (var e in driver.FindElements(by))
            {
                try { if (e.Displayed) return true; }
                catch (StaleElementReferenceException) { }
            }
            return false;
        }

        private static IWebElement FirstDisplayedOrDefault(IWebDriver driver, By by)
        {
            foreach (var e in driver.FindElements(by))
            {
                try { if (e.Displayed) return e; }
                catch (StaleElementReferenceException) { }
            }
            return null;
        }

        // On mobile (BrowserStack iOS/Android) the redirect to the localhost redirect_uri cannot
        // load, so the browser shows a native error page whose ?url= parameter carries the real
        // redirect (URL-encoded, with & written as &amp;). Unwrap it so the authorization code is
        // still visible; on desktop the URL is returned unchanged.
        private static string ResolveRedirectUrl(string currentUrl, B2CConfig config)
        {
            if (string.IsNullOrEmpty(currentUrl)
                || currentUrl.StartsWith(config.RedirectUri, StringComparison.OrdinalIgnoreCase))
                return currentUrl;

            const string marker = "?url=";
            var idx = currentUrl.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
            if (idx >= 0)
            {
                var wrapped = HttpUtility.UrlDecode(currentUrl.Substring(idx + marker.Length));
                wrapped = HttpUtility.HtmlDecode(wrapped); // &amp; -> &
                if (wrapped.StartsWith(config.RedirectUri, StringComparison.OrdinalIgnoreCase))
                    return wrapped;
            }

            return currentUrl;
        }

        private static bool TryEnterAccessCode(IWebDriver driver, B2CConfig config, IWebElement accessCodeField, By continueBy)
        {
            if (string.IsNullOrWhiteSpace(config.BackendTotpSecret))
                return false;

            var code = GenerateTotp(config.BackendTotpSecret);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", accessCodeField);
            accessCodeField.SendKeys(code);
            Thread.Sleep(1000);

            var submit = driver.FindElements(continueBy).FirstOrDefault(e => e.Displayed);
            if (submit != null)
                ClickJs(driver, submit);
            return true;
        }

        private static string BuildTwoStepMessage(B2CConfig config) =>
            "Backend Government Gateway login stopped at a 2-Step Verification (access code) page " +
            $"(aoc=Y). The backend test user '{config.BackendUsername}' has 2-Step Verification enabled, " +
            "which cannot be completed automatically. Either use a backend user without 2SV (like the CP " +
            "test user, which signs straight through) or set B2CConfig.BackendTotpSecret to the user's " +
            "authenticator secret so the access code can be generated automatically.";

        /// <summary>
        /// Generates an RFC 6238 time-based one-time password (TOTP) from a Base32 authenticator
        /// secret using the standard 30s step / 6 digits / SHA1, matching Government Gateway
        /// authenticator-app codes. Implemented inline to avoid taking a new dependency.
        /// </summary>
        private static string GenerateTotp(string base32Secret, int digits = 6, int periodSeconds = 30)
        {
            var key = Base32Decode(base32Secret);
            var counter = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / periodSeconds;
            var counterBytes = BitConverter.GetBytes(counter);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(counterBytes);

            using var hmac = new System.Security.Cryptography.HMACSHA1(key);
            var hash = hmac.ComputeHash(counterBytes);
            var offset = hash[^1] & 0x0F;
            var binary = ((hash[offset] & 0x7F) << 24)
                         | ((hash[offset + 1] & 0xFF) << 16)
                         | ((hash[offset + 2] & 0xFF) << 8)
                         | (hash[offset + 3] & 0xFF);
            var otp = binary % (int)Math.Pow(10, digits);
            return otp.ToString().PadLeft(digits, '0');
        }

        private static byte[] Base32Decode(string input)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            input = input.Trim().Replace(" ", "").Replace("-", "").TrimEnd('=').ToUpperInvariant();

            var bits = 0;
            var value = 0;
            var output = new List<byte>();
            foreach (var c in input)
            {
                var idx = alphabet.IndexOf(c);
                if (idx < 0) continue;
                value = (value << 5) | idx;
                bits += 5;
                if (bits >= 8)
                {
                    output.Add((byte)((value >> (bits - 8)) & 0xFF));
                    bits -= 8;
                }
            }
            return output.ToArray();
        }

        /// <summary>
        /// When the credential page does not progress after submit, logs any GovUK error summary
        /// / field error and the entered user id length, so we can tell a failed click apart from
        /// rejected credentials without another blind rerun.
        /// </summary>
        private static void LogLoginPageState(IWebDriver driver)
        {
            try
            {
                var errorSummary = driver.FindElements(By.CssSelector(".govuk-error-summary, .govuk-error-message, .error-summary"))
                    .Select(e => e.Text?.Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t));
                var errors = string.Join(" | ", errorSummary);

                var headings = string.Join(" | ", driver.FindElements(By.XPath("//h1 | //h2"))
                    .Select(e => e.Text?.Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t)));

                var inputIds = string.Join(", ", driver.FindElements(By.TagName("input"))
                    .Select(e => e.GetAttribute("id"))
                    .Where(id => !string.IsNullOrWhiteSpace(id)));

                var enteredUser = driver.FindElements(By.Id("user_id")).FirstOrDefault()?.GetAttribute("value") ?? "(field gone)";

                Console.WriteLine("=== GOVERNMENT GATEWAY LOGIN DID NOT PROGRESS ===");
                Console.WriteLine($"Still on:        {driver.Url}");
                Console.WriteLine($"Headings:        {(string.IsNullOrEmpty(headings) ? "(none)" : headings)}");
                Console.WriteLine($"Input ids:       {(string.IsNullOrEmpty(inputIds) ? "(none)" : inputIds)}");
                Console.WriteLine($"user_id value:   '{enteredUser}' (length {enteredUser.Length})");
                Console.WriteLine($"Page error text: {(string.IsNullOrEmpty(errors) ? "(none found)" : errors)}");
                Console.WriteLine("================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not read login page state: {ex.Message}");
            }
        }

        /// <summary>
        /// Logs the current URL and page heading so a failed login is diagnosable from the run
        /// output without needing the screenshot.
        /// </summary>
        private static void LogCurrentPage(IWebDriver driver, string context)
        {
            try
            {
                var heading = driver.FindElements(By.XPath("//h1")).FirstOrDefault()?.Text ?? "(no h1)";
                Console.WriteLine($"{context}. Current URL: {driver.Url} | Page heading: {heading}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{context}. Could not read current page: {ex.Message}");
            }
        }

        private static void TryClick(IWebDriver driver, By by)
        {
            var el = driver.FindElements(by).FirstOrDefault();
            if (el != null)
            {
                try { ClickJs(driver, el); } catch { /* best effort */ }
            }
        }

        private static void ClickJs(IWebDriver driver, IWebElement element) =>
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);

        private static string ExchangeCodeForToken(string authority, B2CConfig config, string scope, string code)
        {
            var tokenEndpoint = $"{authority}/oauth2/v2.0/token";

            var parameters = new Dictionary<string, string>
            {
                ["grant_type"]    = "authorization_code",
                ["client_id"]     = config.ClientId,
                ["client_secret"] = config.ClientSecret,
                ["scope"]         = scope,
                ["code"]          = code,
                ["redirect_uri"]  = config.RedirectUri
            };

            var response = _httpClient.PostAsync(tokenEndpoint, new FormUrlEncodedContent(parameters)).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception($"B2C token exchange failed. Status: {response.StatusCode}, Body: {body}");

            var json = JsonConvert.DeserializeObject<dynamic>(body);
            string token = (string?)json?.access_token ?? string.Empty;

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception($"B2C token response did not contain an access_token. Body: {body}");

            LogTokenClaims(token);
            return token;
        }

        /// <summary>
        /// Decodes the JWT payload and logs the key claims so we can verify the token's
        /// audience/scope match what the APIM gateway expects when diagnosing 401s.
        /// </summary>
        private static void LogTokenClaims(string token)
        {
            try
            {
                var parts = token.Split('.');
                if (parts.Length < 2) return;

                var payload = parts[1];
                // Pad base64url to valid base64 length.
                payload = payload.Replace('-', '+').Replace('_', '/');
                switch (payload.Length % 4)
                {
                    case 2: payload += "=="; break;
                    case 3: payload += "="; break;
                }

                var jsonBytes = Convert.FromBase64String(payload);
                var payloadJson = System.Text.Encoding.UTF8.GetString(jsonBytes);
                var claims = JsonConvert.DeserializeObject<dynamic>(payloadJson);

                Console.WriteLine("=== ACCESS TOKEN CLAIMS ===");
                Console.WriteLine($"aud (audience): {claims?.aud}");
                Console.WriteLine($"iss (issuer):   {claims?.iss}");
                Console.WriteLine($"scp (scope):    {claims?.scp}");
                Console.WriteLine($"roles:          {claims?.roles}");
                Console.WriteLine($"azp/appid:      {claims?.azp} {claims?.appid}");
                Console.WriteLine($"sub:            {claims?.sub}");
                Console.WriteLine($"oid:            {claims?.oid}");
                Console.WriteLine($"exp:            {claims?.exp}");
                // Dump every claim so the backend token can be compared field-by-field against what
                // nipts-pts-web sends - the create call accepts this token but writetoqueue 500s, so
                // a missing/empty claim (e.g. scp/roles/a particular id) is the prime suspect.
                Console.WriteLine($"all claims:     {payloadJson}");
                Console.WriteLine("===========================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not decode token claims: {ex.Message}");
            }
        }
    }
}

using nipts_pts_automation_tests.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nipts_pts_automation_tests.HelperMethods
{
    /// <summary>
    /// iOS-only durable sign-in path that sidesteps the native Safari "Save Password"/AutoFill
    /// keychain sheet. That sheet is raised on the Government Gateway credential SUBMIT and
    /// permanently desyncs the BrowserStack Safari WebDriver command channel (no client-side code
    /// can recover it). Prevention on the Safari session has repeatedly failed because the sheet is
    /// an OS-level UIKit sheet, not a WebDriver alert.
    ///
    /// Strategy: drive the FULL applicant login in an isolated LOCAL headless Chrome (which never
    /// raises the iOS sheet), harvest the app-domain session cookies the app set after auth, then
    /// inject those cookies into the scenario's Safari session and reload the app - so the iOS
    /// session is signed in WITHOUT ever submitting the login form.
    ///
    /// Everything is best-effort: any failure returns false and the caller falls back to the normal
    /// UI sign-in (which still has its own fresh-session retry). Desktop/non-iOS never calls this.
    ///
    /// KNOWN RISKS (why this may not work and will simply return false if so):
    ///   * requires the isolated local Chrome to run on the agent (chromedriver next to the DLL) and
    ///     to reach B2C/Government Gateway;
    ///   * relies on the app's auth cookie being portable across browsers (ASP.NET Core auth cookies
    ///     are encrypted but not device/IP-bound by default - if the app binds them, replay fails);
    ///   * safaridriver is strict about AddCookie; cookies it rejects for the domain are skipped.
    /// </summary>
    public static class IosSessionInjector
    {
        private static int GlobalWaits => ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds;

        private static readonly By UserIdBy = By.Id("user_id");
        private static readonly By ChooserBy = By.XPath("//label[@for='scp']");
        private static readonly By SignInBy = By.XPath("//button[contains(text(),'Sign in')] | //button[contains(@id,'continue')]");
        private static readonly By ContinueBy = By.XPath("//button[@id='continueReplacement'] | //button[normalize-space()='Continue']");
        private static readonly By SignedInBy = By.XPath("//a[@href='/User/OSignOut']");
        private static readonly By BetaPasswordBy = By.XPath("//input[@id='EnteredPassword'] | //input[@id='password']");

        /// <summary>
        /// Attempts to sign the scenario (Safari) session in via local-login + cookie replay.
        /// Returns true only when the Safari session lands authenticated on the dashboard.
        /// </summary>
        public static bool TrySignInViaCookieReplay(IWebDriver scenarioDriver, string appUrl, string userId, string password)
        {
            if (string.IsNullOrWhiteSpace(appUrl) || string.IsNullOrWhiteSpace(userId))
                return false;

            IWebDriver? local = null;
            try
            {
                local = TokenAcquirer.CreateIsolatedBrowser();
                if (local == null)
                {
                    Console.WriteLine("iOS cookie-replay: no isolated local browser available on this agent.");
                    return false;
                }

                if (!DriveApplicantLoginLocally(local, appUrl, userId, password))
                {
                    Console.WriteLine("iOS cookie-replay: local applicant login did not reach the dashboard.");
                    return false;
                }

                var cookies = local.Manage().Cookies.AllCookies;
                if (cookies == null || cookies.Count == 0)
                {
                    Console.WriteLine("iOS cookie-replay: no app-domain cookies were harvested from the local login.");
                    return false;
                }

                var signedIn = InjectCookiesAndConfirm(scenarioDriver, appUrl, cookies);
                Console.WriteLine(signedIn
                    ? $"iOS cookie-replay: injected {cookies.Count} cookie(s); Safari session is signed in."
                    : "iOS cookie-replay: cookies injected but the Safari session did not confirm signed-in.");
                return signedIn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("iOS cookie-replay failed (" + ex.Message + "); falling back to UI sign-in.");
                return false;
            }
            finally
            {
                try { local?.Quit(); } catch { /* best-effort disposal */ }
            }
        }

        // Drives beta env-gate -> sign-in chooser -> Government Gateway credentials on the LOCAL
        // headless browser, then waits for the applicant dashboard. Returns true on success.
        private static bool DriveApplicantLoginLocally(IWebDriver driver, string appUrl, string userId, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits * 3));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            driver.Navigate().GoToUrl(appUrl);

            // Beta "Private beta testing login" env gate (present in tst).
            if (driver.FindElements(BetaPasswordBy).Count > 0 && driver.FindElements(UserIdBy).Count == 0)
            {
                TypeInto(driver, BetaPasswordBy, ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
                ClickFirst(driver, ContinueBy);
            }

            // "How do you want to sign in?" chooser -> Government Gateway.
            wait.Until(d => d.FindElements(UserIdBy).Count > 0
                            || d.FindElements(ChooserBy).Count > 0
                            || d.FindElements(SignedInBy).Count > 0);

            if (driver.FindElements(SignedInBy).Count > 0)
                return true;

            if (driver.FindElements(ChooserBy).Count > 0 && driver.FindElements(UserIdBy).Count == 0)
            {
                ClickFirst(driver, ChooserBy);
                ClickFirst(driver, ContinueBy);
                wait.Until(d => d.FindElements(UserIdBy).Count > 0);
            }

            // Government Gateway credentials.
            var attempts = 0;
            while (true)
            {
                try
                {
                    var user = driver.FindElement(UserIdBy);
                    var pass = driver.FindElement(By.Id("password"));
                    var signIn = driver.FindElement(SignInBy);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", user);
                    user.SendKeys(userId);
                    pass.SendKeys(password);
                    Thread.Sleep(1000);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", signIn);
                    break;
                }
                catch (StaleElementReferenceException) when (attempts++ < 3)
                {
                    Thread.Sleep(500);
                }
            }

            // Confirm the dashboard rendered (sign-out link present).
            var dashboardWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits * 3));
            dashboardWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            try
            {
                return dashboardWait.Until(d => d.FindElements(SignedInBy).Count > 0);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // Lands the scenario (Safari) session on the app domain, clears its cookies, replays the
        // harvested cookies, reloads the app and confirms the dashboard is shown.
        private static bool InjectCookiesAndConfirm(IWebDriver scenarioDriver, string appUrl, IReadOnlyCollection<Cookie> cookies)
        {
            var host = new Uri(appUrl).Host;

            // Must be on the app domain before cookies can be written for it.
            scenarioDriver.Navigate().GoToUrl(appUrl);
            try { scenarioDriver.Manage().Cookies.DeleteAllCookies(); } catch { /* best-effort */ }

            foreach (var cookie in cookies)
                AddCookieSafely(scenarioDriver, cookie, host);

            scenarioDriver.Navigate().GoToUrl(appUrl);

            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits * 3);
            while (DateTime.UtcNow < deadline)
            {
                if (scenarioDriver.IsCommandChannelWedged())
                    return false;
                try
                {
                    if (scenarioDriver.FindElements(SignedInBy).Count > 0)
                        return true;
                }
                catch (WebDriverException) { /* transient during load */ }
                Thread.Sleep(1000);
            }
            return false;
        }

        // safaridriver rejects cookies whose domain/attributes it dislikes, so try progressively
        // simpler constructions and skip any the driver will not accept.
        private static void AddCookieSafely(IWebDriver driver, Cookie source, string host)
        {
            var path = string.IsNullOrEmpty(source.Path) ? "/" : source.Path;
            var builders = new Func<Cookie>[]
            {
                () => new Cookie(source.Name, source.Value, source.Domain, path, source.Expiry, source.Secure, source.IsHttpOnly, source.SameSite),
                () => new Cookie(source.Name, source.Value, host, path, source.Expiry, source.Secure, source.IsHttpOnly, source.SameSite),
                () => new Cookie(source.Name, source.Value, host, path, source.Expiry),
                () => new Cookie(source.Name, source.Value, path)
            };

            foreach (var build in builders)
            {
                try
                {
                    driver.Manage().Cookies.AddCookie(build());
                    return;
                }
                catch (Exception) { /* try the next, simpler construction */ }
            }
        }

        private static void TypeInto(IWebDriver driver, By by, string text)
        {
            var element = driver.FindElements(by).FirstOrDefault();
            if (element == null) return;
            try { element.Clear(); } catch { /* some fields reject Clear */ }
            element.SendKeys(text);
        }

        private static void ClickFirst(IWebDriver driver, By by)
        {
            var element = driver.FindElements(by).FirstOrDefault();
            if (element == null) return;
            try { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element); }
            catch (Exception) { /* best-effort */ }
        }
    }
}

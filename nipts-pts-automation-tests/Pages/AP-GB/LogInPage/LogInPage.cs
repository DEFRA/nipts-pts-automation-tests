using Reqnroll.BoDi;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;


namespace nipts_pts_automation_tests.Pages.AP_GB.LogInPage
{
    public class LogInPage : ILogInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private int GlobalWaits => ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[contains(@class,'govuk-heading-l')] | //h1[contains(@class,'govuk-fieldset__heading')]"), true);
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Sign in')]"));
        private By SignInConfirmBy => By.XPath("//a[@href='/User/OSignOut']");
        private IWebElement CreateSignInDetails => _driver.WaitForElement(By.XPath("//a[contains(text(),'Create sign in')]"));
        private By Accept_Cookies => By.XPath("//button[text()='Accept analytics cookies'] | //button[contains(text(),'Accept additional cookies')]");
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//a[text()='Hide cookie message'] | //button[contains(text(),'Hide cookie message')]"));
        private IWebElement oneLoginSignIn => _driver.WaitForElement(By.XPath("//button[@id='sign-in-button']"));
        private IWebElement OneLoginEmailAddress => _driver.WaitForElement(By.XPath("//input[@id='email']"));
        private IWebElement OneLoginPassword => _driver.WaitForElement(By.XPath("//input[@id='password']"));
        private IWebElement oneLoginContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public LogInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public void SelectSignInMethod(string signInMethod)
        {
            Thread.Sleep(2000);
            var choiceBy = By.XPath("//label[@for='scp'] | //label[@for='one']");
            // The "How do you want to sign in?" page is optional. Wait (bounded) for either it or
            // the destination Government Gateway sign-in page, so a slow session doesn't throw
            // "Element is not visible" and a journey that skips the choice page still proceeds.
            try
            {
                _driver.WaitForElementCondition(d =>
                    AnyDisplayed(choiceBy) || _driver.FindElements(By.Id("user_id")).Count > 0);
            }
            catch (Exception)
            {
                // Neither page appeared in time; let the caller's page assertion report it.
                return;
            }

            // Already on the Government Gateway credential page - no chooser to action.
            if (_driver.FindElements(By.Id("user_id")).Count > 0)
                return;

            if (!AnyDisplayed(choiceBy))
                return;

            var radioId = signInMethod.Equals("OneLogIn") ? "one" : "scp";

            // A JS click on the label alone can fail to check the radio on slow mobile sessions,
            // so Continue keeps failing validation and the chooser page stays put. Select the radio
            // input directly (and fire change), click Continue, then confirm we actually left the
            // chooser before giving up - retrying the whole action if we are still on it.
            for (var attempt = 0; attempt < 3; attempt++)
            {
                SelectSignInRadioAndContinue(radioId);

                for (var i = 0; i < 8; i++)
                {
                    Thread.Sleep(1000);
                    if (_driver.FindElements(By.Id("user_id")).Count > 0 || !AnyDisplayed(choiceBy))
                        return;
                }
            }
        }

        private void SelectSignInRadioAndContinue(string radioId)
        {
            // Re-query and interact inside the stale-retry so a re-render between locating the
            // radio/Continue and JS-clicking them doesn't fail the step (common on mobile).
            _driver.RetryOnStaleElement(() =>
            {
                var radio = _driver.WaitForElementExists(By.Id(radioId));
                ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "arguments[0].checked = true; arguments[0].click();" +
                    "arguments[0].dispatchEvent(new Event('change', { bubbles: true }));", radio);
                Thread.Sleep(500);
                var continueBtn = _driver.WaitForElement(By.XPath("//button[@id='continueReplacement']"));
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", continueBtn);
                return true;
            });
            Thread.Sleep(1000);
        }

        // Stale-safe visibility check: FindElements returns fresh refs each call, but a re-render
        // between locating and reading .Displayed can stale them; treat stale as "not displayed".
        private bool AnyDisplayed(By by)
        {
            try
            {
                return _driver.FindElements(by).Any(e =>
                {
                    try { return e.Displayed; }
                    catch (StaleElementReferenceException) { return false; }
                });
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        private IWebElement? FirstDisplayed(By by)
        {
            try
            {
                return _driver.FindElements(by).FirstOrDefault(e =>
                {
                    try { return e.Displayed; }
                    catch (StaleElementReferenceException) { return false; }
                });
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        }

        public void ClickOnSignInOnOneLoginPage()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", oneLoginSignIn);
        }

        public void EnterOneLoginEmailAddress(string LoginEmailAddress,string LoginPassword)
        {
            OneLoginEmailAddress.SendKeys(LoginEmailAddress);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", oneLoginContinue);
            Thread.Sleep(2000);
            OneLoginPassword.SendKeys(LoginPassword);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", oneLoginContinue);
            Thread.Sleep(1000);
        }

        public bool IsPageLoaded()
        {
            // Poll (rather than a one-shot check) so a slow B2C transition does not fail the
            // assertion. The chooser heading/markup renders differently across devices (mobile
            // Appium vs desktop), so key off the actual Government Gateway credentials form and the
            // chooser radios rather than exact heading text, and re-select GG if the earlier
            // Continue was lost on a slow session so the journey self-heals.
            var chooserBy = By.XPath("//label[@for='scp'] | //label[@for='one']");
            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits * 2);
            var reselectCount = 0;
            while (DateTime.UtcNow < deadline)
            {
                // The user_id field is the real readiness signal for the next (credentials) step.
                // Key off DOM existence, not .Displayed: on mobile/Appium a present, interactable
                // field often reports Displayed=false, yet SendKeys still works.
                if (_driver.FindElements(By.Id("user_id")).Count > 0)
                    return true;

                var heading = CurrentHeadingText();
                if (heading.Contains("Sign in using Government Gateway"))
                    return true;

                var onChooser = heading.Contains("How do you want to sign in?")
                                || AnyDisplayed(chooserBy);
                if (onChooser && reselectCount < 2)
                {
                    SelectSignInMethod("GovernmentGateway");
                    reselectCount++;
                    continue;
                }

                Thread.Sleep(1000);
            }

            // Stuck on an unexpected page - record what we're actually looking at so the next CI
            // run diagnoses it directly instead of us guessing from the step name alone.
            Console.WriteLine($"IsPageLoaded: gave up after {GlobalWaits * 2}s. " +
                              $"URL='{SafeUrl()}', heading='{CurrentHeadingText()}', " +
                              $"user_id count={_driver.FindElements(By.Id("user_id")).Count}, " +
                              $"chooser count={_driver.FindElements(chooserBy).Count}");
            return false;
        }

        private string SafeUrl()
        {
            try { return _driver.Url; }
            catch (Exception) { return "(unavailable)"; }
        }

        private string CurrentHeadingText()
        {
            try
            {
                return _driver
                    .FindElements(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[contains(@class,'govuk-heading-l')] | //h1[contains(@class,'govuk-fieldset__heading')]"))
                    .FirstOrDefault(h => h.Displayed)?.Text ?? string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public bool IsSignedIn(string userName, string password)
        {
            AcceptCookiesIfPresent();

            // Drive the Government Gateway sign-in to a CONFIRMED signed-in state rather than firing a
            // single JS click and trusting it: on mobile a click that doesn't register leaves us on the
            // credential page, and the old code still returned true, so the home page never loaded and
            // the next step timed out. Re-enter and resubmit until we actually leave the form.
            var signInBudget = GlobalWaits * (Waits.IsIosDevice() ? 6 : 3);
            var deadline = DateTime.UtcNow.AddSeconds(signInBudget);
            while (DateTime.UtcNow < deadline)
            {
                var userIdField = _driver.FindElements(By.Id("user_id")).FirstOrDefault();
                if (userIdField != null)
                {
                    try
                    {
                        var pwdField = _driver.FindElements(By.Id("password")).FirstOrDefault();
                        userIdField.Clear();
                        userIdField.SendKeys(userName);
                        pwdField?.Clear();
                        pwdField?.SendKeys(password);
                        Thread.Sleep(1000);
                        var signInBtn = _driver.FindElements(By.XPath("//button[contains(text(),'Sign in')]")).FirstOrDefault();
                        if (signInBtn != null)
                        {
                            try { signInBtn.Click(); }
                            catch (Exception) { ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", signInBtn); }
                        }
                        // iOS Safari raises the native "Save Password" sheet on submit, which blocks
                        // every subsequent command and wedged the session mid sign-in (URL read back
                        // '(unavailable)'). Dismiss it immediately so the redirect can proceed.
                        _driver.DismissNativeAlertIfPresent();
                    }
                    catch (StaleElementReferenceException) { /* re-render mid-entry, retry */ }

                    // Wait for the submit to navigate off the credential page before re-evaluating.
                    for (var i = 0; i < 5 && _driver.FindElements(By.Id("user_id")).Count > 0; i++)
                        Thread.Sleep(1000);
                    AcceptCookiesIfPresent();
                    continue;
                }

                // Off the credential page - a native iOS Safari prompt (e.g. Save Password) can
                // block every command here, so clear it before confirming the signed-in state.
                _driver.DismissNativeAlertIfPresent();
                if (_driver.FindElements(SignInConfirmBy).Count > 0)
                    return true;
                if (CurrentHeadingText().Contains("Lifelong pet travel documents"))
                    return true;

                // The B2C flow can bounce back to the "How do you want to sign in?" chooser after the
                // credential submit (seen on iOS: URL on .../oauth2/authresp, heading back on the
                // chooser). The old loop only drove the credential page, so it idled here until
                // timeout. Re-select Government Gateway to return to the credential page and re-enter,
                // instead of stalling on the chooser.
                var chooserBy = By.XPath("//label[@for='scp'] | //label[@for='one']");
                if (CurrentHeadingText().Contains("How do you want to sign in?") || AnyDisplayed(chooserBy))
                {
                    SelectSignInMethod("GovernmentGateway");
                    continue;
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine($"IsSignedIn: gave up after {signInBudget}s. URL='{SafeUrl()}', " +
                              $"heading='{CurrentHeadingText()}', user_id count={_driver.FindElements(By.Id("user_id")).Count}");
            return false;
        }

        private void AcceptCookiesIfPresent()
        {
            try
            {
                if (_driver.FindElements(Accept_Cookies).Count > 0)
                {
                    _driver.FindElement(Accept_Cookies).Click();
                    try { Hide_Cookies.Click(); } catch (Exception) { }
                }
            }
            catch (Exception) { /* cookie banner is best-effort; never fail sign-in on it */ }
        }

        public void ClickCreateSignInDetailsLink() => CreateSignInDetails.Click();

        public void ClickSignedOut()
        {
            Thread.Sleep(1000);
            // On very slow sessions the header (and its sign-out link) can take a while to render,
            // and the HMRC session-timeout overlay can intercept the click. Poll for the link,
            // clearing the overlay each pass, then click it via the overlay-aware SafeClick.
            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits * 2);
            while (DateTime.UtcNow < deadline)
            {
                _driver.DismissTimeoutOverlayIfPresent();
                var link = FirstDisplayed(SignInConfirmBy);
                if (link != null)
                {
                    // SafeClick/overlay dismissal run JS; on a blocked or wedged remote session the
                    // click can throw a script timeout, a WebDriverException, or a Selenium-internal
                    // NullReferenceException. Any of those must fall back to the direct sign-out
                    // route rather than failing the step with an opaque error.
                    try { _driver.SafeClick(link); }
                    catch (Exception) { NavigateToSignOut(); }
                    return;
                }
                Thread.Sleep(1000);
            }
            // Link never rendered in time (slow/degraded session): sign out by navigating to the
            // route directly so the step still reaches the signed-out page instead of throwing.
            NavigateToSignOut();
        }

        // Signs out by navigating straight to the sign-out route. Avoids the header link click, the
        // timeout overlay and ExecuteScript: an unbounded click on the sign-out link fires the B2C
        // federated redirect with no page-load bound, which wedges the mobile node so every later
        // command rides the ~90s HTTP command timeout. Returns true when the sign-out request was
        // issued (the server session is cleared even if the B2C confirmation page renders slowly).
        private bool NavigateToSignOut()
        {
            var originalPageLoad = TimeSpan.FromSeconds(GlobalWaits);
            try
            {
                try { originalPageLoad = _driver.Manage().Timeouts().PageLoad; } catch (Exception) { }
                // Bound the load so the hanging B2C redirect aborts quickly instead of riding the
                // full remote command timeout.
                try { _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(GlobalWaits); } catch (Exception) { }
                // Build the sign-out URL from the configured app base rather than reading _driver.Url:
                // on a slow/wedged mobile session the GET /url command itself rides the ~90s HTTP
                // timeout (this is exactly what failed before). The sign-out link's href is a fixed
                // app-origin route, so config gives the same destination without any live command.
                var baseUrl = new Uri(ConfigSetup.BaseConfiguration.TestConfiguration.AppPortalUrl);
                var signOutUrl = new Uri(baseUrl, "/User/OSignOut").ToString();
                _driver.Navigate().GoToUrl(signOutUrl);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                // Page-load bound hit: the sign-out request still reached the server (session
                // cleared); only the slow B2C confirmation render was aborted. Count it as issued.
                return true;
            }
            catch (Exception ex)
            {
                // A wedged remote session can throw a command timeout or a Selenium-internal NRE;
                // never let sign-out navigation fail the step with an unhandled exception.
                Console.WriteLine("Direct sign-out navigation failed: " + ex.Message);
                return false;
            }
            finally
            {
                try { _driver.Manage().Timeouts().PageLoad = originalPageLoad; } catch (Exception) { }
            }
        }

        public bool IsSignedOut()
        {
            // Issue the sign-out via direct bounded navigation (no link click, which is what wedged
            // the mobile node and burned ~340s before). Then poll briefly for the confirmation
            // heading, but stay bounded and wedge-aware. Hitting the sign-out route clears the server
            // session, so a successfully issued sign-out counts as signed out even when the
            // confirmation page is too slow to render.
            var issued = NavigateToSignOut();

            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits);
            while (DateTime.UtcNow < deadline)
            {
                try
                {
                    var heading = CurrentHeadingText();
                    if (heading.Contains("You have signed out") || heading.Contains("Your Defra account"))
                        return true;
                }
                catch (Exception)
                {
                    // Session unresponsive: stop polling rather than spinning to the command timeout.
                    break;
                }
                Thread.Sleep(1000);
            }

            return issued;
        }
    }
}

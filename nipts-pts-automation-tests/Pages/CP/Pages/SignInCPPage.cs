using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class SignInCPPage : ISignInCPPage
    {
        private readonly IObjectContainer _objectContainer;

        public SignInCPPage(IObjectContainer container)
        {
            _objectContainer = container;
        }


        #region Page objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement btnSignIn => _driver.WaitForElement(By.XPath("//a[contains(text(),'Sign in')] | //button[contains(text(),'Sign in')]"));
        private IWebElement UserId => _driver.FindElement(By.CssSelector("#user_id"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//button[contains(@id,'continue')]"));
        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement SignOut => _driver.WaitForElement(By.XPath("//a[@href='/signout'] | //button[contains(text(),'Sign out')]"));
        private IWebElement AcceptAdditionalCookies => _driver.WaitForElement(By.XPath("//button[contains(text(),'Accept analytics cookies')]"));
        private IWebElement HideCookieMessage => _driver.WaitForElement(By.XPath("//a[contains(text(),'Hide cookie message')]"));
        private IWebElement lnkAccessibilityStatement => _driver.WaitForElement(By.XPath("//p[@class='govuk-body']//a"));
        private IWebElement signInGovernmentGateway => _driver.WaitForElement(By.XPath("//label[@for='scp']"));
        private IWebElement signInContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue'][@id='continueReplacement']"));

        #endregion

        #region Methods
        public void ClickSignInButton()
        {
            var signInBy = By.XPath("//a[contains(text(),'Sign in')] | //button[contains(text(),'Sign in')]");
            var chooserBy = By.XPath("//label[@for='scp']");
            var deadline = DateTime.UtcNow.AddSeconds(
                ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds * (Waits.IsIosDevice() ? 6 : 3));

            // Poll for the Sign in link by PRESENCE rather than WaitForElement, which throws
            // "Element is not visible" and fails the step when a slow landing-page render or an early
            // test-environment gate means the link isn't there yet. Clear the gate each pass, then
            // click via a deferred JS click so the B2C redirect it fires can't wedge the session.
            while (DateTime.UtcNow < deadline)
            {
                try
                {
                    _driver.DismissNativeAlertIfPresent();

                    // Already past the landing page (chooser or credentials showing) - nothing to click here.
                    if (_driver.FindElements(By.CssSelector("#user_id")).Count > 0
                        || _driver.FindElements(chooserBy).Count > 0)
                        break;

                    HandleEnvironmentGateIfPresent();

                    var signIn = _driver.FindElements(signInBy).FirstOrDefault();
                    if (signIn != null)
                    {
                        JsClickAsync(signIn);
                        break;
                    }
                }
                catch (StaleElementReferenceException) { /* re-render mid-read, retry */ }
                catch (WebDriverException) { /* transient command failure on a slow node, retry */ }
                Thread.Sleep(1000);
            }

            Thread.Sleep(2000);
            if (_driver.FindElements(By.XPath("//button[contains(text(),'Accept analytics cookies')]")).Count() > 0)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", AcceptAdditionalCookies);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", HideCookieMessage);
            }

            Thread.Sleep(3000);
            var ggLabel = _driver.FindElements(chooserBy).FirstOrDefault();
            if (ggLabel != null)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ggLabel);
                Thread.Sleep(3000);
                var cont = _driver.FindElements(By.XPath("//button[@id='continueReplacement'] | //button[normalize-space()='Continue']")).FirstOrDefault();
                if (cont != null) JsClickAsync(cont);
                Thread.Sleep(2000);
            }
        }

        public void IsSignedIn(string userName, string password)
        {
            // The CP sign-in walks through several interstitials (test-environment gate, "How do you
            // want to sign in?", then Government Gateway) whose order and timing shift on slow mobile
            // sessions, so a fixed step sequence strands the flow when one page hasn't rendered yet.
            // Drive whatever page is currently shown, in a loop, until the credentials are submitted.
            var js = (IJavaScriptExecutor)_driver;
            var deadline = DateTime.UtcNow.AddSeconds(
                ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds * (Waits.IsIosDevice() ? 6 : 3));

            while (DateTime.UtcNow < deadline)
            {
                try
                {
                    // A native iOS Safari prompt (e.g. "Save Password") can block every command and
                    // stall the whole sign-in; clear it first each iteration so the session responds.
                    _driver.DismissNativeAlertIfPresent();

                    // Government Gateway credentials page: enter and submit, then keep driving - a
                    // post-sign-in "test environment" gate can still stand between us and the route
                    // checker, and its redirect can lag, so we must poll for it rather than hand off.
                    var userIdField = _driver.FindElements(By.CssSelector("#user_id")).FirstOrDefault();
                    if (userIdField != null)
                    {
                        var pwdField = _driver.FindElements(By.CssSelector("#password")).FirstOrDefault();
                        var submit = _driver.FindElements(By.XPath("//button[contains(@id,'continue')]")).FirstOrDefault();
                        js.ExecuteScript("arguments[0].scrollIntoView()", userIdField);
                        TypeInto(userIdField, userName);
                        if (pwdField != null) TypeInto(pwdField, password);
                        Thread.Sleep(1000);
                        // Fire the submit asynchronously so ExecuteScript returns immediately instead of
                        // riding the B2C sign-in redirect into the ~90s remote HTTP command timeout.
                        if (submit != null) JsClickAsync(submit);
                        // iOS Safari raises the native "Save Password" sheet on submit, which blocks
                        // the redirect and wedges the session; dismiss it straight away.
                        _driver.DismissNativeAlertIfPresent();
                        // Wait to actually leave the credential page before re-evaluating.
                        for (var i = 0; i < 8 && _driver.FindElements(By.CssSelector("#user_id")).Count > 0; i++)
                            Thread.Sleep(1000);
                        continue;
                    }

                    // "How do you want to sign in?" page: choose Government Gateway and continue.
                    var ggChoice = _driver.FindElements(By.XPath("//label[@for='scp']")).FirstOrDefault();
                    if (ggChoice != null)
                    {
                        js.ExecuteScript("arguments[0].click();", ggChoice);
                        Thread.Sleep(1000);
                        var cont = _driver.FindElements(By.XPath("//button[@id='continueReplacement'] | //button[normalize-space()='Continue']")).FirstOrDefault();
                        if (cont != null) JsClickAsync(cont);
                        Thread.Sleep(2000);
                        continue;
                    }

                    // "This is a test environment" password gate (before or after credentials).
                    if (HandleEnvironmentGateIfPresent())
                        continue;

                    // Reached the port route checker: sign-in and all interstitials are done.
                    if (HeadingContains("What route are you checking?"))
                        return;
                }
                catch (StaleElementReferenceException) { /* page re-rendered mid-read, retry */ }

                Thread.Sleep(1000);
            }
        }

        public bool IsSignedOut()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SignOut);
            _driver.WaitForElementCondition(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']")));
            Thread.Sleep(4000);
            // Sign-out redirects on to the Defra account page, which re-renders the heading mid-read,
            // so read the text once with a stale-tolerant retry rather than dereferencing it twice.
            var heading = ReadHeadingTextSafely();
            return heading.Contains("You have signed out") || heading.Contains("Your Defra account");
        }

        private string ReadHeadingTextSafely()
        {
            var by = By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']");
            for (int attempt = 0; attempt < 5; attempt++)
            {
                try
                {
                    return _driver.WaitForElement(by).Text;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(500);
                }
            }
            return string.Empty;
        }

        public void EnterPassword()
        {
            Thread.Sleep(3000);
            HandleEnvironmentGateIfPresent();
        }

        // Handles the "This is a test environment" gate (a splash Continue, then a password page) if it
        // is the current page. Returns true when the gate was present and processed. Shared so the
        // credential loop can advance through it regardless of which step happens to encounter it.
        private bool HandleEnvironmentGateIfPresent()
        {
            if (!HeadingContains("This is a test environment"))
                return false;

            var jsExecutor = (IJavaScriptExecutor)_driver;
            var cont = _driver.FindElements(By.XPath("//button[normalize-space()='Continue']")).FirstOrDefault();
            if (cont != null)
            {
                jsExecutor.ExecuteScript("arguments[0].scrollIntoView()", cont);
                jsExecutor.ExecuteScript("arguments[0].click();", cont);
                Thread.Sleep(5000);
            }

            var envField = _driver.FindElements(By.XPath("//input[@id='password']")).FirstOrDefault();
            if (envField != null)
            {
                TypeInto(envField, ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
                Thread.Sleep(3000);
                cont = _driver.FindElements(By.XPath("//button[normalize-space()='Continue']")).FirstOrDefault();
                if (cont != null) jsExecutor.ExecuteScript("arguments[0].click();", cont);
                Thread.Sleep(5000);
            }
            return true;
        }

        // True if any visible page heading/legend contains the text (textContent fallback for mobile
        // govuk headings that report Displayed=false).
        private bool HeadingContains(string text)
        {
            try
            {
                return _driver.FindElements(By.XPath("//h1 | //legend")).Any(h =>
                {
                    var t = h.Text;
                    if (string.IsNullOrEmpty(t)) t = h.GetAttribute("textContent") ?? string.Empty;
                    return t.Contains(text);
                });
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        // SendKeys, falling back to a JS value-set for fields that aren't natively interactable on mobile.
        private void TypeInto(IWebElement field, string value)
        {
            try
            {
                field.SendKeys(value);
            }
            catch (Exception)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "arguments[0].value=arguments[1];arguments[0].dispatchEvent(new Event('input',{bubbles:true}));",
                    field, value);
            }
        }

        // Fires the click asynchronously (setTimeout) so ExecuteScript returns immediately instead of
        // blocking on the B2C federated redirect the click triggers - a synchronous JS click on these
        // navigation controls rode the ~90s remote HTTP command timeout and killed the session.
        private void JsClickAsync(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(
                "var el=arguments[0]; setTimeout(function(){ el.click(); }, 50);", element);
        }

        public void ClickAccessibilityStatementLink()
        {
            lnkAccessibilityStatement.Click();
            
        }

        public bool VerifySignoutButtonNotVisibleOnCPWAFPage()
        {
            if(_driver.FindElements(By.XPath("//button[contains(text(),'Sign out')]")).Count > 0)
                return false;
            else
                return true;
        }
        #endregion

    }
}

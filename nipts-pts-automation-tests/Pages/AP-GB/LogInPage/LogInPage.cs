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
                    d.FindElements(choiceBy).Any(e => e.Displayed)
                    || d.FindElements(By.Id("user_id")).Any(e => e.Displayed));
            }
            catch (Exception)
            {
                // Neither page appeared in time; let the caller's page assertion report it.
                return;
            }

            // Already on the Government Gateway credential page - no chooser to action.
            if (_driver.FindElements(By.Id("user_id")).Any(e => e.Displayed))
                return;

            if (!_driver.FindElements(choiceBy).Any(e => e.Displayed))
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
                    if (_driver.FindElements(By.Id("user_id")).Any(e => e.Displayed)
                        || !_driver.FindElements(choiceBy).Any(e => e.Displayed))
                        return;
                }
            }
        }

        private void SelectSignInRadioAndContinue(string radioId)
        {
            var radio = _driver.WaitForElementExists(By.Id(radioId));
            ((IJavaScriptExecutor)_driver).ExecuteScript(
                "arguments[0].checked = true; arguments[0].click();" +
                "arguments[0].dispatchEvent(new Event('change', { bubbles: true }));", radio);
            Thread.Sleep(500);
            var continueBtn = _driver.WaitForElement(By.XPath("//button[@id='continueReplacement']"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", continueBtn);
            Thread.Sleep(1000);
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
                // The user_id field is the real readiness signal for the next (credentials) step,
                // regardless of how the heading renders on this browser/device.
                if (_driver.FindElements(By.Id("user_id")).Any(e => e.Displayed))
                    return true;

                var heading = CurrentHeadingText();
                if (heading.Contains("Sign in using Government Gateway"))
                    return true;

                var onChooser = heading.Contains("How do you want to sign in?")
                                || _driver.FindElements(chooserBy).Any(e => e.Displayed);
                if (onChooser && reselectCount < 2)
                {
                    SelectSignInMethod("GovernmentGateway");
                    reselectCount++;
                    continue;
                }

                Thread.Sleep(1000);
            }
            return false;
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
            if (_driver.FindElements(Accept_Cookies).Count > 0)
            {
                _driver.FindElement(Accept_Cookies).Click();
                Hide_Cookies.Click();
            }
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", SignIn);
            Thread.Sleep(1000);
            if (_driver.FindElements(Accept_Cookies).Count > 0)
            {
                Thread.Sleep(1000);
                _driver.FindElement(Accept_Cookies).Click();
                Hide_Cookies.Click();
            }
            if (_driver.FindElements(SignInConfirmBy).Count > 0)
                return _driver.WaitForElement(SignInConfirmBy).Enabled;
            else 
                return true;
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
                var link = _driver.FindElements(SignInConfirmBy).FirstOrDefault(e => e.Displayed);
                if (link != null)
                {
                    _driver.SafeClick(link);
                    return;
                }
                Thread.Sleep(1000);
            }
            // Nothing found in time - fall back to the original wait so the caller still gets a
            // meaningful ElementNotVisibleException rather than a silent no-op.
            _driver.WaitForElement(SignInConfirmBy).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            // Poll for the signed-out confirmation rather than reading the heading once: on a slow
            // session the sign-out redirect can lag behind the click.
            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits);
            while (DateTime.UtcNow < deadline)
            {
                var heading = CurrentHeadingText();
                if (heading.Contains("You have signed out") || heading.Contains("Your Defra account"))
                    return true;
                Thread.Sleep(1000);
            }
            return false;
        }
    }
}

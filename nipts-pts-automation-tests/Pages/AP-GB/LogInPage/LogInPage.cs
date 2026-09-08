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
            if (AnyDisplayed(By.Id("user_id")))
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
                    if (AnyDisplayed(By.Id("user_id")) || !AnyDisplayed(choiceBy))
                        return;
                }
            }
        }

        // iOS Safari re-renders the DOM during the B2C redirect chain, so an element found by
        // FindElements can go stale before .Displayed is read. Swallow that (treat as not present)
        // instead of letting "Element does not exist in cache" bubble up and fail the step.
        private bool AnyDisplayed(By by)
        {
            try
            {
                return _driver.FindElements(by).Any(e => e.Displayed);
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        private void SelectSignInRadioAndContinue(string radioId)
        {
            try
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
            catch (StaleElementReferenceException)
            {
                // The chooser re-rendered mid-action; the caller's loop re-checks the page and
                // retries with fresh elements, so end this attempt quietly.
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
            // assertion. If the "How do you want to sign in?" chooser is still showing, the earlier
            // Continue click was lost on a slow session - re-select Government Gateway once so the
            // journey self-heals instead of asserting on the wrong heading.
            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits * 2);
            var reselected = false;
            while (DateTime.UtcNow < deadline)
            {
                var heading = CurrentHeadingText();
                if (heading.Contains("Sign in using Government Gateway"))
                    return true;

                if (!reselected && heading.Contains("How do you want to sign in?"))
                {
                    SelectSignInMethod("GovernmentGateway");
                    reselected = true;
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
                var heading = _driver
                    .FindElements(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[contains(@class,'govuk-heading-l')] | //h1[contains(@class,'govuk-fieldset__heading')]"))
                    .FirstOrDefault(h => h.Displayed);
                if (heading == null)
                    return string.Empty;
                // iOS Safari often returns an empty .Text for a rendered element, so fall back to the
                // DOM textContent - otherwise the signed-out heading reads blank and never matches.
                var text = heading.Text;
                if (string.IsNullOrWhiteSpace(text))
                    text = heading.GetAttribute("textContent") ?? string.Empty;
                return text;
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
            SuppressIosSavePasswordSheet();
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", SignIn);
            Thread.Sleep(1000);
            if (_driver.FindElements(Accept_Cookies).Count > 0)
            {
                Thread.Sleep(1000);
                _driver.FindElement(Accept_Cookies).Click();
                Hide_Cookies.Click();
            }
            // iOS: the "Save Password" sheet can wedge the session AFTER this step, so the old
            // "no sign-out link yet => assume success" shortcut declared success too early and the
            // wedge then killed a later step with no retry. Instead, actively confirm the
            // authenticated state here; returning false on a wedge/timeout lets the caller recreate
            // the session and retry sign-in (which is where recovery is wired).
            if (Waits.IsIosDevice())
                return ConfirmSignedInIos();

            if (_driver.FindElements(SignInConfirmBy).Count > 0)
                return _driver.WaitForElement(SignInConfirmBy).Enabled;
            else 
                return true;
        }

        private bool ConfirmSignedInIos()
        {
            // Healthy sessions confirm as soon as the dashboard renders (the sign-out link appears or
            // the dashboard heading shows). A wedged session trips IsCommandChannelWedged and bails
            // fast, so a generous budget never penalises a slow-but-healthy load.
            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits * 6);
            while (DateTime.UtcNow < deadline)
            {
                if (_driver.IsCommandChannelWedged())
                    return false;
                try
                {
                    _driver.DismissNativeAlertIfPresent();
                    if (_driver.FindElements(SignInConfirmBy).Count > 0)
                        return true;
                    if (CurrentHeadingText().Contains("Lifelong pet travel documents"))
                        return true;
                }
                catch (WebDriverException)
                {
                    // Command likely riding the wedge timeout; the next IsCommandChannelWedged confirms.
                }
                Thread.Sleep(1000);
            }
            return false;
        }

        public void ClickCreateSignInDetailsLink() => CreateSignInDetails.Click();

        // iOS Safari pops a native "Save Password" keychain sheet after a login form submits. It is
        // NOT a WebDriver alert, so it can't be dismissed and it blocks every following command until
        // the ~90s HTTP timeout desyncs the session for good (URL reads '(unavailable)'). The sheet
        // only triggers when a type=password field is submitted, so on iOS neutralise the field
        // (value/name preserved -> identical POST) right before clicking Sign in to stop it appearing.
        private void SuppressIosSavePasswordSheet()
        {
            if (!Waits.IsIosDevice()) return;
            try
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "var pw=document.getElementById('password');" +
                    "if(pw){var f=pw.form; if(f){f.setAttribute('autocomplete','off');}" +
                    "pw.setAttribute('autocomplete','off'); pw.type='text';}" +
                    "var uid=document.getElementById('user_id');" +
                    "if(uid){uid.setAttribute('autocomplete','off');}" +
                    "if(document.activeElement){document.activeElement.blur();}");
            }
            catch (Exception)
            {
                // Best-effort suppression - never fail sign-in because the tweak errored.
            }
        }

        public void ClickSignedOut()
        {
            Thread.Sleep(1000);
            // On very slow sessions the header (and its sign-out link) can take a while to render,
            // and the HMRC session-timeout overlay can intercept the click. Poll for the link,
            // clearing the overlay each pass. On mobile (iPhone) the link lives in a collapsed menu
            // so it never reports Displayed - in that case navigate straight to its href (the sign-out
            // endpoint) to bypass the menu entirely.
            var deadline = DateTime.UtcNow.AddSeconds(GlobalWaits * 2);
            while (DateTime.UtcNow < deadline)
            {
                try
                {
                    _driver.DismissTimeoutOverlayIfPresent();
                    var links = _driver.FindElements(SignInConfirmBy);
                    var visible = links.FirstOrDefault(e => e.Displayed);
                    if (visible != null)
                    {
                        // A JS click is more reliable than a native click on iOS Safari, where a
                        // native .Click() can silently no-op and leave the session still signed in.
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", visible);
                        return;
                    }
                    var href = links.FirstOrDefault()?.GetAttribute("href");
                    if (!string.IsNullOrWhiteSpace(href))
                    {
                        _driver.Navigate().GoToUrl(href);
                        return;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    // The Back navigation re-renders the header while we grab/click the link, so the
                    // element can go stale mid-pass (iOS Safari reports this as "not in cache").
                    // Swallow and re-find on the next poll instead of failing the step.
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

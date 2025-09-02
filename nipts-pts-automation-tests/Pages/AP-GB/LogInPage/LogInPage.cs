using Reqnroll.BoDi;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;


namespace nipts_pts_automation_tests.Pages.AP_GB.LogInPage
{
    public class LogInPage : ILogInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"), true);
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Sign in')]"));
        private By SignInConfirmBy => By.XPath("//a[@href='/User/OSignOut']");
        private IWebElement CreateSignInDetails => _driver.WaitForElement(By.XPath("//a[contains(text(),'Create sign in')]"));
        private By Accept_Cookies => By.XPath("//button[text()='Accept analytics cookies'] | //button[contains(text(),'Accept additional cookies')]");
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//a[text()='Hide cookie message'] | //button[contains(text(),'Hide cookie message')]"));
        private IWebElement signInGovUKOneLogin => _driver.WaitForElement(By.XPath("//label[@for='one']"));
        private IWebElement signInGovernmentGateway => _driver.WaitForElement(By.XPath("//label[@for='scp']"));
        private IWebElement signInContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue'][@id='continueReplacement']"));
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
            Thread.Sleep(1000);
            if (PageHeading.Text.Contains("How do you want to sign in?"))
            {
                if (signInMethod.Equals("OneLogIn"))
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", signInGovUKOneLogin);
                }
                else
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", signInGovernmentGateway);
                }
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", signInContinue);
                Thread.Sleep(1000);
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
            return PageHeading.Text.Contains("Sign in using Government Gateway");
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
            _driver.WaitForElement(SignInConfirmBy).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            return PageHeading.Text.Contains("You have signed out") || PageHeading.Text.Contains("Your Defra account");
        }
    }
}

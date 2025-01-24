using BoDi;
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
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//a[text()='Hide cookie message']"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public LogInPage(IObjectContainer container)
        {
            _objectContainer = container;
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
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", SignIn);
            Thread.Sleep(1000);
            if (_driver.FindElements(Accept_Cookies).Count > 0)
            {
                _driver.FindElement(Accept_Cookies).Click();
                Hide_Cookies.Click();
            }
            return _driver.WaitForElement(SignInConfirmBy).Enabled;
        }

        public void ClickCreateSignInDetailsLink() => CreateSignInDetails.Click();

        public void ClickSignedOut()
        {
            _driver.WaitForElement(SignInConfirmBy).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            return PageHeading.Text.Contains("You have signed out") || PageHeading.Text.Contains("Your Defra account");
        }
    }
}

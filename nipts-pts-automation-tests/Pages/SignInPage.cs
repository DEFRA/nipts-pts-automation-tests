using BoDi;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using SeleniumExtras.WaitHelpers;


namespace nipts_pts_automation_tests.Pages
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Sign in')]"));
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignOut => _driver.WaitForElement(By.XPath("//a[@href='/User/OSignOut']"));
        private IWebElement Accept_Cookies => _driver.WaitForElement(By.XPath("//button[text()='Accept analytics cookies']"));
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//a[text()='Hide cookie message']"));
        private IWebElement EnvPassword => _driver.WaitForElement(By.Id("EnteredPassword"));
        private IWebElement Continue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private By SignInConfirmBy => By.XPath("//a[@href='/User/OSignOut']");

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SignInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsSignedIn(string userId, string password)
        {
            UserId.SendKeys(userId);
            Password.SendKeys(password);
            _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            int count = _driver.WaitForElements(SignInConfirmBy).Count;
            return count > 0;
        }


        public void ClickSignIn()
        {
            SignIn.Click();
        }

        public void ClickSignedOut()
        {
            SignOut.Click();
        }

        public bool IsSignedOut()
        {
            return true;
        }

        public void EnterPassword()
        {
            if (PageHeading.Text.Contains("This is for testing use only"))
            {
                EnvPassword.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
                Continue.Click();
            }
        }

        public bool VerifySignOutTextInSelectedLanguage(string signOutText)
        {
            return SignOut.Text.Contains(signOutText);
        }

    }

}

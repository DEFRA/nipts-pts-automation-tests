using BoDi;
using OpenQA.Selenium;
using pets_com_automation_tests.Configuration;
using pets_com_automation_tests.HelperMethods;


namespace pets_com_automation_tests.Pages
{
    public class SignInPage : ISignInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//a[contains(text(),'Sign in')]"));
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignOut => _driver.WaitForElement(By.XPath("//a[text()='Sign out']"));
        private IWebElement Accept_Cookies => _driver.WaitForElement(By.XPath("//button[text()='Accept analytics cookies']"));
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//a[text()='Hide cookie message']"));
        private IWebElement EnvPassword => _driver.WaitForElement(By.Id("password"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public SignInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }


        public void ClickSignIn()
        {
            SignIn.Click();
        }

        public void ClickSignedOut()
        {
        }

        public bool IsSignedOut()
        {
            return true;
        }

        public void EnterPAssword()
        {

        }
    }

}

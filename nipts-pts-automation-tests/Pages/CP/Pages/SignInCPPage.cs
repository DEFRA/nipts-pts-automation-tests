using BoDi;
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
        private IWebElement btnSignIn => _driver.WaitForElement(By.XPath("//a[contains(text(),'Sign in')]"));
        private By signInConfirmBy => By.XPath("//h1[contains(@class,'govuk-heading-xl')]");
        private IWebElement UserId => _driver.FindElement(By.CssSelector("#user_id"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement SignIn => _driver.WaitForElement(By.Id("continue"));
        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        #endregion

        #region Methods
        public void ClickSignInButton()
        {
            btnSignIn.Click();
        }

        public void IsSignedIn(string userName, string password)
        {
            if (PageHeading.Text == "Sign in using Government Gateway")
            {
                UserId.SendKeys(userName);
                Password.SendKeys(password);
                _driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            }
        }

        public void EnterPassword()
        {
            Thread.Sleep(1000);
            if(PageHeading.Text == "This is a test environment")
            { 
                txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
                btnContinue.Click(); 
            }
        }
        #endregion

    }
}

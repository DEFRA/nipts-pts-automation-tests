using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.LandingPage
{
    public class LandingPage : ILandingPage
    {
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[contains(@class,'govuk-fieldset__heading')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-panel__title']"));

        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password'] | //input[@id='EnteredPassword']"));

        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private IWebElement AcceptAdditionalCookies => _driver.WaitForElement(By.XPath("//button[contains(text(),'Accept additional cookies')]"));
        private IWebElement HideCookieMessage => _driver.WaitForElement(By.XPath("//div[@id='govuk-cookie-banner-accepted'] //button[contains(text(),'Hide cookie message')]"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public LandingPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool IsPageLoaded(string pageName)
        {
            AcceptAdditionalCookies.Click();
            HideCookieMessage.Click();
            return PageHeading.Text.Contains(pageName);
        }

        public void EnterPassword()
        {
            txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
            btnContinue?.Click();
        }

        public void ClickContinueButton()
        {
            By continueBy = By.XPath("//button[contains(text(),'Continue')]");

            if (_driver.FindElements(continueBy).Count > 0)
            btnContinue.Click();
        }

        public bool VerifyNextPageIsLoaded(string pageName)
        {
            string text = PageHeading.Text;
            return PageHeading.Text.Contains(pageName);
        }

        #endregion Page Methods
    }
}
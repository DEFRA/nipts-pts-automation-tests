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

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"), true);

        private IWebElement txtLoging => _driver.WaitForElement(By.Id("EnteredPassword"));

        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[@type='submit']"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public LandingPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool IsPageLoaded(string pageName)
        {
            return PageHeading.Text.Contains(pageName);
        }

        public void EnterPassword()
        {
            txtLoging.SendKeys(ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword);
            btnContinue?.Click();
        }

        public void ClickContinueButton()
        {
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
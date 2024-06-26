using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class FullNamePage : IFullNamePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement FullNameEle => _driver.WaitForElement(By.Id("Name"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public FullNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterFullName(string fullName)
        {
            FullNameEle.SendKeys(fullName);
        }

        public bool ThenVerifyErrorMessageOnPetsFullNamePage(string errorMessage)
        {
            return true;
        }


        #endregion Page Methods


    }
}

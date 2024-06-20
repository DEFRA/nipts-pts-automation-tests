using BoDi;
using Defra.UI.Framework.Driver;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class PersonalDetailsPage : IPersonalDetailsPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PersonalDetailsPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyPersonalDetails(string user)
        {
            return true;
        }

        public void ClickOnContinue()
        {

        }

        public void ClickOnBack()
        {

        }

        public void SelectOptionOnPersonalDetailsPage(string option)
        { 
        
        }
        #endregion Page Methods



    }
}

using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Pages
{
    public class PetNamePage : IPetNamePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement PetNametxt => _driver.WaitForElement(By.Id("PetName"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterNameOfPet(string petName)
        {
            PetNametxt.Clear();
            PetNametxt.SendKeys(petName);
        }


        #endregion Page Methods

    }
}

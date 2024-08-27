using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class PetSexPage : IPetSexPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        public IWebElement FemaleRadiobtn => _driver.WaitForElementExists(By.CssSelector("#Female"));
        public IWebElement MaleRadiobtn => _driver.WaitForElementExists(By.CssSelector("#Male"));
        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//a[@href='#Gender']"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetSexPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public void SelectPetsSexOption(string sex)
        {
            if (sex.ToLower().Equals("male"))
            {
                MaleRadiobtn.Click();
            }
            else
            {
                FemaleRadiobtn.Click();
            }
        }
        public bool VerifyErrorMessageOnSelectSexOfPetPage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
        }

        #endregion Page Methods

    }
}

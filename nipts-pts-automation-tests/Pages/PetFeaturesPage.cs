using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages
{
    public class PetFeaturesPage : IPetFeaturesPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SignificantFeaturesRadioButtonYes => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureYes"));
        private IWebElement SignificantFeaturesRadioButtonNo => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureNo"));
        private IWebElement SignificantFeaturesTextBox => _driver.WaitForElementExists(By.ClassName("govuk-textarea"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetFeaturesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void SelectSignificantFeaturesOption(string hasSignificantFeatures)
        {
            if (hasSignificantFeatures.ToLower().Equals("yes") | hasSignificantFeatures.ToLower().Equals("oes"))
            {
                SignificantFeaturesRadioButtonYes.Click();
            }
            else if (hasSignificantFeatures.ToLower().Equals("no") | hasSignificantFeatures.ToLower().Equals("nac oes"))
            {
                SignificantFeaturesRadioButtonNo.Click();
            }
        }

        public void EnterSignificantFeature(string SignificantFeature)
        {
            SignificantFeaturesTextBox.SendKeys(SignificantFeature);
        }



        #endregion Page Methods

    }
}

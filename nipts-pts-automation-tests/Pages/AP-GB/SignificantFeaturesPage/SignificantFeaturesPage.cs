using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.SignificantFeaturesPage
{
    public class SignificantFeaturesPage : ISignificantFeaturesPage
    {
        private readonly IObjectContainer _objectContainer;

        public SignificantFeaturesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElementExists(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement SignificantFeaturesRadioButtonYes => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureYes"), true);
        private IWebElement SignificantFeaturesRadioButtonNo => _driver.WaitForElementExists(By.CssSelector("#HasUniqueFeatureNo"), true);
        private IWebElement SignificantFeaturesTextBox => _driver.WaitForElementExists(By.ClassName("govuk-textarea"));
        private IWebElement txtUniqueFeatures => _driver.WaitForElement(By.Id("featureinput"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public string SelectSignificantFeaturesOption(string hasSignificantFeatures)
        {
            var significantFeatures = "Black Mark on Shoulder";

            if (hasSignificantFeatures.ToLower().Equals("yes"))
            {
                SignificantFeaturesRadioButtonYes.Click();
                SignificantFeaturesTextBox.SendKeys(significantFeatures);
                return significantFeatures;
            }
            else if (hasSignificantFeatures.ToLower().Equals("no"))
            {
                SignificantFeaturesRadioButtonNo.Click();
                return "No";
            }

            return "No";
        }

        public void ClickContinueButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,1000)", "");
            By continueBy = By.XPath("//button[contains(text(),'Continue')]");
            if(_driver.FindElements(continueBy).Count > 0)
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", btnContinue);
            //btnContinue.Click();
        }

        public void EnterSignificantFeatures(string significantFeatures)
        {
            SignificantFeaturesTextBox.Clear();
            SignificantFeaturesTextBox.SendKeys(significantFeatures);
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
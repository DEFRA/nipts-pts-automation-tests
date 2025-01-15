using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class SearchResultsPassFailPage : ISearchResultsPassFail
    {
        private readonly IObjectContainer _objectContainer;

        public SearchResultsPassFailPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        private IWebElement PTDNumberEle => _driver.WaitForElement(By.XPath("(//dl[contains(@class,'govuk-summary-list')]/div[1]/dd)[1]"));

        private IWebElement SigFeaturesEle => _driver.WaitForElementExists(By.XPath("(//dl[contains(@class,'govuk-summary-list')]/div[7]/dd)[1]"));
        private IWebElement PetClrEle => _driver.WaitForElementExists(By.XPath("(//dl[contains(@class,'govuk-summary-list')]/div[6]/dd)[1]"));

        #endregion

        #region Methods
        public bool VerifyPTDNoOnSearchResultsPassFailPage(string finalPTD)
        {
            return PTDNumberEle.Text.Equals(finalPTD);
        }

        public bool VerifySignificantFeaturesOption(string sigFeatures)
        {
            return SigFeaturesEle.Text.Contains(sigFeatures);
        }

        public bool VerifyOtherClrOption(string otherClr)
        {

            return PetClrEle.Text.Contains(otherClr);
        }
        #endregion

    }
}

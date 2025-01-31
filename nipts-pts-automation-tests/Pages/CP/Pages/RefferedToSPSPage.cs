using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class RefferedToSPSPage : IRefferedToSPSPage
    {
        private readonly IObjectContainer _objectContainer;

        public RefferedToSPSPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IReadOnlyCollection<IWebElement> recordCount => _driver.WaitForElements(By.XPath("//tbody[@class='govuk-table__body']//tr[contains(@class,'govuk-table__row')]"));
        #endregion

        #region Methods

        public void VerifyReferredToSPSDetails()
        {

        }

        public void VerifySPSOutcome(string outcome)
        {

        }

        public void ClickOnPTDNumberOfTheApplication(string ptdNumber)
        {
            var clickPTD = _driver.WaitForElement(By.XPath($"//button[contains(text(),'{ptdNumber}')]"));
            // clickPTD.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", clickPTD);
        }

        public void ClickOnPage(string pageNumber)
        {
            string pageXpath = $"//a[contains(text(), '{pageNumber}')]";
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", _driver.WaitForElement(By.XPath(pageXpath)));
            _driver.WaitForElement(By.XPath(pageXpath)).Click();
        }

        public bool VerifyReferredToSPSRecordCount(int count)
        {
            if (recordCount.Count == count)
                return true;
            else
                return false;
        }

        #endregion

    }
}

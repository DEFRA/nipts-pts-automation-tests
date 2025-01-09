using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class GBCheckReportPage : IGBCheckReportPage
    {
        private readonly IObjectContainer _objectContainer;

        public GBCheckReportPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement clickSPSConduct => _driver.WaitForElement(By.XPath("//button[contains(text(),'Conduct an SPS check')]"));
        #endregion

        #region Methods

        public void VerifyGBCheckReport()
        { 
        
        }

        public void ClickOnConductAnSPSCheck()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", clickSPSConduct);
        }

        #endregion

    }
}

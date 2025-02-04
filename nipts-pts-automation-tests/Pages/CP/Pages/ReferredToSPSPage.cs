using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class ReferredToSPSPage : IReferredToSPSPage
    {
        private readonly IObjectContainer _objectContainer;

        public ReferredToSPSPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IReadOnlyCollection<IWebElement> recordCount => _driver.WaitForElements(By.XPath("//tbody[@class='govuk-table__body']//tr[contains(@class,'govuk-table__row')]"));
        private IWebElement SPSOutcomeEle => _driver.WaitForElement(By.XPath("//tr[contains(@class,'govuk-table__row')]/td[4]"));
        private IWebElement PTDNoEle => _driver.WaitForElement(By.XPath("//button[contains(@type,'submit')]"));
        private IWebElement PetTypeEle => _driver.WaitForElement(By.XPath("//tr[contains(@class,'govuk-table__row')]/td[1]"));
        private IWebElement MichrochipNoEle => _driver.WaitForElement(By.XPath("//tr[contains(@class,'govuk-table__row')]/td[2]"));
        private IWebElement headerDepartureTime => _driver.WaitForElement(By.XPath("//header[@class='pts-location-bar']//p"));
        private IWebElement spsDetails => _driver.WaitForElement(By.XPath("//caption[contains(@class, 'govuk-table__caption govuk-table__caption--m')]"));
        #endregion

        #region Methods

        public bool VerifyPetDocumentDetailsOnReferredToSPSPage(string ptdNumberNew, string petType, string michrochipNo)
        {
            return PTDNoEle.Text.Contains(ptdNumberNew) && PetTypeEle.Text.Contains(petType) && MichrochipNoEle.Text.Contains(michrochipNo);
        }

        public bool VerifyDepartureDetailsOnReferredToSPSPage()
        {
            bool status = true;
            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7, 29).Trim();
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                if (ConfigSetup.BaseConfiguration.TestConfiguration.BSBrowserVersion == "16.5")
                {
                    departureDate = headerTime.Substring(60, 10);
                    departureTime = headerTime.Substring(71, 5);
                }
                else
                {
                    departureDate = headerTime.Substring(53, 10);
                    departureTime = headerTime.Substring(64, 5);
                }
            }
            else if (route.Contains("Cairnryan to Larne (P&O)"))
            {
                departureDate = headerTime.Substring(48, 10);
                departureTime = headerTime.Substring(59, 5);
            }
            else if (route.Contains("Loch Ryan to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(52, 10);
                departureTime = headerTime.Substring(63, 5);
            }

            if (spsDetails.Text.Contains(route) && spsDetails.Text.Contains(departureDate) && spsDetails.Text.Contains(departureTime))
                status = true;
            else
                status = false;

            return status;
        }

        public bool VerifySPSOutcome(string outcome)
        {
            return SPSOutcomeEle.Text.Contains(outcome);
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

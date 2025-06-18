using Reqnroll.BoDi;
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
        private IWebElement headerDepartureTime => _driver.WaitForElement(By.XPath("//div[@class='pts-location-bar']//p"));
        private IWebElement spsDetails => _driver.WaitForElement(By.XPath("//caption[contains(@class, 'govuk-table__caption govuk-table__caption--m')]"));
        private IReadOnlyCollection<IWebElement> PTDRefNumbers => _driver.WaitForElements(By.XPath("//button[contains(@data-identifier,'referred')]"));
        private IWebElement PTDRefNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Application reference number')]/following-sibling::dd | //dt[contains(text(),'PTD number')]/following-sibling::dd"));
        List<string> PTDRefCollection = new List<string>();
        #endregion

        #region Methods

        public bool VerifyPetDocumentDetailsOnReferredToSPSPage(string ptdNumberNew, string petType, string michrochipNo)
        {
            string ptdNumberCheck = $"//button[contains(text(),'{ptdNumberNew}')]";
            string PetTypeEleCheck = $"//button[contains(text(),'{ptdNumberNew}')]/../../..//td[1]";
            string MichrochipNoEleCheck = $"//button[contains(text(),'{ptdNumberNew}')]/../../..//td[2]";
            return _driver.FindElement(By.XPath(ptdNumberCheck)).Text.Contains(ptdNumberNew) && _driver.FindElement(By.XPath(PetTypeEleCheck)).Text.Contains(petType) && _driver.FindElement(By.XPath(MichrochipNoEleCheck)).Text.Contains(michrochipNo);
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
            string clickPTD = $"//button[contains(text(),'{ptdNumber}')]";
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _driver.FindElement(By.XPath(clickPTD)));
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

        public void ClickOnNextPage(string nextPage)
        {
            string pageXpath = $"//span[contains(text(), '{nextPage}')]/..";
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", _driver.WaitForElement(By.XPath(pageXpath)));
            _driver.WaitForElement(By.XPath(pageXpath)).Click();
        }

        public void GetPTDReferenceAndAddInCollection()
        {
            PTDRefCollection.Add(PTDRefNumber.Text.Trim());
        }

        public void ArrangePTDRefNumberInAscendingOrder()
        {
            PTDRefCollection.Sort();
        }

        public bool VerifyAscendingOderOfPTDReference()
        {
            var PTDRefNumberUI = new List<string>();
            for (int i = 0; i < PTDRefNumbers.Count; i++)
            {
                var AppPTDNumber = PTDRefNumbers.ElementAt(i).Text.Trim();
                if (AppPTDNumber.Length > 20)
                {
                    AppPTDNumber = AppPTDNumber.Substring(0, 13);
                }
                else
                {
                    AppPTDNumber = AppPTDNumber.Substring(0, 8);
                }
                PTDRefNumberUI.Add(AppPTDNumber.Trim());
            }

            bool status = false;

            for (int i = 0; i < PTDRefNumberUI.Count; i++)
            {
                for (int j = 0; j < PTDRefCollection.Count; j++)
                {
                    if (i == j)
                    {
                        if (PTDRefNumberUI[i].Equals(PTDRefCollection[j]))
                        {
                            status = true;
                            Console.WriteLine($"Match found: {PTDRefNumberUI[i]}");
                            Console.WriteLine($"Match found: {PTDRefCollection[j]}");
                        }
                        else
                        {
                            Console.WriteLine($"Match not found: {PTDRefNumberUI[i]}");
                            Console.WriteLine($"Match not found: {PTDRefCollection[j]}");
                            status = false;
                            break;
                        }
                    }
                    if (status == false)
                        break;
                }
            }
            return status;
        }
        #endregion

    }
}

using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class RefferedToSPSPage : IRefferedToSPSPage
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public RefferedToSPSPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IReadOnlyCollection<IWebElement> recordCount => _driver.WaitForElements(By.XPath("//tbody[@class='govuk-table__body']//tr[contains(@class,'govuk-table__row')]"));
        private IReadOnlyCollection<IWebElement> PTDRefNumbers => _driver.WaitForElements(By.XPath("//button[contains(@data-identifier,'referred')]"));
        private IWebElement PTDRefNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Application reference number')]/following-sibling::dd | //dt[contains(text(),'PTD number')]/following-sibling::dd"));
        List<string> PTDRefCollection = new List<string>();
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

        public void ClickOnNextPage(string nextPage)
        {
            string pageXpath = $"//a//span[contains(text(), '{nextPage}')]";
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
            //foreach (var item in PTDRefCollection.Where(i => PTDRefCollection.Contains(i)))
            //{
            //    Console.WriteLine($"Match found: {item}");
            //    status = true;
            //}
            return status;
        }
            #endregion
    }
}

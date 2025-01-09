using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class WelcomePage : IWelcomePage
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        static string departTime;
        public WelcomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(text(),'Checks')]"));
        private IWebElement submittedMessage => _driver.WaitForElement(By.XPath("//div[@class='ons-panel__body']"));
        private IWebElement iconSearch => _driver.WaitForElement(By.XPath("//a[@href='/checker/document-search']//*[name()='svg']"));
        private IWebElement iconHome => _driver.WaitForElement(By.XPath("//span[normalize-space()='Home']"));
        private IWebElement lnkHeadersChange => _driver.WaitForElement(By.XPath("//a[normalize-space()='Change']"));
        private IReadOnlyCollection<IWebElement> viewLinks => _driver.WaitForElements(By.XPath("//button[contains(text(),'View')]"));
        private IWebElement headerDepartureTime => _driver.WaitForElement(By.XPath("//header[@class='pts-location-bar']//p"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Checks");
        }

        public void FooterSearchButton()
        {
            iconSearch.Click();
        }

        public void HeadersChangeLink()
        {
            lnkHeadersChange.Click();
        }

        public void FooterHomeIcon()
        {
            iconHome.Click();
        }

        public void clickOnView()
        {
            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7,29).Trim();
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(53, 10);
                departureTime = headerTime.Substring(64, 5);
                departTime = headerTime.Substring(64, 5);
            }
            else if (route.Contains("Cairnryan to Larne (P&O)"))
            {
                departureDate = headerTime.Substring(48, 10);
                departureTime = headerTime.Substring(59, 5);
                departTime = headerTime.Substring(59, 5);
            }
            else if (route.Contains("Loch Ryan to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(52, 10);
                departureTime = headerTime.Substring(63, 5);
                departTime = headerTime.Substring(63, 5);
            }
            string matchingTime = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{departureTime}')]/..//button";

            if (_driver.FindElements(By.XPath(matchingTime)).Count > 0)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", _driver.FindElement(By.XPath(matchingTime)));
                _driver.FindElement(By.XPath(matchingTime)).Click();
            }
       }

        public void clickOnViewWithSPSUser(string departureRoute)
        {
            var GBDepartureTime = departTime;
            string headerTime = headerDepartureTime.Text.Trim();
            string departureDate = "";
            if (departureRoute.Contains("Birkenhead to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(53, 10);
            }
            else if (departureRoute.Contains("Cairnryan to Larne (P&O)"))
            {
                departureDate = headerTime.Substring(48, 10);
            }
            else if (departureRoute.Contains("Loch Ryan to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(52, 10);
            }

            string matchingTime = $"//input[contains(@value,'{departureRoute}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{GBDepartureTime}')]/..//button";

            if (_driver.FindElements(By.XPath(matchingTime)).Count > 0)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", _driver.FindElement(By.XPath(matchingTime)));
                _driver.FindElement(By.XPath(matchingTime)).Click();
            }
        }

        public bool DepartureDateTimeCheck()
        {
            bool status = true;
            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7,29).Trim();
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(53, 10);
                departureTime = headerTime.Substring(64, 5);
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

            string matchingTime = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{departureTime}')]/..//button";

            if(_driver.FindElements(By.XPath(matchingTime)).Count > 0)
                status = false;
            else
                status = true;

            return status;
        }

        public bool DepartureDateTimeCheckForFlight()
        {
            bool status = true;
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(15, 10).Trim();
            string departureDate = headerTime.Substring(38, 10);
            string departureTime = headerTime.Substring(49, 5);

            string matchingTime = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{departureTime}')]/..//button";

            if (_driver.FindElements(By.XPath(matchingTime)).Count > 0)
                status = false;
            else
                status = true;

            return status;
        }

        public bool VerifySubmiitedMessage()
        {
            return submittedMessage.Text.Contains("Information has been successfully submitted");
        }

        #endregion
    }
}

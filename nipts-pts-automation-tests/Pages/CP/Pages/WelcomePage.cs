using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using System.Globalization;
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
        private IWebElement pageHeading => _driver.WaitForElementExists(By.XPath("//h1[contains(text(),'Checks')]"));
        private IWebElement submittedMessage => _driver.WaitForElement(By.XPath("//div[@class='ons-panel__body']"));
        private IWebElement iconSearch => _driver.WaitForElement(By.XPath("//a[@href='/checker/document-search']//*[name()='svg']"));
        private IWebElement iconHome => _driver.WaitForElement(By.XPath("//span[normalize-space()='Home']"));
        private IWebElement lnkHeadersChange => _driver.WaitForElement(By.XPath("//a[normalize-space()='Change']"));
        private IReadOnlyCollection<IWebElement> viewLinks => _driver.WaitForElements(By.XPath("//button[contains(text(),'View')]"));
        private IWebElement headerDepartureTime => _driver.WaitForElement(By.XPath("//header[@class='pts-location-bar']//p"));
        private IReadOnlyCollection<IWebElement> DepartureDateTime => _driver.WaitForElements(By.XPath("//h2//b[contains(text(),'Departure:')]/.."));
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
            string route = headerTime.Substring(7, 29).Trim();
            Thread.Sleep(1000);
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                if (ConfigSetup.BaseConfiguration.TestConfiguration.BSBrowserVersion == "16.5")
                {
                    departureDate = headerTime.Substring(60, 10);
                    departureTime = headerTime.Substring(71, 5);
                    departTime = headerTime.Substring(71, 5);
                }
                else
                {
                    departureDate = headerTime.Substring(53, 10);
                    departureTime = headerTime.Substring(64, 5);
                    departTime = headerTime.Substring(64, 5);
                }
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
            Thread.Sleep(1000);
            if (departureRoute.Contains("Birkenhead to Belfast (Stena)"))
            {
                if (ConfigSetup.BaseConfiguration.TestConfiguration.BSBrowserVersion == "16.5")
                {
                    departureDate = headerTime.Substring(60, 10);
                }
                else
                {
                    departureDate = headerTime.Substring(53, 10);
                }
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
                Console.WriteLine($"Matching count: {_driver.WaitForElements(By.XPath(matchingTime)).Count}");
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", _driver.FindElement(By.XPath(matchingTime)));
                //_driver.FindElement(By.XPath(matchingTime)).Click();
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _driver.WaitForElementExists(By.XPath(matchingTime)));
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

        public bool VerifyEntriesOnCheckerPage()
        {
            CultureInfo enGB = new CultureInfo("en-GB");
            DateTime Hour24LaterDateTime = DateTime.Now.AddDays(1);
            DateTime Hours48BeforeDateTime = DateTime.Now.AddDays(-2);
            bool status = false;
            for (int i = 0; i < DepartureDateTime.Count; i++)
            {
                var dateTime = DepartureDateTime.ElementAt(i).Text.Substring(11,16).Trim();
                DateTime dateTimeRecord = DateTime.ParseExact(dateTime, "g", enGB);
                if (dateTimeRecord > Hour24LaterDateTime && dateTimeRecord < Hours48BeforeDateTime)
                {
                    status = false;
                    break;
                }
                else
                    status = true;   
            }
            return status;
        }

        public bool getPassCount(string passCount)
        {
            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7, 29).Trim();
            Thread.Sleep(1000);
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                if (ConfigSetup.BaseConfiguration.TestConfiguration.BSBrowserVersion == "16.5")
                {
                    departureDate = headerTime.Substring(60, 10);
                    departureTime = headerTime.Substring(71, 5);
                    departTime = headerTime.Substring(71, 5);
                }
                else
                {
                    departureDate = headerTime.Substring(53, 10);
                    departureTime = headerTime.Substring(64, 5);
                    departTime = headerTime.Substring(64, 5);
                }
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
            string matchingRecord = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{departureTime}')]/../../../preceding-sibling::div//dd";

            string UIPassCount = null;
            if (_driver.FindElements(By.XPath(matchingRecord)).Count > 0)
            {
                UIPassCount = _driver.FindElement(By.XPath(matchingRecord)).Text;
            }
            
            if (UIPassCount.Equals(passCount))
                return true;
            else
                return false;
        }
        public bool VerifySelectedFerryRouteOnWelcomePage(string FerryRoute)
        {
            bool status = false;
            IList<IWebElement> FerryRouteEle = _driver.FindElements(By.XPath("//p[@class='govuk-body  govuk-!-margin-bottom-1']"));
            foreach (IWebElement ele in FerryRouteEle)
            {
                if (ele.Text.Contains(FerryRoute))
                {
                    status = true;
                    break;
                }
            }
            return status;
        }

        public bool VerifyNoViewLinkIfNoReferredToSPS()
        {
            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7, 29).Trim();
            Thread.Sleep(1000);
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                if (ConfigSetup.BaseConfiguration.TestConfiguration.BSBrowserVersion == "16.5")
                {
                    departureDate = headerTime.Substring(60, 10);
                    departureTime = headerTime.Substring(71, 5);
                    departTime = headerTime.Substring(71, 5);
                }
                else
                {
                    departureDate = headerTime.Substring(53, 10);
                    departureTime = headerTime.Substring(64, 5);
                    departTime = headerTime.Substring(64, 5);
                }
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
            string FailCount = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{departureTime}')]/../../..//dd[1]";
            string ViewLink = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{departureTime}')]/../../..//dd[2]//button";

            string GetFailCount = null;
            if (_driver.FindElements(By.XPath(FailCount)).Count > 0)
            {
                GetFailCount = _driver.FindElement(By.XPath(FailCount)).Text;
            }

            bool ViewLinkStatus = true;

            if (GetFailCount.Equals("0"))
                if(_driver.FindElements(By.XPath(ViewLink)).Count > 0)
                    ViewLinkStatus = false;

            return ViewLinkStatus;
        }

        public bool VerifyNoViewLinkIfNoReferredToSPSWithSPSUser()
        {
            var GBDepartureTime = departTime;
            string departureDate = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7, 29).Trim();
            Thread.Sleep(1000);
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                if (ConfigSetup.BaseConfiguration.TestConfiguration.BSBrowserVersion == "16.5")
                {
                    departureDate = headerTime.Substring(60, 10);
                }
                else
                {
                    departureDate = headerTime.Substring(53, 10);
                }
            }
            else if (route.Contains("Cairnryan to Larne (P&O)"))
            {
                departureDate = headerTime.Substring(48, 10);
            }
            else if (route.Contains("Loch Ryan to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(52, 10);
            }
            string FailCount = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{GBDepartureTime}')]/../../..//dd[1]";
            string ViewLink = $"//input[contains(@value,'{route}')]/following-sibling::input[contains(@value,'{departureDate}')]/following-sibling::input[contains(@value,'{GBDepartureTime}')]/../../..//dd[2]//button";

            string GetFailCount = null;
            if (_driver.FindElements(By.XPath(FailCount)).Count > 0)
            {
                GetFailCount = _driver.FindElement(By.XPath(FailCount)).Text;
            }

            bool ViewLinkStatus = true;

            if (GetFailCount.Equals("0"))
                if (_driver.FindElements(By.XPath(ViewLink)).Count > 0)
                    ViewLinkStatus = false;

            return ViewLinkStatus;
        }

        #endregion
    }
}

using BoDi;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class RouteCheckingPage : IRouteCheckingPage
    {
        private readonly IObjectContainer _objectContainer;

        public RouteCheckingPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement rdoFerry => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption']"));
        private IWebElement rdoFlight => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption-2']"));
        private IWebElement rdoBirkenhead => _driver.WaitForElement(By.XPath("//label[normalize-space()='Birkenhead to Belfast (Stena)']"));
        private IWebElement rdoCairnryan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Cairnryan to Larne (P&O)']"));
        private IWebElement rdoLochRyan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Loch Ryan to Belfast (Stena)']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private IWebElement hourDropdown => _driver.WaitForElement(By.CssSelector("#sailingHour"));
        private IWebElement minuteDropdown => _driver.WaitForElement(By.CssSelector("#sailingMinutes"));
        private IWebElement txtBoxFlighterNumber => _driver.WaitForElement(By.XPath("//input[@id='routeFlight']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement txtScheduleDepartureDay => _driver.WaitForElement(By.Id("departureDateDay"));
        private IWebElement txtScheduleDepartureMonth => _driver.WaitForElement(By.Id("departureDateMonth"));
        private IWebElement txtScheduleDepartureYear => _driver.WaitForElement(By.Id("departureDateYear"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("What route are you checking?");
        }

        public void SelectTransportationOption(string radioButtonValue)
        {
            if (radioButtonValue == "Ferry")
            {

                //if (!rdoFerry.Selected)
                //{
                    //rdoFerry.Click();
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                    jsExecutor.ExecuteScript("arguments[0].click();", rdoFerry);
                //}
            }
            else if (radioButtonValue == "Flight")
            {

                if (!rdoFlight.Selected)
                {
                    //rdoFlight.Click();
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                    jsExecutor.ExecuteScript("arguments[0].click();", rdoFlight);
                }
            }
        }

        public void SelectFerryRouteOption(string routeOption)
        {
            switch (routeOption)
            {
                case "Birkenhead to Belfast (Stena)":
                    rdoBirkenhead.Click();
                    break;
                case "Cairnryan to Larne (P&O)":
                    rdoCairnryan.Click();
                    break;
                case "Loch Ryan to Belfast (Stena)":
                    rdoLochRyan.Click();
                    break;
            }
        }

        public string SelectDropDownDepartureTime()
        {
            var hour = DateTime.Now.ToString("HH");
            var minutes = DateTime.Now.ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourDropdown);

            SelectElement selectHour = new SelectElement(hourDropdown);
            selectHour.SelectByValue(hour);
            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue(minutes);

            return departureTime;
        }

        public void SelectDropDownDepartureTimeWithSPS()
        {
            var hour = DateTime.Now.ToString("HH");
            var minutes = DateTime.Now.ToString("mm");

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourDropdown);
            SelectElement selectHour = new SelectElement(hourDropdown);
            selectHour.SelectByValue(hour);
            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue(minutes);
        }

        public void SelectSaveAndContinue()
        {
            btnSaveAndContinue.Click();
        }

        public void SelectFlightNumber(string routeFlight)
        {
            txtBoxFlighterNumber.Clear();
            txtBoxFlighterNumber.SendKeys(routeFlight);
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

        public void SelectScheduledDepartureDate(string departureDay, string departureMonth, string departureYear)
        {
            txtScheduleDepartureDay.Clear();
            txtScheduleDepartureDay.SendKeys(departureDay);
            txtScheduleDepartureMonth.Clear();
            txtScheduleDepartureMonth.SendKeys(departureMonth);
            txtScheduleDepartureYear.Clear();
            txtScheduleDepartureYear.SendKeys(departureYear);
        }

        public void SelectDropDownDepartureTimeMinuteOnly()
        {

            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue("30");
        }

        public string SelectfutureDropDownDepartureTime()
        {
            var hour = DateTime.Now.AddHours(1).ToString("HH");
            var minutes = DateTime.Now.ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";

            SelectElement selectHour = new SelectElement(hourDropdown);
            selectHour.SelectByValue(hour);
            SelectElement selectMinute = new SelectElement(minuteDropdown);
            selectMinute.SelectByValue(minutes);

            return departureTime;
        }

        public void EnterDateMonthYear(DateTime dateTime)
        {
            var day = dateTime.ToString("dd");
            var month = dateTime.ToString("MM");
            var year = dateTime.ToString("yyyy");

            txtScheduleDepartureDay.Clear();
            txtScheduleDepartureMonth.Clear();
            txtScheduleDepartureYear.Clear();

            txtScheduleDepartureDay.SendKeys(day);
            txtScheduleDepartureMonth.SendKeys(month);
            txtScheduleDepartureYear.SendKeys(year);
        }


        #endregion

    }
}

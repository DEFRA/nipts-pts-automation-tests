using Reqnroll.BoDi;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;

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
        private IWebElement HeaderTextEle => _driver.WaitForElement(By.XPath("//header[@class='govuk-width-container pts-header-title']//div[@class='govuk-grid-column-two-thirds']//div[contains(@class,'govuk-heading-l')]"));
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement rdoFerry => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption']"));
        private IWebElement rdoFlight => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption-2']"));
        private IWebElement rdoBirkenhead => _driver.WaitForElement(By.XPath("//label[normalize-space()='Birkenhead to Belfast (Stena)']"));
        private IWebElement rdoCairnryan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Cairnryan to Larne (P&O)']"));
        private IWebElement rdoLochRyan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Loch Ryan to Belfast (Stena)']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private By hourEle => By.XPath("//label[@for='sailingHour']");
        private IWebElement hourInput => _driver.WaitForElement(By.XPath("//input[@id='sailingHour']"));
        private By minuteEle => By.XPath("//label[@for='sailingMinutes']");
        private IWebElement minuteInput => _driver.WaitForElement(By.XPath("//input[@id='sailingMinutes']"));
        private IWebElement txtBoxFlighterNumber => _driver.WaitForElement(By.XPath("//input[@id='routeFlight']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement txtScheduleDepartureDay => _driver.WaitForElement(By.Id("departureDateDay"));
        private IWebElement txtScheduleDepartureMonth => _driver.WaitForElement(By.Id("departureDateMonth"));
        private IWebElement txtScheduleDepartureYear => _driver.WaitForElement(By.Id("departureDateYear"));
        private IWebElement txtFlightFilterMsg1 => _driver.WaitForElement(By.XPath("(//ul[contains(@class,'govuk-list govuk-list--bullet')]//li)[1]"));
        private IWebElement txtFlightFilterMsg2 => _driver.WaitForElement(By.XPath("(//ul[contains(@class,'govuk-list govuk-list--bullet')]//li)[2]"));
        private IWebElement txtFlightFilterMsg3 => _driver.WaitForElement(By.XPath("(//ul[contains(@class,'govuk-list govuk-list--bullet')]//li)[3]"));
        private IWebElement txtFlightFilterHeaderMsg => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-grid-column-two-thirds')]//p"));
        private By ScheduledDepartureHeading => By.XPath("//fieldset[@aria-describedby='sailingHourHint']//h2[contains(text(),'Scheduled departure time')]");
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

                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                jsExecutor.ExecuteScript("arguments[0].click();", rdoFerry);
            }
            else if (radioButtonValue == "Flight")
            {

                if (!rdoFlight.Selected)
                {
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
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            if (_driver.FindElements(hourEle).Count >0 || _driver.FindElements(minuteEle).Count >0)
            {
                //SelectElement selectHour = new SelectElement(hourInput);
                hourInput.SendKeys(hour);
                //SelectElement selectMinute = new SelectElement(minuteInput);
                minuteInput.SendKeys(minutes);
            }
            return departureTime;
        }

        public void SelectDropDownDepartureTimeWithSPS()
        {
            var hour = DateTime.Now.ToString("HH");
            var minutes = DateTime.Now.ToString("mm");

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);
            //SelectElement selectHour = new SelectElement(hourInput);
            hourInput.SendKeys(hour);
            //SelectElement selectMinute = new SelectElement(minuteInput);
            minuteInput.SendKeys(minutes);
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

            SelectElement selectMinute = new SelectElement(minuteInput);
            selectMinute.SelectByValue("30");
        }

        public string SelectfutureDropDownDepartureTime()
        {
            var hour = DateTime.Now.AddHours(1).ToString("HH");
            var minutes = DateTime.Now.ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";

            //SelectElement selectHour = new SelectElement(hourInput);
            hourInput.SendKeys(hour);
            //SelectElement selectMinute = new SelectElement(minuteInput);
            minuteInput.SendKeys(minutes);

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

        public string SelectDropDownDepartureTimeJustOneMinuteLaterThanCurrent()
        {
            var hour = DateTime.Now.ToString("HH");
            var minutes = DateTime.Now.AddMinutes(1).ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            //SelectElement selectHour = new SelectElement(hourInput);
            hourInput.SendKeys(hour);
            //SelectElement selectMinute = new SelectElement(minuteInput);
            minuteInput.SendKeys(minutes);

            return departureTime;
        }

        public string SelectDropDownDepartureTimeJustOneMinuteBeforeThanCurrent()
        {
            var hour = DateTime.Now.ToString("HH");
            var minutes = DateTime.Now.AddMinutes(-1).ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            //SelectElement selectHour = new SelectElement(hourInput);
            hourInput.SendKeys(hour);
            //SelectElement selectMinute = new SelectElement(minuteInput);
            minuteInput.SendKeys(minutes);

            return departureTime;
        }
        public bool VerifyFilterFlightMsg(string FlightMsgPTD, string FlightMsgAppno, string FlightMsgMichrochipNo)
        {
            return txtFlightFilterMsg1.Text.Contains(FlightMsgPTD) && txtFlightFilterMsg2.Text.Contains(FlightMsgAppno) && txtFlightFilterMsg3.Text.Contains(FlightMsgMichrochipNo);
        }

        public bool VerifyFilterFlightHeaderMsg(string FlightHeaderMsg)
        {
            return txtFlightFilterHeaderMsg.Text.Contains(FlightHeaderMsg);
        }

        public bool VerifyTheHeaderText(string headerText)
        {
            return HeaderTextEle.Text.Contains(headerText);
        }

        public bool VerifyScheduledDepartureHeading()
        {
            if(_driver.FindElements(ScheduledDepartureHeading).Count > 0)
                return true;
            else
                return false;
        }
        #endregion

    }
}

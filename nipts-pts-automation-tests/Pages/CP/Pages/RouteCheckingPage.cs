using Reqnroll;
using Reqnroll.BoDi;
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
        private ScenarioContext _scenarioContext => _objectContainer.Resolve<ScenarioContext>();
        private IWebElement HeaderTextEle => _driver.WaitForElement(By.XPath("//header[@class='govuk-width-container pts-header-title']//div[@class='govuk-grid-column-two-thirds']//div[contains(@class,'govuk-heading-l')]"));
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement rdoFerry => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption']"));
        private IWebElement rdoFlight => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='routeOption-2']"));
        private IWebElement rdoBirkenhead => _driver.WaitForElement(By.XPath("//label[normalize-space()='Birkenhead to Belfast (Stena)']"));
        private IWebElement rdoCairnryan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Cairnryan to Larne (P&O)']"));
        private IWebElement rdoLochRyan => _driver.WaitForElement(By.XPath("//label[normalize-space()='Loch Ryan to Belfast (Stena)']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save and continue']"));
        private By hourEle => By.XPath("//label[@for='sailingHour'][contains(text(),'Hours')]");
        private IWebElement hourInput => _driver.WaitForElement(By.XPath("//input[@id='sailingHour']"));
        private By minuteEle => By.XPath("//label[@for='sailingMinutes'][contains(text(),'Minutes')]");
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
        private IWebElement sailingHourHintText => _driver.WaitForElement(By.XPath("//div[@id='sailingHourHint'][contains(@class,'govuk-hint')]"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return _driver.IsHeadingLoaded("What route are you checking?");
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
            // Persist the exact sailing time so the SPS user can open the same sailing the pet was
            // referred under - re-deriving it from DateTime.Now later can cross a minute boundary and
            // select a different sailing, so the referral never appears in the SPS user's list.
            _scenarioContext["SailingHour"] = hour;
            _scenarioContext["SailingMinutes"] = minutes;
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            if (_driver.FindElements(hourEle).Count >0 || _driver.FindElements(minuteEle).Count >0)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);
            }
            return departureTime;
        }

        public void SelectDropDownDepartureTimeWithSPS()
        {
            // Reuse the GB user's sailing time so the SPS user opens the exact sailing the pet was
            // referred under; fall back to now only if the GB step didn't record it.
            var hour = _scenarioContext.TryGetValue("SailingHour", out var h) && h is string hs && hs.Length > 0
                ? hs : DateTime.Now.ToString("HH");
            var minutes = _scenarioContext.TryGetValue("SailingMinutes", out var m) && m is string ms && ms.Length > 0
                ? ms : DateTime.Now.ToString("mm");

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);
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

        public bool VerifyHintText(string hintText)
        { 
            return sailingHourHintText.Text.Contains(hintText);
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
            minuteInput.SendKeys("30");
        }

        public string SelectfutureDropDownDepartureTime()
        {
            var hour = DateTime.Now.AddHours(1).ToString("HH");
            var minutes = DateTime.Now.AddMinutes(3).ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);

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
            // Derive hour and minute from ONE timestamp so the offset is a steady +30 min. The old code
            // took the hour from Now+1h but the minute from Now+4min, so when the current minute was >=56
            // the inside-48h margin collapsed to ~4 min and the "just within 48 hours" scenarios flaked
            // whenever the agent/server clocks differed by more than that (e.g. the 09:58 run).
            var departure = DateTime.Now.AddMinutes(30);
            var hour = departure.ToString("HH");
            var minutes = departure.ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);

            return departureTime;
        }

        public string SelectDropDownDepartureTimeJustOneMinuteBeforeThanCurrent()
        {
            var hour = DateTime.Now.ToString("HH");
            var minutes = DateTime.Now.AddMinutes(-1).ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);

            return departureTime;
        }

        // Enters a scheduled departure ~44h in the past - deriving BOTH the date and the time from ONE
        // timestamp so they can never disagree. The positive "within 48 hours" scenarios used to enter
        // date = now-2 days and time = now+30min separately, leaving the departure only ~30 min inside
        // the 48h window (and able to wrap across midnight); a small agent/app clock difference
        // (e.g. UTC vs BST) then tipped it past 48h so the app rejected it and the flow never reached
        // the Welcome page. 44h ago is always >24h and <48h, with hours of margin either side.
        public string EnterScheduledDepartureWithinPast48Hours()
        {
            var departure = DateTime.Now.AddHours(-44);
            EnterDateMonthYear(departure);

            var hour = departure.ToString("HH");
            var minutes = departure.ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);

            return departureTime;
        }

        // Enters a scheduled departure ~28h in the future - date and time from ONE timestamp so they
        // can never disagree. The negative "exceeds 24 hours" scenarios used to enter date = now+1 day
        // and time = now+30min separately, leaving the departure only ~30 min BEYOND the +24h window
        // (and able to wrap across midnight); a small agent/app clock difference then tipped it back
        // inside the window so the app accepted it, the error never showed and the assertion timed out
        // on "Element is not visible". 28h ahead is always >24h, with hours of margin.
        public string EnterScheduledDepartureBeyondNext24Hours()
        {
            var departure = DateTime.Now.AddHours(28);
            EnterDateMonthYear(departure);

            var hour = departure.ToString("HH");
            var minutes = departure.ToString("mm");
            string departureTime = $"'{hour}':'{minutes}'";
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", hourInput);

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", hourInput, hour);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", minuteInput, minutes);

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

using BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class RouteCheckingPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IRouteCheckingPage? _routeCheckingPage => _objectContainer.IsRegistered<IRouteCheckingPage>() ? _objectContainer.Resolve<IRouteCheckingPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public RouteCheckingPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to port route checke page")]
        public void ThenIShouldRedirectedToPortRouteCheckePage()
        {
            Assert.True(_routeCheckingPage?.IsPageLoaded(), "Port route checker Application page not loaded");
        }

        [Given(@"I have selected '([^']*)' radio option")]
        [When(@"I have selected '([^']*)' radio option")]
        [Then(@"I have selected '([^']*)' radio option")]
        public void ThenIHaveSelectedRadioOption(string transportType)
        {
            _routeCheckingPage?.SelectTransportationOption(transportType);
        }

        [Given(@"I select the '([^']*)' radio option")]
        [When(@"I select the '([^']*)' radio option")]
        [Then(@"I select the '([^']*)' radio option")]
        public void ThenISelectTheRadioOption(string routeOption)
        {
            _routeCheckingPage?.SelectFerryRouteOption(routeOption);
        }

        [Given(@"I have provided Scheduled departure time")]
        [When(@"I have provided Scheduled departure time")]
        [Then(@"I have provided Scheduled departure time")]
        public void ThenIHaveProvidedScheduledDepartureTime()
        {
            string departureTime = _routeCheckingPage?.SelectDropDownDepartureTime();
            _scenarioContext.Add("DepartureTime", departureTime);
        }

        [When(@"I have provided Scheduled departure time with SPS user")]
        [Then(@"I have provided Scheduled departure time with SPS user")]
        public void ThenIHaveProvidedScheduledDepartureTimeSPS()
        {
            _routeCheckingPage?.SelectDropDownDepartureTimeWithSPS();
        }

        [When(@"I click save and continue button from route checke page")]
        public void WhenIClickSaveAndContinueButtonFromRouteCheckePage()
        {
            _routeCheckingPage?.SelectSaveAndContinue();
        }

        [When(@"I provide the '([^']*)' in the box")]
        [Then(@"I provide the '([^']*)' in the box")]
        public void ThenIProvideTheInTheBox(string routeFlightNumber)
        {
            _routeCheckingPage?.SelectFlightNumber(routeFlightNumber);
        }

        [When(@"I provide the invalid FlightNumber in the box")]
        [Then(@"I provide the invalid FlightNumber in the box")]
        public void ThenIProvideInvalidFlightNumber()
        {
            var routeFlightNumber = "'-'";
            _routeCheckingPage?.SelectFlightNumber(routeFlightNumber);
        }

        [Then(@"I should see an error '([^']*)' in route checking page")]
        public void ThenIShouldSeeAnErrorInRouteCheckingPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(_routeCheckingPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message ""([^""]*)"" in route checking page")]
        public void ThenIShouldSeeAnErrorMessageInRouteCheckingPage(string errorMessage)
        {
            Assert.True(_routeCheckingPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I have provided Scheduled departure time in hours field only")]
        public void ThenIHaveProvidedScheduledDepartureTimeInHoursFieldOnly()
        {
            _routeCheckingPage?.SelectDropDownDepartureTimeMinuteOnly();
        }

        [Then(@"I have selected '([^']*)''([^']*)''([^']*)'Date option")]
        public void ThenIHaveSelectedDateOption(string departureDay, string departureMonth, string departureYear)
        {
            _routeCheckingPage?.SelectScheduledDepartureDate(departureDay, departureMonth, departureYear);
        }

        [Then(@"I have provided Invalid Day '([^']*)''([^']*)'Date option")]
        public void ThenIHaveProvidedInvalidDayDateOption(string departureMonth, string departureYear)
        {
            var departureDay = "'-'";
            _routeCheckingPage?.SelectScheduledDepartureDate(departureDay, departureMonth, departureYear);
        }

        [Then(@"I have provided Invalid Month '([^']*)''([^']*)'Date option")]
        public void ThenIHaveProvidedInvalidMonthDateOption(string departureDay, string departureYear)
        {
            var departureMonth = "'-'";
            _routeCheckingPage?.SelectScheduledDepartureDate(departureDay, departureMonth, departureYear);
        }

        [Then(@"I have provided Invalid Year '([^']*)''([^']*)'Date option")]
        public void ThenIHaveProvidedInvalidYearDateOption(string departureDay, string departureMonth)
        {
            var departureYear = "'-'";
            _routeCheckingPage?.SelectScheduledDepartureDate(departureDay, departureMonth, departureYear);
        }

    }
}

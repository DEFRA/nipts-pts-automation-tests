using BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class WelcomePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IWelcomePage? _welcomePage => _objectContainer.IsRegistered<IWelcomePage>() ? _objectContainer.Resolve<IWelcomePage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public WelcomePageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Welcome page")]
        public void ThenIShouldNavigateToWelcomePage()
        {
            Assert.True(_welcomePage?.IsPageLoaded(), "Checks page not loaded");
        }

        [When(@"I click search button from footer")]
        public void WhenIClickSearchButtonFromFooter()
        {
            _welcomePage?.FooterSearchButton();
        }

        [Then(@"I click change link from headers")]
        public void ThenIClickChangeLinkFromHeaders()
        {
            _welcomePage?.HeadersChangeLink();
        }

        [When(@"I click footer home icon")]
        public void WhenIClickFooterHomeIcon()
        {
            _welcomePage?.FooterHomeIcon();
        }

        [When(@"I click on view on Checks page")]
        [Then(@"I click on view on Checks page")]
        public void ThenIClickOnViewOnChecksPage()
        {
            _welcomePage.clickOnView();
        }

        [When(@"I click on view on Checks page with SPS user for '([^']*)'")]
        [Then(@"I click on view on Checks page with SPS user for '([^']*)'")]
        public void ThenIClickOnViewOnChecksPageWithSPSUser(string departureRoute)
        {
            _welcomePage.clickOnViewWithSPSUser(departureRoute);
        }

        [When(@"I should see departure date and time is not matching with latest referred to SPS")]
        [Then(@"I should see departure date and time is not matching with latest referred to SPS")]
        public void ThenDepartureDateTimeCheck()
        {
            Assert.True(_welcomePage?.DepartureDateTimeCheck(), "Departure time matching");
        }

        [When(@"I should see for Flights departure date and time is not matching with latest referred to SPS")]
        [Then(@"I should see for Flights departure date and time is not matching with latest referred to SPS")]
        public void ThenFlightDepartureDateTimeCheck()
        {
            Assert.True(_welcomePage?.DepartureDateTimeCheckForFlight(), "Departure time matching");
        }
    }
}

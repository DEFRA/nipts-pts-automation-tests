using Reqnroll.BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

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

        [Then(@"I verify scan link from footer")]
        [When(@"I verify scan link from footer")]
        public void WhenIVerifyScanLinkFromFooter()
        {
            Assert.True(_welcomePage?.VerifyScanLinkFromFooter(),"Scan Link not found");
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

        [When(@"I verify submiited message")]
        [Then(@"I verify submiited message")]
        public void ThenIVerifySubmiitedMessage()
        {
            Assert.True(_welcomePage?.VerifySubmiitedMessage(), "Submitted message not matching");
        }


        [When(@"I verify submiited message image")]
        [Then(@"I verify submiited message image")]
        public void ThenIVerifySubmiitedMessageImage()
        {
            Assert.True(_welcomePage?.VerifySubmiitedMessageImage(), "Submitted message not matching");
        }

        [When(@"I verify no entries on checker page after 24 hours and before 48 hours")]
        [Then(@"I verify no entries on checker page after 24 hours and before 48 hours")]
        public void ThenIVerifyEntriesOnCheckerPage()
        {
            Assert.True(_welcomePage?.VerifyEntriesOnCheckerPage(), "Checker page entries are either after 24 hours or before 48 hours");
        }

        [When(@"I verify count '([^']*)' for Pass Checks")]
        [Then(@"I verify count '([^']*)' for Pass Checks")]
        public void ThenIVerifyCountForPassChecks(string PassCount)
        {
            Assert.True(_welcomePage.getPassCount(PassCount),"Pass count not matching on Checks page");
        }

        [Then(@"verify the route details on the welcome page for ferry '([^']*)'")]
        public void ThenVerifyFerryRoute(string FerryRoute)
        {
            Assert.True(_welcomePage.VerifySelectedFerryRouteOnWelcomePage(FerryRoute), "Selected ferry route not matching on Welcome page");
        }

        [When(@"I verify No View link if No Referred to SPS")]
        [Then(@"I verify No View link if No Referred to SPS")]
        public void ThenIVerifyNoViewLinkIfNoReferredToSPS()
        {
            Assert.True(_welcomePage.VerifyNoViewLinkIfNoReferredToSPS(), "View Link visible for No Referred to SPS on Checks page");
        }

        [When(@"I verify No View link if No Referred to SPS with SPS User")]
        [Then(@"I verify No View link if No Referred to SPS with SPS User")]
        public void ThenIVerifyNoViewLinkIfNoReferredToSPSWithSPSUser()
        {
            Assert.True(_welcomePage.VerifyNoViewLinkIfNoReferredToSPSWithSPSUser(), "View Link visible for No Referred to SPS on Checks page");
        }
    }
}

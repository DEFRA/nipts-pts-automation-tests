using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IHomePage? HomePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;

        public HomePageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Lifelong pet travel documents page")]
        public void ThenIShouldNavigateToLifelongPetTravelDocumentsPage()
        {
            Assert.True(HomePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");
        }

        [When(@"I click Apply for a document button")]
        public void WhenIClickApplyForADocumentButton()
        {
            HomePage?.ClickApplyForPetTravelDocument();
        }

        [Then(@"I click the Feedback Link")]
        public void ThenIClickTheFeedbackLink()
        {
            HomePage?.ClickFeedbackLink();
        }
        [Then(@"I should navigate to the Feedback details correct page")]
        public void ThenIShouldNavigateToTheFeedbackDetailsCorrectPage()
        {
            String currentURL = DriverCommand.GetCurrentUrl;
            currentURL.Contains("defragroup.eu.qualtrics.com/");
        }
        [Then(@"I click the Gethelp Link")]
        public void ThenIClickTheGethelpLink()
        {
            HomePage?.ClickGethelpLink();
        }

        [Then(@"I should navigate to the Gethelp details correct page")]
        public void ThenIShouldNavigateToTheGethelpDetailsCorrectPage()
        {
            var pageTitle = "Get help applying";
            Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the AccessibilityStatement Link")]
        public void ThenIClickTheAccessibilityStatementLink()
        {
            HomePage?.ClickAccessibilityStatementLink();
        }

        [Then(@"I should navigate to the AccessibilityStatement details correct page")]
        public void ThenIShouldNavigateToTheAccessibilityStatementDetailsCorrectPage()
        {
            var pageTitle = "Accessibility statement for taking a dog, cat or ferret from Great Britain to Northern Ireland";
            Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the Cookies Link")]
        public void ThenIClickTheCookiesLink()
        {
            HomePage?.ClickCookiesLink();
        }

        [Then(@"I should navigate to the Cookies details correct page")]
        public void ThenIShouldNavigateToTheCookiesDetailsCorrectPage()
        {
            var pageTitle = "Cookies";
            Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the PrivacyNotice Link")]
        public void ThenIClickThePrivacyNoticeLink()
        {
            HomePage?.ClickPrivacyNoticeLink();
        }

        [Then(@"I should navigate to the PrivacyNotice details correct page")]
        public void ThenIShouldNavigateToThePrivacyNoticeDetailsCorrectPage()
        {
            var pageTitle = "Pet travel scheme privacy notice";
            Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the TermsAndConditions Link")]
        public void ThenIClickTheTermsAndConditionsLink()
        {
            HomePage?.ClickTermsAndConditionsLink();
        }

        [Then(@"I should navigate to the TermsAndConditions details correct page")]
        public void ThenIShouldNavigateToTheTermsAndConditionsDetailsCorrectPage()
        {
            var pageTitle = "Northern Ireland Pet Travel Scheme terms and conditions";
            Assert.IsTrue(HomePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I click the CrownCopyright Link")]
        public void ThenIClickTheCrownCopyrightLink()
        {
            HomePage?.ClickCrownCopyrightLink();
        }

        [Then(@"I should navigate to the CrownCopyright details correct page")]
        public void ThenIShouldNavigateToTheCrownCopyrightDetailsCorrectPage()
        {
            String currentURL = DriverCommand.GetCurrentUrl;
            currentURL.Contains("https://www.nationalarchives.gov.uk/information-management/re-using-public-sector-information/uk-government-licensing-framework/crown-copyright/");
        }

        [Then(@"I should navigate to Manage account")]
        public void ThenIShouldNavigateToManageAccount()
        {
            HomePage?.ClickOnManageAccountLink();
        }

        [When(@"I have clicked the View hyperlink from home page")]
        public void WhenIHaveClickedTheViewHyperlinkFromHomePage()
        {
            var petName = _scenarioContext.Get<string>("PetName");
            HomePage?.ClickViewLink(petName);
        }

        [Then(@"I should see the application on pets in '([^']*)' status")]
        public void ThenIShouldSeeTheApplicationInStatus(string applicationStatus)
        {
            var petName = _scenarioContext.Get<string>("PetName");

            Assert.IsTrue(HomePage?.VerifyTheExpectedStatus(petName, applicationStatus), $"The submitted application is not in expected status of '{applicationStatus}'");
        }

    }
}

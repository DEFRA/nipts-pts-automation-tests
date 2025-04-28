using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class HeaderSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IHeaderPage? headerPage => _objectContainer.IsRegistered<IHeaderPage>() ? _objectContainer.Resolve<IHeaderPage>() : null;

        public HeaderSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"Click on GOV.UK link in the header of the page")]
        [When(@"Click on GOV.UK link in the header of the page")]
        public void ClickGOVLink()
        {
            headerPage.ClickGOVHeaderLink();
        }

        [Then(@"verify feedback page is loaded")]
        public void ThenVerifyFeedbackPageIsLoaded()
        {
            Assert.True(headerPage.VerifyFeedbackPageLoaded(), "Feed back page not loaded");
        }

        [Then(@"verify generic GOV page is loaded")]
        public void ThenVerifygenericGOVPageIsLoaded()
        {
            Assert.True(headerPage.VerifyGenericGOVPageLoaded(), "Generic GOV page not loaded");
        }

        [When(@"click on the feedback link")]
        [Then(@"click on the feedback link")]
        public void ThenClickOnTheFeedbackLink()
        {
            headerPage.ClickOnFeedBackLink();
        }

        [Then(@"verify header title '([^']*)'")]
        public void ThenVerifyHeaderTitle(string pageTitle)
        {
            Assert.True(headerPage.VerifyHeaderTitle(pageTitle), "Header Title not matching");
        }

        [Then(@"verify header banner '([^']*)'")]
        public void ThenVerifyHeaderBanner(string bannerText)
        {
            Assert.True(headerPage.VerifyHeaderBanner(bannerText), "Header banner text not matching");

        }

        [Then(@"delete browser cookies")]
        [Given(@"delete browser cookies")]
        public void ThenDeleteBrowserCookies()
        {
            headerPage.DeleteBrowserCookies();

        }

        [Then(@"verify cookies banner '([^']*)' in WELSH")]
        public void ThenVerifyWELSHCookiesBanner(string cookiesWELSHText)
        {
            Assert.True(headerPage.VerifyCookiesBannerWelsh(cookiesWELSHText), "Cookies banner text not matching");

        }

        [Then(@"verify text on the cookies preference banner '([^']*)'")]
        public void ThenVerifyTextOnSelectedCookiesBanner(string cookiesText)
        {
            Assert.True(headerPage.VerifyCookiesPrefTextWelsh(cookiesText), "Cookies banner text not matching");

        }

        [Then(@"click on cookies preference button '([^']*)' button in WELSH on cookies banner")]
        public void ThenClickCookiesPrefBtn(string cookiesPrefBtn)
        {
            headerPage.ClickCookiesPrefButton(cookiesPrefBtn);

        }

    }
}

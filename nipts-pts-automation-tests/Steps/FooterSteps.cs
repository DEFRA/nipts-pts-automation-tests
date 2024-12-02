using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class FooterSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IFooterPage? footerPage => _objectContainer.IsRegistered<IFooterPage>() ? _objectContainer.Resolve<IFooterPage>() : null;

        public FooterSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click privacy link on footer page")]
        [Then(@"click privacy link on footer page")]
        public void ClickPrivacyLinkFooterPage()
        {
            Assert.True(footerPage.ClickOnPrivacyFooterLink(), "Privacy notice link not valid");
        }

        [When(@"click cookies link on footer page")]
        [Then(@"click cookies link on footer page")]
        public void ClickCookiesLinkFooterPage()
        {
            Assert.True(footerPage.ClickOnCookiesFooterLink(), "Cookies link not valid");
           
        }

        [When(@"click accessibility link on footer page")]
        [Then(@"click accessibility link on footer page")]
        public void ClickAccessibilityLinkFooterPage()
        {
            Assert.True(footerPage.ClickOnAccessibilityFooterLink(), "Accessibility link not valid");
        }

        [When(@"click TCs link on footer page")]
        [Then(@"click TCs link on footer page")]
        public void ClickTCsLinkFooterPage()
        {
            Assert.True(footerPage.ClickOnTCsFooterLink(), "TCs link not valid");
        }

        [Then(@"verify text '([^']*)' on the page footer")]
        public void ThenVerifyTextLinkInFooterPage(string FooterHintText)
        {
            Assert.True(footerPage.VerifyFooterText(FooterHintText), "Text on Page footer not matching");
        }

        [Then(@"verify the link in Footer page details '([^']*)'")]
        public void VerifyLinkOnTheFooterPage(string Link)
        {
            Assert.True(footerPage.VerifyLinkText(Link), "Link not matching on Footer Page details");
        }

        [Then(@"verify the page title in Footer page '([^']*)'")]
        public void ThenVerifyPageTitleInFooterPage(string pageTitle)
        {
            Assert.True(footerPage.VerifyPageTitle(pageTitle), "Page title not matching");
        }

        [When(@"select Google Analytics option for cookies '([^']*)'")]
        [Then(@"select Google Analytics option for cookies '([^']*)'")]
        public void WhenSelectGoogleAnalyticsOption(string googleAnalytics)
        {
            footerPage.SelectGoogleAnalyticsOption(googleAnalytics);
        }

        [When(@"click on Save Google Analytics for cookies")]
        [Then(@"click on Save Google Analytics for cookies")]
        public void ThenClickOnSavebtn()
        {
            footerPage.ClickOnSaveGoogleAnalyticsBtn();
        }

        [Then(@"verify Google Analytics success heading  on the cookies page '([^']*)'")]
        public void ThenVerifyGoogleAnalyticsHeading(string GoogleAnalyticsHeading)
        {
            Assert.True(footerPage.VerifyGoogleAnalyticsBanner(GoogleAnalyticsHeading), "Google Analytics Success Heading not matching");
        }

        [Then(@"select option for cookies on Google Analytics banner '([^']*)'")]
        [When(@"select option for cookies on Google Analytics banner '([^']*)'")]
        public void WhenSelectCookiesOptionOnBanner(string googleAnalyticsOption)
        {
            footerPage.SelectGoogleAnalyticsOptionOnHeader(googleAnalyticsOption);
        }

        [When(@"click Hide Cookies message button on the Google Analytics Banner")]
        [Then(@"click Hide Cookies message button on the Google Analytics Banner")]
        public void ThenClickOnHidebtn()
        {
            footerPage.ClickOnHideCookiesBtn();
        }

        [Then(@"verify Hide Cookie Message button is not displayed on Google Analytics banner")]
        public void ThenVerifyHideCookieButton()
        {
            Assert.False(footerPage.VerifyHideCookieMessageButtonOnGoogleAnalyticsBanner(), "Hide Cookie Message button is displayed");
        }

        [When(@"click Change Cookies settings on the Google Analytics Banner")]
        [Then(@"click Change Cookies settings on the Google Analytics Banner")]
        public void ThenClickChangeCookieSettings()
        {
            footerPage.ClickChangeCookieSettingslnk();
        }

       
    }
}

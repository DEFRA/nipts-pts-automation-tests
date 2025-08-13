using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

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

        [When(@"open TCs link page without login")]
        [Then(@"open TCs link page without login")]
        [Given(@"open TCs link page without login")]
        public void OpenTCsLinkPage()
        {
            footerPage.OpenTCsLinkPage();
        }

        [Given(@"open Cookies link page without login")]
        [Then(@"open Cookies link page without login")]
        [Then(@"open Cookies link page without login")]
        public void OpenCookiesLinkPage()
        {
            footerPage.OpenCookiesLinkPage();
        }

        [Given(@"open Accessibility link page without login")]
        [When(@"open Accessibility link page without login")]
        [Then(@"open Accessibility link page without login")]
        public void OpenAccessibilityLinkPage()
        {
            footerPage.OpenAccessibilityLinkPage();
        }
    }
}

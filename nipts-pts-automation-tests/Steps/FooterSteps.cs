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
            footerPage.ClickOnPrivacyFooterLink();
        }

        [When(@"click cookies link on footer page")]
        [Then(@"click cookies link on footer page")]
        public void ClickCookiesLinkFooterPage()
        {
            footerPage.ClickOnCookiesFooterLink();
        }

        [When(@"click accessibility link on footer page")]
        [Then(@"click accessibility link on footer page")]
        public void ClickAccessibilityLinkFooterPage()
        {
            footerPage.ClickOnAccessibilityFooterLink();
        }

        [When(@"click TCs link on footer page")]
        [Then(@"click TCs link on footer page")]
        public void ClickTCsLinkFooterPage()
        {
            footerPage.ClickOnTCsFooterLink();
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


    }
}

using BoDi;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Pages.CP.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    internal class OutageScreenSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IOutagePage? outagePage => _objectContainer.IsRegistered<IOutagePage>() ? _objectContainer.Resolve<IOutagePage>() : null;

        public OutageScreenSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"verify the link '([^']*)' on outage page")]
        [When(@"verify the link '([^']*)' on outage page")]
        public void ThenVerifyLinkOn403OutagePage(string outageLink)
        {
            Assert.IsTrue(outagePage?.VerifyTheOutageLink(outageLink), "Outage Link not matching ");
        }

        [Then(@"I force to load the 404 error page")]
        [When(@"I force to load the 404 error page")]
        public void WhenIForceToLoadThe404ErrorPage()
        {
            outagePage?.LoadThe404ErrorPage();
        }

        [Then(@"verify text '([^']*)' on page")]
        public void ThenVerifyTextOnPage(string text)
        {
            Assert.IsTrue(outagePage?.VerifyTextOnPage(text),"Text not matching");
        }

        [Then(@"verify heading '([^']*)' on page")]
        public void ThenVerifyHeadingOnPage(string text)
        {
            Assert.IsTrue(outagePage?.VerifyHeadingOnPage(text), "Heading not matching");
        }

        [Then(@"verify Account and SignOut links not visible on page")]
        public void ThenVerifyAccountAndSignOutLinksOnPage()
        {
            Assert.IsTrue(outagePage?.VerifyAccountAndSignOutLinksOnPage(), "Account and SignOut Links are visible");
        }
    }
}

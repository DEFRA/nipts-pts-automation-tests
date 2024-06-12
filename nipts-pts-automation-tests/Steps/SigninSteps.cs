using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using pets_com_automation_tests.Data;
using pets_com_automation_tests.Pages;
using pets_com_automation_tests.Tools;
using TechTalk.SpecFlow;

namespace pets_com_automation_tests.Steps
{
    [Binding]
    public class SigninSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;

        private ISignInPage? Signin => _objectContainer.IsRegistered<ISignInPage>() ? _objectContainer.Resolve<ISignInPage>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        public SigninSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Given(@"that I navigate to the Pets compliance portal")]
        [When(@"that I navigate to the Pets compliance portal")]
        public void GivenThatINavigateToThePetsCompliancePortal()
        {
            string url = UrlBuilder.Default().Build();
            _driver.Navigate().GoToUrl(url);
            Assert.True(applicationPage.VerifyNextPageIsLoaded("Check a pet from"), "We are not in the home Page");
        }

        [Given(@"click on sign in button")]
        [When(@"click on sign in button")]
        [Then(@"click on sign in button")]
        public void ThenClickOnSignInButton()
        {
            Signin.ClickSignIn();
        }

        [Then(@"click on signout button and verify the signout message")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
        }

    }
}

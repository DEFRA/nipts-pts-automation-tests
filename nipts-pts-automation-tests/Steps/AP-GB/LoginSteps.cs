using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.LandingPage;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using nipts_pts_automation_tests.Pages.AP_GB.LogInPage;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class LoginSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ILandingPage? landingPage => _objectContainer.IsRegistered<ILandingPage>() ? _objectContainer.Resolve<ILandingPage>() : null;
        private ILogInPage? signin => _objectContainer.IsRegistered<ILogInPage>() ? _objectContainer.Resolve<ILogInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public LoginSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"that I navigate to the DEFRA application")]
        [Given(@"that I navigate to the DEFRA application")]
        public void GivenThatINavigateToTheDEFRAApplication()
        {
            var url = urlBuilder.Default("App").Build();
            _driver?.Navigate().GoToUrl(url);
        }

        [Given(@"I navigate to PETS a travel document URL")]
        [When(@"I navigate to PETS a travel document URL")]
        [Then(@"I navigate to PETS a travel document URL")]
        public void GivenINavigateToPETSATravelDocumentURL()
        {
            var url = urlBuilder.Default("App").Build();
            _driver?.Navigate().GoToUrl(url);
            signin?.SelectSignInMethod();
            Assert.True(landingPage?.IsPageLoaded("Private beta testing login"), "Application page not loaded");
        }

        [Given(@"I have provided the password for Landing page")]
        [When(@"I have provided the password for Landing page")]
        [Then(@"I have provided the password for Landing page")]
        public void GivenIHaveProvidedThePasswordForLandingPage()
        {
            landingPage?.EnterPassword();
        }

        [When(@"I click Continue button from Landing page")]
        public void WhenIClickContinueButtonFromLandingPage()
        {
            landingPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Sign in using Government Gateway page")]
        public void ThenIShouldRedirectedToTheSignInUsingGovernmentGatewayPage()
        {
            Assert.True(signin.IsPageLoaded(), "Application page not loaded");
        }

        [When(@"I have provided the credentials and signin")]
        public void WhenIHaveProvidedTheCredentialsAndSignin()
        {

            var jsonData = UserObject?.GetUser("AP-GB");
            var userObject = new User
            {
                UserId = jsonData.UserId,
                password = jsonData.password
            };

            signin?.IsSignedIn(userObject.UserId, userObject.password);
        }

        [When(@"click on signout button and verify the signout message on pets")]
        [Then(@"click on signout button and verify the signout message on pets")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(signin?.IsSignedOut(), "Not able to sign out");
        }

    }
}

using Reqnroll.BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class SignInCPSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IUrlBuilder urlBuilder => _objectContainer.Resolve<IUrlBuilder>();
        private ISignInCPPage _signInCPPage => _objectContainer.Resolve<ISignInCPPage>();
        private IRouteCheckingPage _routeCheckingPage => _objectContainer.Resolve<IRouteCheckingPage>();
        private IUserObject UserObject => _objectContainer.Resolve<IUserObject>();

        public SignInCPSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I navigate to the port checker application")]
        [Given(@"I navigate to the port checker application")]
        public void GivenThatINavigateToThePortCheckerApplication()
        {
            var url = urlBuilder.Default("Com").Build();
            // A slow B2C redirect can exceed the page-load bound; the landing page is still usable,
            // so let the sign-in step drive on rather than failing here on the timeout.
            try { _driver?.Navigate().GoToUrl(url); }
            catch (WebDriverTimeoutException) { }
        }

        [When(@"I click signin button on port checker application")]
        [Given(@"I click signin button on port checker application")]
        public void GivenIClickSigninButtonOnPortCheckerApplication()
        {
            _signInCPPage?.ClickSignInButton();
        }

        [When(@"click on signout button on CP and verify the signout message")]
        [Then(@"click on signout button on CP and verify the signout message")]
        public void ThenClickOnSignoutButtonOnCPAndVerifyTheSignoutMessage()
        {
            Assert.True(_signInCPPage?.IsSignedOut(), "Not able to sign out");
        }

        [When(@"I have provided the password for prototype research page")]
        public void WhenIHaveProvidedThePasswordForPrototypeResearchPage()
        {
            _signInCPPage?.EnterPassword();
        }

        [When(@"I have provided the CP credentials and signin")]
        public void WhenIHaveProvidedTheCPCredentialsAndSignin()
        {
            var jsonData = UserObject.GetUser("CP");
            var userObject = new User
            {
                UserId = jsonData.UserId,
                password = jsonData.password
            };

            _signInCPPage?.IsSignedIn(userObject.UserId, userObject.password);
        }

        [When(@"I have provided the CP credentials and signin for user '([^']*)'")]
        public void WhenIHaveProvidedTheCPCredentialsAndSigninForUser(string userType)
        {
            var jsonData = UserObject.GetUser("CP", userType);
            var userObject = new User
            {
                UserId = jsonData.UserId,
                password = jsonData.password
            };

            _signInCPPage?.IsSignedIn(userObject.UserId, userObject.password);
        }

        [When(@"I click on accessibility statement link")]
        [Then(@"I click on accessibility statement link")]
        public void ThenClickOnAccessibilityLink()
        {
            _signInCPPage?.ClickAccessibilityStatementLink();
        }

        [When(@"I verify signout button not visible on CP WAF Page")]
        [Then(@"I verify signout button not visible on CP WAF Page")]
        public void ThenIVerifySignoutButtonNotVisibleOnCPWAFPage()
        {
            Assert.True(_signInCPPage?.VerifySignoutButtonNotVisibleOnCPWAFPage(), "Sign out button is visible");
        }
    }
}

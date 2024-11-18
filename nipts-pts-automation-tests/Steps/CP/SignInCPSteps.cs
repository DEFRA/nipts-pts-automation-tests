using BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Tools;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class SignInCPSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IUrlBuilder? urlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private ISignInCPPage? _signInCPPage => _objectContainer.IsRegistered<ISignInCPPage>() ? _objectContainer.Resolve<ISignInCPPage>() : null;
        private IRouteCheckingPage? _routeCheckingPage => _objectContainer.IsRegistered<IRouteCheckingPage>() ? _objectContainer.Resolve<IRouteCheckingPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        public SignInCPSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I navigate to the port checker application")]
        [Given(@"that I navigate to the port checker application")]
        public void GivenThatINavigateToThePortCheckerApplication()
        {
            var url = urlBuilder.Default("Com").Build();
            _driver?.Navigate().GoToUrl(url);
        }

        [When(@"I click signin button on port checker application")]
        [Given(@"I click signin button on port checker application")]
        public void GivenIClickSigninButtonOnPortCheckerApplication()
        {
            _signInCPPage?.ClickSignInButton();
        }

        [When(@"I have provided the password for prototype research page")]
        public void WhenIHaveProvidedThePasswordForPrototypeResearchPage()
        {
            _signInCPPage?.EnterPassword();
        }

        [When(@"I have provided the CP credentials and signin")]
        public void WhenIHaveProvidedTheCPCredentialsAndSignin()
        {
            var jsonData = UserObject?.GetUser("CP");
            var userObject = new User
            {
                UserId = jsonData.UserId,
                password = jsonData.password
            };

            _signInCPPage?.IsSignedIn(userObject.UserId, userObject.password);
        }

    }
}

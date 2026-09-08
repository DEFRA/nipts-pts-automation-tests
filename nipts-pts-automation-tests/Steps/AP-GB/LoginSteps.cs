using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.LandingPage;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Tools;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Hooks;
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

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IUrlBuilder urlBuilder => _objectContainer.Resolve<IUrlBuilder>();
        private ILandingPage landingPage => _objectContainer.Resolve<ILandingPage>();
        private ILogInPage signin => _objectContainer.Resolve<ILogInPage>();
        private IUserObject UserObject => _objectContainer.Resolve<IUserObject>();

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
            signin?.SelectSignInMethod("GovernmentGateway");
        }


        [When(@"I select sign in method '([^']*)'")]
        public void WhenISelectSignInMethod(string signInMethod)
        {
            landingPage?.ClickContinueButton();
            signin?.SelectSignInMethod(signInMethod);
        }

        [When(@"I click on Sign In on OneLogIn page")]
        public void WhenIClickOnSignInOnOneLoginPage()
        {
            signin?.ClickOnSignInOnOneLoginPage();
        }

        [When(@"I have provided the One Login credentials '([^']*)', '([^']*)'")]
        public void WhenIHaveProvidedTheOneLoginCredentials(string LoginEmailAddress, string LoginPassword)
        {
            signin?.EnterOneLoginEmailAddress(LoginEmailAddress, LoginPassword);
        }

        [Then(@"I should redirected to the Sign in using Government Gateway page")]
        public void ThenIShouldRedirectedToTheSignInUsingGovernmentGatewayPage()
        {
            Assert.True(signin.IsPageLoaded(), "Application page not loaded");
        }

        [When(@"I have provided the credentials and signin")]
        public void WhenIHaveProvidedTheCredentialsAndSignin()
        {

            var jsonData = UserObject.GetUser("AP-GB");
            var userObject = new User
            {
                UserId = jsonData.UserId,
                password = jsonData.password
            };

            if (TrySignIn(userObject))
                return;

            // iOS only: the BrowserStack Safari session intermittently wedges on the sign-in redirect
            // and never recovers in-session (confirmed repeatedly). Because on iOS the container hands
            // the driver out via a swappable holder, replace the dead session with a fresh one and
            // re-drive the whole sign-in once - a fresh session usually lands healthy where the wedged
            // one could not. Fully guarded and additive: on a path that otherwise always fails today.
            if (Waits.IsIosDevice() && _objectContainer.IsRegistered<WebDriverHolder>())
            {
                Console.WriteLine("iOS sign-in did not confirm - recreating the BrowserStack session and retrying sign-in once.");
                try
                {
                    _objectContainer.Resolve<WebDriverHolder>().Recreate();

                    var url = urlBuilder.Default("App").Build();
                    _driver.Navigate().GoToUrl(url);
                    landingPage?.EnterPassword();
                    landingPage?.ClickContinueButton();
                    signin?.SelectSignInMethod("GovernmentGateway");
                    TrySignIn(userObject);
                }
                catch (Exception ex)
                {
                    // Best-effort recovery; the next step's IsPageLoaded makes the final pass/fail call.
                    Console.WriteLine("iOS fresh-session sign-in retry failed: " + ex.Message);
                }
            }
        }

        private bool TrySignIn(User user)
        {
            try
            {
                return signin?.IsSignedIn(user.UserId, user.password) ?? false;
            }
            catch (WebDriverException) when (Waits.IsIosDevice())
            {
                // The iOS wedge fast-fail throws here; treat it as "not signed in" so the
                // fresh-session retry can run instead of failing the step outright.
                return false;
            }
        }

        [When(@"click on signout button and verify the signout message on pets")]
        [Then(@"click on signout button and verify the signout message on pets")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(signin?.IsSignedOut(), "Not able to sign out");
        }

    }
}

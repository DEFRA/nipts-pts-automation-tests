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

            // iOS BrowserStack sessions can wedge the command channel around the GG/B2C sign-in (the
            // native Save-Password sheet, a stalled redirect, or a bounce back to the chooser). When
            // that happens, replace the session and re-drive the WHOLE login from a fresh navigation,
            // which gives B2C a new authorize request with fresh state. Scoped to iOS on purpose - the
            // desktop login path is left untouched.
            if (!Waits.IsIosDevice())
                return;

            const int maxLoginRetries = 2;
            for (var attempt = 1; attempt <= maxLoginRetries; attempt++)
            {
                Console.WriteLine($"Sign-in did not confirm - restarting the full login flow (attempt {attempt} of {maxLoginRetries}).");
                try
                {
                    if (_objectContainer.IsRegistered<WebDriverHolder>())
                        _objectContainer.Resolve<WebDriverHolder>().Recreate();

                    var url = urlBuilder.Default("App").Build();
                    _driver.Navigate().GoToUrl(url);
                    landingPage?.EnterPassword();
                    landingPage?.ClickContinueButton();
                    signin?.SelectSignInMethod("GovernmentGateway");
                    if (TrySignIn(userObject))
                        return;
                }
                catch (Exception ex)
                {
                    // Best-effort recovery; the next step's page assertion makes the final call.
                    Console.WriteLine($"Login retry {attempt} failed: {ex.Message}");
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
                // On iOS, a wedged command channel around sign-in surfaces as a WebDriver error.
                // Treat it as "not signed in" so the iOS full-login retry above can restart the flow.
                // Desktop keeps its original behaviour (the exception propagates).
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

using Reqnroll.BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_API_tests.Application;
using nipts_pts_automation_tests.Tools;
using Reqnroll;
using nipts_pts_automation_tests.Data;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]
    public class SigninSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationPage applicationPage => _objectContainer.Resolve<IApplicationPage>();
        private ISignInPage signin => _objectContainer.Resolve<ISignInPage>();
        private IUrlBuilder UrlBuilder => _objectContainer.Resolve<IUrlBuilder>();
        private IUserObject UserObject => _objectContainer.Resolve<IUserObject>();

        public SigninSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Given(@"that I navigate to the Pets compliance portal")]
        [When(@"that I navigate to the Pets compliance portal")]
        public void GivenThatINavigateToThePetsCompliancePortal()
        {
            string url = UrlBuilder.Default("Com").Build();
            _driver.Navigate().GoToUrl(url);
            Assert.True(applicationPage.VerifyNextPageIsLoaded("Check a pet travelling from"), "We are not in the home Page");
        }

        [Given(@"that I navigate to the Pets application portal")]
        [When(@"that I navigate to the Pets application portal")]
        public void GivenThatINavigateToThePetsApplicationPortal()
        {
            string url = UrlBuilder.Default("App").Build();
            _driver.Navigate().GoToUrl(url);
            signin.EnterPassword();
            //Assert.True(applicationPage.VerifyNextPageIsLoaded("Sign in using Government Gateway"), "We are not in the home Page");
        }

        [Given(@"sign in with valid credentials with logininfo '([^']*)'")]
        [When(@"sign in with valid credentials with logininfo '([^']*)'")]
        [Then(@"sign in with valid credentials with logininfo '([^']*)'")]
        public void ThenSignInWithValidCredentialsWithLogininfo(string userType)
        {
            var user = UserObject.GetUserById(userType);
            _objectContainer.RegisterInstanceAs(user);
            Assert.True(signin.IsSignedIn(user.UserId, user.password), "Not able to sign in");
            EnsureAccountIsNotSuspended(userType);
        }

        /// <summary>
        /// Self-heals the shared login before the test body runs: if a previous test left the
        /// account suspended, the home page shows the suspension banner and hides the "Apply for a
        /// document" button, which would otherwise fail the current scenario at that step. Any
        /// suspended application found is re-approved via the backend and we wait for it to leave
        /// the Suspended state so the account is in the expected (usable) condition. This runs for
        /// every applicant sign-in (including the suspension scenarios, which also need a usable
        /// account to create their new application) and is a best-effort no-op for healthy accounts
        /// (a single fast, non-blocking probe). It never throws: if it cannot recover, the scenario
        /// simply fails naturally at the step that needs the Apply button.
        /// </summary>
        private void EnsureAccountIsNotSuspended(string userType)
        {
            IHomePage home;
            try
            {
                home = _objectContainer.Resolve<IHomePage>();
            }
            catch
            {
                // Non-applicant-portal sign-ins (e.g. compliance portal) have no applicant home
                // page/Apply button, so there is nothing to correct here.
                return;
            }

            try
            {
                if (!home.IsSuspendedWarningPresent())
                    return;

                Console.WriteLine($"Sign-in landed on a SUSPENDED home page for '{userType}'. A previous test left the shared account suspended; attempting to restore it before continuing.");

                var appData = _objectContainer.Resolve<IApplicationData>();
                BackendTokenProvider.EnsureTokens(_driver);

                // Re-approve by posting the same 'Authorised' Service Bus message the suite already
                // uses (see ApplicationData.ApproveApplication / nipts-pts-dynamics-util). This only
                // needs the applicationId, which the row's View link targets, so we avoid the
                // fragile summary-page PTD read that the checker API rejected. Only wait on pets we
                // actually sent a re-approval for, so a failed recovery does not burn the full
                // status-poll timeout.
                var reapprovedPets = new List<string>();
                foreach (var (petName, viewHref) in home.GetSuspendedApplicationLinks())
                {
                    try
                    {
                        var applicationId = ExtractApplicationId(viewHref);
                        Console.WriteLine($"Recovery: suspended pet '{petName}' view link = '{viewHref}', extracted applicationId = '{applicationId ?? "(none)"}'.");
                        if (string.IsNullOrWhiteSpace(applicationId))
                        {
                            Console.WriteLine($"Could not extract an applicationId for suspended pet '{petName}'; skipping automatic recovery for it.");
                            continue;
                        }

                        appData.ApproveApplication(applicationId);
                        reapprovedPets.Add(petName);
                        Console.WriteLine($"Sent re-approval (Authorised) for suspended pet '{petName}' (applicationId {applicationId}).");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to auto-recover suspended pet '{petName}': {ex.Message}");
                    }
                }

                // Re-approval is applied asynchronously (Service Bus -> Dynamics), so wait for each
                // re-approved pet to leave the Suspended state before the test proceeds.
                foreach (var petName in reapprovedPets)
                {
                    home.VerifyTheExpectedStatus(petName, "Approved");
                }
            }
            catch (Exception ex)
            {
                // Best-effort: never mask the scenario with an unrelated recovery error.
                Console.WriteLine($"Suspended-account auto-recovery could not complete: {ex.Message}");
            }
        }

        // Applications are identified by a GUID that the View link carries in its href; pull it out
        // so the account can be un-suspended by applicationId without a UI PTD lookup.
        private static string? ExtractApplicationId(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;
            var match = System.Text.RegularExpressions.Regex.Match(
                url, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");
            return match.Success ? match.Value : null;
        }

        [Given(@"click on sign in button")]
        [When(@"click on sign in button")]
        [Then(@"click on sign in button")]
        public void ThenClickOnSignInButton()
        {
            signin.ClickSignIn();
        }

        [When(@"click on signout button and verify the signout message")]
        [Then(@"click on signout button and verify the signout message")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            signin.ClickSignedOut();
            Thread.Sleep(1000);
        }

        [Then(@"verify sign out link in displayed in selected language '([^']*)'")]
        public void ThenVerifySignOutTextInSelectedLanguage(string SignOutText)
        {
            Assert.True(signin.VerifySignOutTextInSelectedLanguage(SignOutText), "SignOut text language not matching");
        }

        [Then(@"verify the link on the accessibility statement page '([^']*)'")]
        public void VerifyLinkOnTheAccessibilityStatement(string Link)
        {
            Assert.True(signin.VerifyAccessibilityStatementLink(Link), "Link not matching on Accessibility statement");
        }

        
    }
}

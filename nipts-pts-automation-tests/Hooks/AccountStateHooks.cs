using Reqnroll;
using Reqnroll.BoDi;
using nipts_pts_API_tests.Application;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Hooks
{
    /// <summary>
    /// Restores the shared login account to a usable state after a scenario that suspends an
    /// application. Suspending an application makes the applicant home page show the
    /// "You have been suspended..." banner and hides the "Apply for a document" button, so any
    /// later scenario reusing the same login (e.g. test5) would fail at the Apply step if a
    /// suspending scenario ended - crucially, <b>on failure</b> - without re-approving. This hook
    /// runs on both pass and fail, before the WebDriver is torn down, and re-approves whatever the
    /// scenario suspended so the account is never left in a suspended state.
    /// </summary>
    [Binding]
    public class AccountStateHooks
    {
        // ScenarioContext keys set by the suspend steps so this hook knows what to restore.
        public const string SuspendedPtdKey = "AccountSuspendedPtdNumber";
        public const string SuspendedReferenceKey = "AccountSuspendedAppReference";

        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;

        public AccountStateHooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }

        // Order 0 so this runs before the (unordered) WebDriver teardown, keeping the driver
        // available in case a fresh backend token has to be minted to re-approve.
        [AfterScenario(Order = 0)]
        public void RestoreSuspendedAccount()
        {
            var hasPtd = _scenarioContext.TryGetValue(SuspendedPtdKey, out string ptdNumber)
                         && !string.IsNullOrWhiteSpace(ptdNumber);
            var hasReference = _scenarioContext.TryGetValue(SuspendedReferenceKey, out string appReference)
                               && !string.IsNullOrWhiteSpace(appReference);

            if (!hasPtd && !hasReference)
                return;

            try
            {
                var appData = _objectContainer.Resolve<IApplicationData>();
                BackendTokenProvider.EnsureTokens(TryGetDriver());

                if (hasPtd)
                {
                    Console.WriteLine($"AccountStateHooks: re-approving suspended application (PTD {ptdNumber}) to leave the account usable.");
                    appData.GetSuspendedApplicationToApprove(ptdNumber);
                }
                else
                {
                    Console.WriteLine($"AccountStateHooks: re-approving suspended application (reference {appReference}) to leave the account usable.");
                    appData.GetApplicationToApprove(appReference);
                }
            }
            catch (Exception ex)
            {
                // Best-effort cleanup: never mask the scenario's own result with a teardown error.
                Console.WriteLine($"AccountStateHooks: failed to restore suspended account: {ex.Message}");
            }
        }

        private IWebDriver? TryGetDriver()
        {
            try
            {
                return _objectContainer.Resolve<IWebDriver>();
            }
            catch
            {
                return null;
            }
        }
    }
}

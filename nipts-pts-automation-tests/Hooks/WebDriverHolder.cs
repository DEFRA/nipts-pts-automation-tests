using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Hooks
{
    // Holds the live WebDriver behind a per-dependency container factory so a wedged iOS Safari
    // session can be replaced mid-scenario. Because every step and page object resolves IWebDriver
    // fresh from the container, swapping Current here transparently repoints them all at the new
    // BrowserStack session - no re-registration (which BoDi forbids after resolution) is needed.
    public class WebDriverHolder
    {
        private readonly Func<IWebDriver> _driverFactory;

        public WebDriverHolder(IWebDriver initial, Func<IWebDriver> driverFactory)
        {
            Current = initial;
            _driverFactory = driverFactory;
        }

        public IWebDriver Current { get; private set; }

        // Quits the (usually wedged) current session and starts a brand-new one. The quit is
        // best-effort: a dead session's Quit can throw or hang, so failure to close it must never
        // stop us obtaining the fresh session.
        public void Recreate()
        {
            try { Current?.Quit(); } catch (Exception) { /* dead session - nothing to salvage */ }
            Current = _driverFactory();
        }
    }
}

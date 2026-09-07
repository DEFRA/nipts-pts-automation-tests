using Reqnroll.BoDi;
using Defra.UI.Framework.Object;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Capabilities;
using nipts_pts_automation_tests.Configuration;
using System.Reflection;
using Reqnroll;

namespace nipts_pts_automation_tests.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        public IWebDriver Driver { get; set; } = null!;

        // iOS-only: set when the driver is registered behind a swappable holder so a wedged sign-in
        // session can be replaced with a fresh one mid-scenario. Null on every other platform.
        private WebDriverHolder? _holder;

        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly IReqnrollOutputHelper _specFlowOutputHelper;

        public WebDriverHook(ScenarioContext context, ObjectContainer container,
            IReqnrollOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = context;
            _objectContainer = container;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        [BeforeScenario(Order = (int)HookRunOrder.WebDriver)]
        public void BeforeTestScenario()
        {

            Logger.Debug("Starting set Capability");

            var site = new Site();
            site.With(GetDriverOptions());
            Driver = site.WebDriver.Driver;

            // Latch the real platform from the live BrowserStack session so the iOS heals key off
            // ground truth, not the artifact's (sometimes stale) appsettings DeviceName.
            HelperMethods.Waits.CaptureDeviceFromDriver(Driver);

            // Bound the page-load timeout below the ~90s remote HTTP command timeout. Navigating
            // clicks/redirects (esp. the B2C sign-in/sign-out chain on mobile) can hang forever with
            // no bound; because WebDriver serialises commands during navigation, the NEXT command
            // then rides the full 90s client timeout and the whole session is declared dead. A 60s
            // bound turns that wedge into a recoverable TimeoutException the polling loops tolerate.
            try
            {
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(
                    ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds * 2);
            }
            catch (Exception ex) { Logger.Debug("Could not set page-load timeout: " + ex.Message); }

            if (HelperMethods.Waits.IsIosDevice())
            {
                // iOS only: hand the driver out via a swappable holder (behind a per-dependency
                // container factory) so the intermittently-wedged Safari sign-in session can be
                // replaced with a fresh one mid-scenario. Every non-iOS platform keeps the direct
                // instance registration below, so their behaviour is completely unchanged.
                _holder = new WebDriverHolder(Driver, CreateBrowserStackDriver);
                _objectContainer.RegisterInstanceAs(_holder);
                _objectContainer.RegisterFactoryAs<IWebDriver>(() => _holder.Current).InstancePerDependency();
            }
            else
            {
                _objectContainer.RegisterInstanceAs(Driver);
            }
        }

        // Builds a brand-new BrowserStack session used to replace a wedged iOS one. Uses a fresh
        // capability instance (BrowserStackCapability.GetDriverOptions mutates its own dictionaries
        // and cannot be called twice on the same instance) and reapplies the device latch and
        // page-load bound so the new session behaves exactly like a first-of-scenario one.
        private IWebDriver CreateBrowserStackDriver()
        {
            var site = new Site();
            site.With(new BrowserStackCapability(ConfigSetup.BaseConfiguration, _scenarioContext).GetDriverOptions());
            var driver = site.WebDriver.Driver;

            HelperMethods.Waits.CaptureDeviceFromDriver(driver);
            try
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(
                    ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds * 2);
            }
            catch (Exception ex) { Logger.Debug("Could not set page-load timeout on recreated driver: " + ex.Message); }

            return driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // After an iOS mid-scenario session swap the field points at the quit session; retarget
            // teardown (artifacts + Quit) at the live one so we clean up and report the right session.
            if (_holder != null) Driver = _holder.Current;

            bool takeScreenShot = false;
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    takeScreenShot = true;
                    var error = _scenarioContext.TestError;
                    Logger.LogMessage("An error ocurred:" + error.Message);
                    Logger.Debug("It was of type:" + error.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("Not able to take screenshot" + ex.Message);
            }
            finally
            {
                if (Driver != null)
                {
                    if (takeScreenShot)
                    {
                        // On iOS the failure is almost always a wedged command channel, so a WebDriver
                        // screenshot just rides the dead channel for ~60s and fails. BrowserStack records
                        // video + per-command visual logs server-side (independent of the channel), so
                        // log those artifact URLs instead - they show the real on-screen state.
                        if (HelperMethods.Waits.IsIosDevice())
                        {
                            LogBrowserStackSessionArtifacts();
                        }
                        else
                        {
                            // A failed scenario often leaves a degraded/closed BrowserStack session, so
                            // capturing the screenshot can itself throw; never let that surface as a
                            // teardown error that masks the real scenario failure.
                            try { AttachScreenShotToXmlReport(); }
                            catch (Exception ex) { Logger.Debug("Screenshot capture failed: " + ex.Message); }
                        }
                    }
                    // The browser session may already be gone (e.g. mobile/Edge dropped the
                    // connection); swallow so cleanup never fails an otherwise-passing scenario.
                    try { Driver.Quit(); }
                    catch (Exception ex) { Logger.Debug("Driver cleanup failed: " + ex.Message); }
                }
            }
        }

        private void AttachScreenShotToXmlReport()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            filePath = Path.Combine(filePath, "TestResults");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Logger.Debug($"{filePath} directory created....");
            }

            var fileTitle = _scenarioContext.ScenarioInfo.Title;
            var fileName = Path.Combine(filePath, $"{fileTitle}_TestFailures_{DateTime.Now:yyyyMMdd_hhss}" + ".png");

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(fileName);

            _specFlowOutputHelper.AddAttachment(fileName);
            Logger.Debug($"SCREENSHOT {fileName} ");
        }

        // Fetches BrowserStack's server-side recording for the failed session over plain HTTP - this
        // works even when the iOS WebDriver command channel is wedged (which is exactly when a normal
        // screenshot cannot be taken), so we can watch what the device was actually showing at failure.
        private void LogBrowserStackSessionArtifacts()
        {
            try
            {
                // SessionId is a local property (no remote command), so it is safe to read on a wedged session.
                var sessionId = (Driver as OpenQA.Selenium.Remote.RemoteWebDriver)?.SessionId?.ToString();
                if (string.IsNullOrWhiteSpace(sessionId))
                {
                    Logger.LogMessage("iOS failure: could not resolve the BrowserStack session id - open the "
                        + "BrowserStack Automate dashboard and find this build's session video manually.");
                    return;
                }

                var user = ConfigSetup.BaseConfiguration.BrowserStackConfiguration.CloudDeviceUserName;
                var key = ConfigSetup.BaseConfiguration.BrowserStackConfiguration.CloudDeviceUserKey;
                if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(key))
                {
                    Logger.LogMessage($"iOS failure: BrowserStack session {sessionId} - no credentials to query "
                        + "the REST API; open this session in the BrowserStack Automate dashboard to view the video.");
                    return;
                }

                using var http = new System.Net.Http.HttpClient { Timeout = TimeSpan.FromSeconds(20) };
                var auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{user}:{key}"));
                http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth);
                var json = http.GetStringAsync(
                    $"https://api.browserstack.com/automate/sessions/{sessionId}.json").GetAwaiter().GetResult();

                string Extract(string field)
                {
                    var m = System.Text.RegularExpressions.Regex.Match(json, "\"" + field + "\"\\s*:\\s*\"([^\"]+)\"");
                    return m.Success ? m.Groups[1].Value.Replace("\\/", "/") : "(not found)";
                }

                Logger.LogMessage($"iOS failure diagnostics - BrowserStack session {sessionId}: "
                    + $"dashboard={Extract("browser_url")} | video={Extract("video_url")}");
            }
            catch (Exception ex)
            {
                Logger.Debug("Could not fetch BrowserStack session artifacts: " + ex.Message);
            }
        }

        private DriverOptions GetDriverOptions()
        {
            return _objectContainer.Resolve<IDriverOptions>().GetDriverOptions();
        }

    }
}

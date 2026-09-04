using Reqnroll.BoDi;
using Defra.UI.Framework.Object;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
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

            var driverOptions = GetDriverOptions();
            var seleniumGrid = ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

            if (!string.IsNullOrWhiteSpace(seleniumGrid) &&
                seleniumGrid.Contains("browserstack", StringComparison.OrdinalIgnoreCase))
            {
                // ROOT-CAUSE FIX for the recurring mobile/Edge session wedges. BrowserStack real
                // devices/browsers can take well over 90s to settle a heavy navigation (the B2C
                // sign-in redirect, the "View all"/home-page redirect, a JS execute after a backend
                // approve). The framework's Site wrapper builds the RemoteWebDriver with the default
                // ~90s HTTP command timeout, so the navigating command is KILLED at 90s; once that
                // happens OpenQA.Selenium's command channel desyncs permanently (the late response is
                // read as the reply to the next command), which is exactly why .Url then reads back
                // '(unavailable)', FindElements returns 0, the raw command Dictionary leaks, and every
                // retry just stacks more 90s timeouts. Building the remote driver ourselves with a
                // generous command timeout lets the slow navigation finish instead of being killed,
                // keeping the session alive. Deferring clicks only moved the 90s wall to the next
                // step; this removes the wall. Capabilities are the same options the framework would
                // have used, so provisioning is unchanged - only the timeout differs.
                var commandTimeout = TimeSpan.FromSeconds(
                    ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds * 10);
                Driver = new RemoteWebDriver(new Uri(seleniumGrid), driverOptions.ToCapabilities(), commandTimeout);
            }
            else
            {
                var site = new Site();
                site.With(driverOptions);
                Driver = site.WebDriver.Driver;
            }

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

            _objectContainer.RegisterInstanceAs(Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
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
                        // A failed scenario often leaves a degraded/closed BrowserStack session, so
                        // capturing the screenshot can itself throw; never let that surface as a
                        // teardown error that masks the real scenario failure.
                        try { AttachScreenShotToXmlReport(); }
                        catch (Exception ex) { Logger.Debug("Screenshot capture failed: " + ex.Message); }
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

        private DriverOptions GetDriverOptions()
        {
            return _objectContainer.Resolve<IDriverOptions>().GetDriverOptions();
        }

    }
}

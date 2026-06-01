using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using Reqnroll;

namespace nipts_pts_automation_tests.Capabilities
{
    public class BrowserStackCapability : IDriverOptions
    {
        private static ScenarioContext _scenarioContext;
        private BaseConfiguration _configuration => ConfigSetup.BaseConfiguration;
        private readonly Dictionary<string, object> _browserstackOptions = [];
        private static readonly string[] _osList = ["WINDOWS", "OS X"];

        private readonly string _target;
        private readonly string _deviceName;
        private readonly string _bs_os_version;
        private readonly string _bs_browser_version;

        public BrowserStackCapability(BaseConfiguration baseConfiguration, ScenarioContext context)
        {
            _scenarioContext = context;
            _target = _configuration.UiFrameworkConfiguration.Target;
            _deviceName = _configuration.TestConfiguration.DeviceName;
            _bs_os_version = _configuration.TestConfiguration.BSOSVersion;
            _bs_browser_version = _configuration.TestConfiguration.BSBrowserVersion;
        }


        public DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null)
        {
            GetBrowserStackConfig();
            GetProjectDriverOptions();
            GetTestNameDriverOptions();

            bool isDesktop = _osList.Contains(_deviceName.ToUpper());

            if (isDesktop)
            {
                _browserstackOptions["os"] = _deviceName;
                _browserstackOptions["osVersion"] = _bs_os_version;
            }
            else
            {
                _browserstackOptions["deviceName"] = _deviceName;
                _browserstackOptions["osVersion"] = _bs_os_version;
                _browserstackOptions["deviceOrientation"] = "portrait";
                _browserstackOptions["realMobile"] = "true";
            }

            _browserstackOptions["local"] = "false";

            var driverOptions = BuildBrowserOptions(isDesktop);
            driverOptions.AcceptInsecureCertificates = true;
            driverOptions.AddAdditionalOption("bstack:options", _browserstackOptions);

            return driverOptions;
        }

        // Pick the correct W3C DriverOptions subclass for the target browser so
        // BrowserStack sees a consistent top-level browserName (it now enforces
        // this strictly and rejects mismatched ChromeOptions for Edge/Firefox/Safari).
        private DriverOptions BuildBrowserOptions(bool isDesktop)
        {
            var target = (_target ?? string.Empty).Trim();
            DriverOptions options = target.ToLowerInvariant() switch
            {
                "edge" => new EdgeOptions(),
                "firefox" => new FirefoxOptions(),
                "safari" => new SafariOptions(),
                _ => new ChromeOptions(),
            };
            if (isDesktop && !string.IsNullOrWhiteSpace(_bs_browser_version))
            {
                options.BrowserVersion = _bs_browser_version;
            }
            return options;
        }


        private void GetBrowserStackConfig()
        {
            if (!_browserstackOptions.ContainsKey("debug"))
            {
                _browserstackOptions.Add("debug", true);
                _browserstackOptions.Add("userName", _configuration.BrowserStackConfiguration.CloudDeviceUserName);
                _browserstackOptions.Add("accessKey", _configuration.BrowserStackConfiguration.CloudDeviceUserKey);
                _browserstackOptions.Add("idleTimeout", 300);
            }
        }

        private void GetProjectDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("projectName"))
            {
                _browserstackOptions.Add("projectName", ConfigSetup.BaseConfiguration.TestConfiguration.Project);
                _browserstackOptions.Add("buildName", ConfigSetup.BaseConfiguration.TestConfiguration.Build);
            }
        }

        protected virtual void GetTestNameDriverOptions()
        {
            if (!_browserstackOptions.ContainsKey("sessionName"))
                _browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.ClassName);
        }


    }

}

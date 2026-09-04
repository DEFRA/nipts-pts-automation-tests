using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using Reqnroll;

namespace nipts_pts_automation_tests.Capabilities
{
    public class BrowserStackCapability : IDriverOptions
    {
        private static ScenarioContext _scenarioContext = null!;
        private BaseConfiguration _configuration => ConfigSetup.BaseConfiguration;
        private readonly Dictionary<string, object> _capDictionary = [];
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


        public DriverOptions GetDriverOptions(Dictionary<string, string>? capDictionary = null)
        {
            GetBrowserStackConfig();
            GetProjectDriverOptions();
            GetTestNameDriverOptions();

            _browserstackOptions.Add("acceptInsecureCerts", true);

            _capDictionary.Add("autoGrantPermission:", true);
            _capDictionary.Add("osVersion", _bs_os_version);
            _browserstackOptions.Add("osVersion", _bs_os_version);

            if (_osList.Contains(_deviceName.ToUpper()))
            {
                _capDictionary.Add("os", _deviceName);
                _browserstackOptions.Add("os", _deviceName);
                _browserstackOptions.Add("browserName", _target);
                _browserstackOptions.Add("browserVersion", _bs_browser_version);
            }
            else
            {
                _capDictionary.Add("deviceName", _deviceName);
                _browserstackOptions.Add("deviceName", _deviceName);
                _browserstackOptions.Add("browserName", _target);
                _browserstackOptions.Add("deviceOrientation", "portrait");

                // iOS Safari raises OS-level dialogs (e.g. the "Save Password"/AutoFill sheet) around
                // the Government Gateway sign-in that Selenium's web-context Alert API cannot dismiss -
                // they wedge the session so every command (even .Url) fails until the sign-in budget
                // expires. Ask both the Appium/XCUITest layer (autoDismissAlerts, top-level and under
                // bstack:options since Automate web sessions may forward only one) to auto-dismiss
                // native alerts.
                if (IsIosDevice(_deviceName))
                {
                    _capDictionary.Add("appium:autoDismissAlerts", true);
                    _browserstackOptions.Add("autoDismissAlerts", true);
                }
            }

            _browserstackOptions.Add("local", "false");

            var driverOptions = new ChromeOptions();
            AddDictionaryValuesInDriverOptions(driverOptions, _capDictionary);
            driverOptions.AddAdditionalOption("bstack:options", _browserstackOptions);

            // For any WebDriver-visible prompt (the iOS run showed .Url returning the prompt's raw
            // value), tell the driver to auto-dismiss it at the protocol level rather than letting it
            // block commands and time the sign-in out.
            if (IsIosDevice(_deviceName))
            {
                driverOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            }

            return driverOptions;
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
            _capDictionary.Add("acceptSslCerts", "true");
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
                _browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.ClassName ?? string.Empty);
        }

        private static bool IsIosDevice(string deviceName) =>
            !string.IsNullOrEmpty(deviceName) &&
            (deviceName.Contains("iPhone", StringComparison.OrdinalIgnoreCase)
             || deviceName.Contains("iPad", StringComparison.OrdinalIgnoreCase));

        private void AddDictionaryValuesInDriverOptions(DriverOptions driverOptions, Dictionary<string, object> capDictionary)
        {
            if (capDictionary != null)
            {
                foreach (var androidDictionary in capDictionary)
                {
                    driverOptions.AddAdditionalOption(androidDictionary.Key.ToString(), androidDictionary.Value);
                }

            }
        }


    }

}

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using pets_com_automation_tests.Configuration;
using TechTalk.SpecFlow;

namespace pets_com_automation_tests.Capabilities
{
    public class BrowserStackCapability : IDriverOptions
    {


        private static ScenarioContext _scenarioContext;

        private BaseConfiguration _configuration => ConfigSetup.BaseConfiguration;
        private Dictionary<string, object> _capDictionary;
        private readonly Dictionary<string, object> _browserstackOptions = new();

        private readonly string _target;
        private readonly string _deviceName;
        private readonly string _bs_os_version;

        public BrowserStackCapability(BaseConfiguration baseConfiguration, ScenarioContext context)
        {
            _scenarioContext = context;
            _target = _configuration.UiFrameworkConfiguration.Target;
            _deviceName = _configuration.TestConfiguration.DeviceName;
            _bs_os_version = _configuration.TestConfiguration.BSOSVersion;
        }


        public DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null)
        {
            _capDictionary = new Dictionary<string, object>();

            GetBrowserStackConfig();
            GetProjectDriverOptions();
            GetTestNameDriverOptions();

            _capDictionary.Add("browser:", _target);
            _capDictionary.Add("browser_version:", "latest");
            _capDictionary.Add("os:", _deviceName);
            _capDictionary.Add("os_version:", _bs_os_version);
            _capDictionary.Add("autoGrantPermission:", true);

            _browserstackOptions.Add("acceptInsecureCerts", true);

            DriverOptions driverOptions = null;
            if (_target.Contains("Chrome"))
                driverOptions = new ChromeOptions();
            else if (_target.Contains("Edge"))
                driverOptions = new EdgeOptions();
            else if (_target.Contains("Safari"))
                driverOptions = new SafariOptions();
            else if (_target.Contains("Firefox"))
                driverOptions = new FirefoxOptions();

            AddDictionaryValuesInDriverOptions(driverOptions, _capDictionary);
            driverOptions.AddAdditionalOption("bstack:options", _browserstackOptions);

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
                _browserstackOptions.Add("sessionName", TestContext.CurrentContext.Test.ClassName);
        }

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

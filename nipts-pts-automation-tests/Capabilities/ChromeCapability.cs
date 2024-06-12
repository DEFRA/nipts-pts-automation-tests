using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Capabilities
{
    public class ChromeCapability : IDriverOptions
    {
        private static ScenarioContext _scenarioContext;

        public ChromeCapability(BaseConfiguration baseConfiguration, ScenarioContext context)
        {
            _scenarioContext = context;

        }


        private static ChromeOptions GetChromeOptions(List<string> arguments)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--diable-inforbars");
            chromeOptions.AddArgument("--start-maximized");

            if (ConfigSetup.BaseConfiguration.TestConfiguration.Headless)
            {
                chromeOptions.AddArgument("--headless");
            }

            if (arguments != null)
            {
                foreach (var argument in arguments)
                {
                    if (!argument.Contains("accept_languages"))
                    {
                        chromeOptions.AddArgument(argument);
                    }

                }
            }

            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsEmulationEnabled)
                SetChromiumDevice(chromeOptions);

            return chromeOptions;

        }
        private static void SetChromiumDevice(ChromeOptions chromeOptions)
        {
            //var chromiumMobileEmulationDeviceSettings = new ChromiumMobileEmulationDeviceSettings()
            //{
            //    Width = 393,
            //    Height = 854,
            //    PixelRatio= 1.0,
            //    EnableTouchEvents= true,
            //    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
            //};
            //chromeOptions.EnableMobileEmulation(chromiumMobileEmulationDeviceSettings);
            chromeOptions.EnableMobileEmulation(ConfigSetup.BaseConfiguration.TestConfiguration.EmulateDeviceInfo);
        }

        public DriverOptions GetDriverOptions(Dictionary<string, string> overrideCapDict = null)
        {
            List<string> arguments = GetArgumentsFromOverrides(ref overrideCapDict);

            Dictionary<string, object> capDictionary = new Dictionary<string, object>();

            DriverOptions driverOptions = GetChromeOptions(arguments);

            return driverOptions;
        }

        private List<string> GetArgumentsFromOverrides(ref Dictionary<string, string> overrideCapDict)
        {
            if (overrideCapDict == null || !overrideCapDict.ContainsKey(BrowserConfigurationValue.BrowserArguments))
            {
                return null;
            }

            List<string> args = new List<string>();
            args.Add(overrideCapDict[BrowserConfigurationValue.BrowserArguments]);

            overrideCapDict.Remove(BrowserConfigurationValue.BrowserArguments);

            return args;
        }
    }

    public class BrowserConfigurationValue
    {
        public const string BrowserArguments = nameof(BrowserArguments);
    }

}

using Defra.UI.Framework.Configuration;
using Microsoft.Extensions.Configuration;
using Reqnroll;
using TestExecutionContext = NUnit.Framework.Internal.TestExecutionContext;


namespace nipts_pts_automation_tests.Configuration
{
    [Binding]
    public class ConfigSetup
    {
        public static BaseConfiguration? BaseConfiguration { get; private set; }

        [BeforeTestRun(Order = (int)HookRunOrder.Configuration)]
        public static void SetupProjectConfig()
        {
            BaseConfiguration = LoadConfigurationFromAppSettings();
            UiFrameworkConfigurationBinding();
            DataSetupConfigurationBinding();
            DBSetupConfigurationBinding();
            ServiceBusConfigurationBinding();
        }

        private static BaseConfiguration LoadConfigurationFromAppSettings()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true);
            // Optional local overrides for developers (never committed - see .gitignore).
            builder.AddJsonFile("appsettings.local.json", true, true);
            // Allow secrets (e.g. BrowserStack credentials) to be supplied via environment
            // variables, e.g. AppSettings__BrowserStackConfiguration__CloudDeviceUserKey.
            builder.AddEnvironmentVariables();
            var settings = builder.Build();
            DebugAppSettings(settings);
            return settings.GetSection("AppSettings").Get<BaseConfiguration>();
        }

        // Config key fragments whose values must never be written to logs/console.
        private static readonly string[] _sensitiveKeyParts =
        [
            "Password", "UserKey", "AccessKey", "ConnString", "Connectionstring", "Secret", "Token"
        ];

        private static void DebugAppSettings(IConfigurationRoot configurationRoot)
        {
            Console.WriteLine("Appsettings.json >>>>>>>>>>");
            foreach (var keyValuePair in configurationRoot.GetSection("AppSettings").AsEnumerable())
            {
                var value = IsSensitive(keyValuePair.Key) ? "***REDACTED***" : keyValuePair.Value;
                Console.WriteLine($"{keyValuePair.Key} === {value}");
            }
        }

        private static bool IsSensitive(string key) =>
            !string.IsNullOrEmpty(key) &&
            _sensitiveKeyParts.Any(part => key.Contains(part, StringComparison.OrdinalIgnoreCase));
        private static void UiFrameworkConfigurationBinding()
        {
            FrameworkConfiguration.Configuration = BaseConfiguration.UiFrameworkConfiguration;
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Add("UiFrameworkConfiguration", BaseConfiguration.UiFrameworkConfiguration);
        }
        private static void DataSetupConfigurationBinding()
        {
            nipts_pts_API_tests.Configuration.DataSetupConfig.Configuration = BaseConfiguration.BackendSetupConfig;
        }

        private static void DBSetupConfigurationBinding()
        {
            string dataDB = BaseConfiguration.AppConnectionString.DBConnectionstring;
            //BaseConfiguration.ApplicationCon = BaseConfiguration.ApplicationCon.DBConnect(BaseConfiguration.AppConnectionString.DBConnectionstring);
            //BaseConfiguration.ApplicationCon.DBConnect(BaseConfiguration.AppConnectionString.DBConnectionstring);
        }
        private static void ServiceBusConfigurationBinding()
        {
            nipts_pts_API_tests.Configuration.ServiceBusConnectionData.Configuration = BaseConfiguration.ServiceBusConnectionConfig;
        }

    }


}

using Defra.UI.Framework.Configuration;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
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
            var settings = builder.Build();
            DebugAppSettings(settings);
            return settings.GetSection("AppSettings").Get<BaseConfiguration>();
        }

        private static void DebugAppSettings(IConfigurationRoot configurationRoot)
        {
            Console.WriteLine("Appsettings.json >>>>>>>>>>");
            foreach (var keyValuePair in configurationRoot.GetSection("AppSettings").AsEnumerable())
            {
                Console.WriteLine($"{keyValuePair.Key} === {keyValuePair.Value}");
            }
        }
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

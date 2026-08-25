using System.Data.SqlClient;

namespace nipts_pts_automation_tests.Configuration
{
    public class BaseConfiguration
    {
        public TestConfiguration TestConfiguration { get; set; } = new();
        public UiFrameworkConfiguration UiFrameworkConfiguration { get; set; } = new();
        public BrowserStackConfiguration BrowserStackConfiguration { get; set; } = new();
        public BackendSetupConfig BackendSetupConfig { get; set; } = new();
        public ServiceBusConnectionConfig ServiceBusConnectionConfig { get; set; } = new();
        public SqlConnection ApplicationCon { get; set; } = null!;
        public AppConnectionString AppConnectionString { get; set; } = new();
        public B2CConfig B2CConfig { get; set; } = new();
        public KeyVaultConfiguration KeyVaultConfiguration { get; set; } = new();

    }
}

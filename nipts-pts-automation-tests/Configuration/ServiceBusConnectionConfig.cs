using nipts_pts_API_tests.Configuration;

namespace nipts_pts_automation_tests.Configuration
{
    public class ServiceBusConnectionConfig : IServiceBusConnectionData
    {
        public string ServiceBusConnString { get; set; } = string.Empty;
        public string ServiceBusQueueName { get; set; } = string.Empty;
        public string ServiceBusOfflineApplQueueName { get; set; } = string.Empty;
    }
}

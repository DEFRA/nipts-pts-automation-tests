using nipts_pts_API_tests.Configuration;

namespace nipts_pts_automation_tests.Configuration
{
    public class ServiceBusConnectionConfig : IServiceBusConnectionData
    {
        public string ServiceBusConnString { get; set; }
        public string ServiceBusQueueName { get; set; }
    }
}

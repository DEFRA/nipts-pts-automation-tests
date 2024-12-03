namespace nipts_pts_API_tests.Configuration
{
    public interface IServiceBusConnectionData
    {
        string ServiceBusConnString { get; set; }
        string ServiceBusQueueName { get; set; }
    }
}

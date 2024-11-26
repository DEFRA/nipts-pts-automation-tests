namespace nipts_pts_API_tests.Configuration
{
    public class ServiceBusConnectionData
    {
        private static IServiceBusConnectionData _configuration;
        public static IServiceBusConnectionData Configuration
        {
            get
            {
                return _configuration = _configuration ?? throw new Exception("Datasetup config not initialized");
            }
            set
            {
                _configuration = value;

            }
        }
    }
}

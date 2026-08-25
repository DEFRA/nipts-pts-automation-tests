using nipts_pts_API_tests.Configuration;

namespace nipts_pts_automation_tests.Configuration
{
    public class BackendSetupConfig : IDataSetupConfig
    {
        public string ApiEndPoint1 { get; set; } = string.Empty;
        public string ApiEndPoint2 { get; set; } = string.Empty;
        public string ApiEndPoint3 { get; set; } = string.Empty;
        public string ApiEndPoint4 { get; set; } = string.Empty;
        public string ApiEndPoint5 { get; set; } = string.Empty;
        public string CheckerSubscriptionKey { get; set; } = string.Empty;
        public string CommonSubscriptionKey { get; set; } = string.Empty;
        public string BearerToken { get; set; } = string.Empty;
        public string CheckerBearerToken { get; set; } = string.Empty;
    }
}

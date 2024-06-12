namespace nipts_pts_automation_tests.Configuration
{
    public class TestConfiguration
    {
        public string Environment { get; set; }
        public string EnvPassword { get; set; }
        public string Platform { get; set; }
        public bool Headless { get; set; }
        public int GlobalWaitsInSeconds { get; set; }
        public string DeviceName { get; set; }
        public string BSOSVersion { get; set; }
        public string Project { get; set; }
        public string Build { get; set; }
        public bool IsEmulationEnabled { get; set; }
        public string EmulateDeviceInfo { get; set; }
    }

}

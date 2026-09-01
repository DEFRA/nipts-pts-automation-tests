namespace nipts_pts_automation_tests.Configuration
{
    public class TestConfiguration
    {
        public string ComPortalUrl { get; set; } = string.Empty;
        public string AppPortalUrl { get; set; } = string.Empty;
        public string EnvPassword { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public bool Headless { get; set; }
        public int GlobalWaitsInSeconds { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public string BSOSVersion { get; set; } = string.Empty;
        public string BSBrowserVersion { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public string Build { get; set; } = string.Empty;
        public bool IsEmulationEnabled { get; set; }
        public string EmulateDeviceInfo { get; set; } = string.Empty;
    }

}

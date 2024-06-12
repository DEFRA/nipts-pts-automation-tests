using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Capabilities
{
    public interface IDriverOptions
    {
        DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null);
    }
}

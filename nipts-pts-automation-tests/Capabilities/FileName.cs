using OpenQA.Selenium;

namespace pets_com_automation_tests.Capabilities
{
    public interface IDriverOptions
    {
        DriverOptions GetDriverOptions(Dictionary<string, string> capDictionary = null);
    }
}

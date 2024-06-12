using BoDi;
using Defra.UI.Framework.Object;
using OpenQA.Selenium;
using pets_com_automation_tests.Capabilities;
using pets_com_automation_tests.Configuration;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace pets_com_automation_tests.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        public IWebDriver Driver { get; set; }
        private static string Target => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.Target;
        private static string SeleniumGrid => ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public WebDriverHook(ScenarioContext context, ObjectContainer container,
            ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = context;
            _objectContainer = container;
            _specFlowOutputHelper = specFlowOutputHelper;
        }


        [BeforeScenario(Order = (int)HookRunOrder.WebDriver)]
        public void BeforeTestScenario()
        {

            Logger.Debug("Starting set Capability");

            var site = new Site();
            site.With(GetDriverOptions());
            Driver = site.WebDriver.Driver;


            _objectContainer.RegisterInstanceAs(Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            bool takeScreenShot = false;
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    takeScreenShot = true;
                    var error = _scenarioContext.TestError;
                    Logger.LogMessage("An error ocurred:" + error.Message);
                    Logger.Debug("It was of type:" + error.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("Not able to take screenshot" + ex.Message);
            }
            finally
            {
                if (takeScreenShot)
                {
                    AttachScreenShotToXmlReport();
                }
                Driver.Close();
                Driver.Quit();
                if (!ConfigSetup.BaseConfiguration.TestConfiguration.Environment.Contains("pre"))
                {
                    DeleteApplicationViaBackend();
                }
            }
        }

        private void AttachScreenShotToXmlReport()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath = Path.Combine(filePath, "TestResults");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Logger.Debug($"{filePath} directory created....");
            }

            var fileTitle = _scenarioContext.ScenarioInfo.Title;
            var fileName = Path.Combine(filePath, $"{fileTitle}_TestFailures_{DateTime.Now:yyyyMMdd_hhss}" + ".png");

            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(fileName);

            _specFlowOutputHelper.AddAttachment(fileName);
            Logger.Debug($"SCREENSHOT {fileName} ");
        }

        private DriverOptions GetDriverOptions()
        {
            return _objectContainer.Resolve<IDriverOptions>().GetDriverOptions();
        }

        private void DeleteApplicationViaBackend()
        {
            if (_scenarioContext.Count > 0 &&
                _scenarioContext.ContainsKey("AppDispId"))
            {
                /*var applicationres = (ApplicationResponse)_scenarioContext["AppDispId"];
                if (applicationres != null &&
                    !string.IsNullOrEmpty(applicationres.ApplicationId))
                {
                    _objectContainer.Resolve<ApplicationData>().DeleteApplication(applicationres.ApplicationId);
                }*/

            }


        }

    }
}

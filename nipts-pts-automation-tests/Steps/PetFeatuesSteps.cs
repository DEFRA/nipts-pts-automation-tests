using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetFeatuesSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPetFeaturesPage? petfeaturePage => _objectContainer.IsRegistered<IPetFeaturesPage>() ? _objectContainer.Resolve<IPetFeaturesPage>() : null;
        public PetFeatuesSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"enter Pets significant features '([^']*)'")]
        public void ThenIHaveSelectedAnOptionAsForSignificantFeatures(string hasSignificantFeatures)
        {
            var significantFeature = petfeaturePage.SelectSignificantFeaturesOption(hasSignificantFeatures);
            
        }   

    }
}

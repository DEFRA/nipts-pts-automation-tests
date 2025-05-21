using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetFeatuesSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetFeaturesPage? petfeaturePage => _objectContainer.IsRegistered<IPetFeaturesPage>() ? _objectContainer.Resolve<IPetFeaturesPage>() : null;
        public PetFeatuesSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"select Pets significant features '([^']*)'")]
        [Then(@"select Pets significant features '([^']*)'")]
        public void ThenIHaveSelectedAnOptionAsForSignificantFeatures(string hasSignificantFeatures)
        {
            petfeaturePage.SelectSignificantFeaturesOption(hasSignificantFeatures);
            
        }

        [When(@"enter Pets significant features '([^']*)'")]
        [Then(@"enter Pets significant features '([^']*)'")]
        public void ThenEnterPetsSignificantFeature(string SignificantFeature)
        {
            petfeaturePage.EnterSignificantFeature(SignificantFeature);

        }


    }
}

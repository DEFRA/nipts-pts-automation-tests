using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetBreedSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPetBreedPage? petBreedPage => _objectContainer.IsRegistered<IPetBreedPage>() ? _objectContainer.Resolve<IPetBreedPage>() : null;

        public PetBreedSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Select breed of your pet '([^']*)'")]
        [Then(@"Select breed of your pet '([^']*)'")]
        public void WhenEnterBreedOfPet(string petBreed)
        {
            petBreedPage.EnterFreeTextBreed(petBreed);
            
        }
    }
}

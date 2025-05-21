using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetSexSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPetSexPage? petSexPage => _objectContainer.IsRegistered<IPetSexPage>() ? _objectContainer.Resolve<IPetSexPage>() : null;
        public PetSexSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Select Pet Sex option '([^']*)'")]
        [Then(@"Select Pet Sex option '([^']*)'")]
        public void WhenSelectPetSexOption(string petSex)
        {
            petSexPage.SelectPetsSexOption(petSex);
        }

        [Then(@"verify error message '([^']*)' on Select sex of pet page")]
        public void ThenVerifyErrorMessageOnSelectSexOfPetPage(string errorMessage)
        {
            Assert.True(petSexPage.VerifyErrorMessageOnSelectSexOfPetPage(errorMessage), "Invalid error on select sex of pet Page");
        }
    }
}

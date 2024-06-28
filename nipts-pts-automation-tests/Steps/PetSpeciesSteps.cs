using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetSpeciesSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetSpeciesPage? enterSpeciesPage => _objectContainer.IsRegistered<IPetSpeciesPage>() ? _objectContainer.Resolve<IPetSpeciesPage>() : null;

        public PetSpeciesSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"verify error message '([^']*)' on Enter Species page")]
        public void ThenVerifyErrorMessageOnEnterSpeciesPage(string errorMessage)
        {
            Assert.True(enterSpeciesPage.VerifyErrorMessageOnEnterSpeciesPage(errorMessage), "Invalid error on Enter species Page");
        }

        [Then(@"I have selected an option as '([^']*)' for pet")]
        public void ThenIHaveSelectedAnOptionAsForPet(string petType)
        {
            enterSpeciesPage.SelectSpecies(petType);
            _scenarioContext.Add("PetType", petType);
        }

    }
}
using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetDateOfBirthSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPetDateOfBirthPage? petdobPage => _objectContainer.IsRegistered<IPetDateOfBirthPage>() ? _objectContainer.Resolve<IPetDateOfBirthPage>() : null;
        public PetDateOfBirthSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"enter the pet date of birth")]
        public void ThenIHaveProvidedDateOfBirth()
        {
            var dateOfBirth = petdobPage.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            _scenarioContext.Add("DateOfBirth", dateOfBirth);
        }


        [When(@"enter pets date of birth as '([^']*)', '([^']*)', '([^']*)'")]
        [Then(@"enter pets date of birth as '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenEnterPetsMicrochipDate(string PetDOBDay, string PetDOBMonth, string PetDOBYear)
        {
            petdobPage.EnterPetsDateOfBirth(PetDOBDay, PetDOBMonth, PetDOBYear);
        }

    }
}

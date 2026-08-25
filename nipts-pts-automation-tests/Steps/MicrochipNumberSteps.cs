using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class MicrochipNumberSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IMicrochipNumberPage microchipNumberPage => _objectContainer.Resolve<IMicrochipNumberPage>();

        public MicrochipNumberSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I selected the '([^']*)' option")]
        [Then(@"I selected the '([^']*)' option")]
        public void ThenISelectedTheOption(string option)
        {
            microchipNumberPage?.SelectMicrochippedOption(option);
        }

        [When(@"provided microchip number as (.*)")]
        [Then(@"provided microchip number as (.*)")]
        public void ThenProvidedMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", microchipNumberPage?.EnterMicrochipNumber(microchipNumber));
        }
    }
}
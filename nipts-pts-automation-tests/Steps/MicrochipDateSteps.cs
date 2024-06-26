using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class MicrochipDateSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IMicrochipDatePage? microchipDatePage => _objectContainer.IsRegistered<IMicrochipDatePage>() ? _objectContainer.Resolve<IMicrochipDatePage>() : null;

        public MicrochipDateSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I have provided date of PETS microchipped")]
        public void ThenIHaveProvidedDateOfPETSMicrochipped()
        {
            var microchippedDate = microchipDatePage?.EnterDateMonthYear(DateTime.Now.AddYears(-3));
            _scenarioContext.Add("MicrochippedDate", microchippedDate);
        }
    }
}



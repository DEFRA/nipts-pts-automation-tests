using BoDi;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]

    public class GBCheckReportSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IGBCheckReportPage? gBCheckReportPage => _objectContainer.IsRegistered<IGBCheckReportPage>() ? _objectContainer.Resolve<IGBCheckReportPage>() : null;

        public GBCheckReportSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"I verify GB check report")]
        [Then(@"I verify GB check report")]
        public void ThenIVerifyGBCheckReport()
        {
            gBCheckReportPage.VerifyGBCheckReport();
        }

        [When(@"I click on Conduct an SPS check")]
        [Then(@"I click on Conduct an SPS check")]
        public void ThenIClickOnConductAnSPSCheck()
        {
            gBCheckReportPage.ClickOnConductAnSPSCheck();
        }
    }
}

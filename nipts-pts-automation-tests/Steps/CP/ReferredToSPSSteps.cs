using BoDi;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]

    public class ReferredToSPSSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IRefferedToSPSPage? refferedToSPSPage => _objectContainer.IsRegistered<IRefferedToSPSPage>() ? _objectContainer.Resolve<IRefferedToSPSPage>() : null;

        public ReferredToSPSSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I verify Referred to SPS details")]
        [When(@"I verify Referred to SPS details")]
        public void WhenIVerifyReferredToSPSDetails()
        {
            refferedToSPSPage?.VerifyReferredToSPSDetails();
        }

        [Then(@"I verify SPS outcome '([^']*)' on referred SPS page")]
        [When(@"I verify SPS outcome '([^']*)' on referred SPS page")]
        public void WhenIVerifySPSOutcome(string outcome)
        {
            refferedToSPSPage?.VerifySPSOutcome(outcome);
        }

        [Then(@"I click on PTD number of the application")]
        [When(@"I click on PTD number of the application")]
        public void WhenIClickOnPTDNumberOfTheApplication()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumberNew = ptdNumber.Substring(0,5) + " " + ptdNumber.Substring(5,3) + " " + ptdNumber.Substring(8,3);
            refferedToSPSPage?.ClickOnPTDNumberOfTheApplication(ptdNumberNew);
        }

        [Then(@"I click on PTD '([^']*)' of the application")]
        [When(@"I click on PTD '([^']*)' of the application")]
        public void WhenIClickOnPTDNumberOfTheApplication(string ptdNumber)
        {
            var ptdNumberNew = "GB826" + " " + ptdNumber.Substring(0, 3) + " " + ptdNumber.Substring(3, 3);
            refferedToSPSPage?.ClickOnPTDNumberOfTheApplication(ptdNumberNew);
        }

    }
}

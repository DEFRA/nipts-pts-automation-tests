using BoDi;
using nipts_pts_API_tests.Application;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}

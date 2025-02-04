using BoDi;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
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

        [Then(@"I verify referred to SPS record count '([^']*)' on page")]
        [When(@"I verify referred to SPS record count '([^']*)' on page")]
        public void WhenIVerifyReferredToSPSRecordCount(int count)
        {
            Assert.True(refferedToSPSPage?.VerifyReferredToSPSRecordCount(count), "Count not match on Referred to SPS page");
        }

        [Then(@"I click on page '([^']*)'")]
        [When(@"I click on page '([^']*)'")]
        public void WhenIClickOnPage(string pageNumber)
        {
            refferedToSPSPage?.ClickOnPage(pageNumber);
        }

        [Then(@"I click on '([^']*)' page")]
        [When(@"I click on '([^']*)' page")]
        public void WhenIClickOnNextPage(string nextPage)
        {
            refferedToSPSPage?.ClickOnNextPage(nextPage);
        }

        [Then(@"I get PTD or reference number and add it in collection")]
        [When(@"I get PTD or reference number and add it in collection")]
        public void ThenGetPTDReferenceAndAddInCollection()
        {
            refferedToSPSPage?.GetPTDReferenceAndAddInCollection();
        }

        [Then(@"I arrange PTD or reference number in ascending order")]
        [When(@"I arrange PTD or reference number in ascending order")]
        public void ThenArrangePTDRefNumberInAscendingOrder()
        {
            refferedToSPSPage?.ArrangePTDRefNumberInAscendingOrder();
        }

        [Then(@"I verify PTD and reference number are displayed in ascending order")]
        [When(@"I verify PTD and reference number are displayed in ascending order")]
        public void WhenIVerifyAscendingOderOfPTDReference()
        {
            Assert.True(refferedToSPSPage?.VerifyAscendingOderOfPTDReference(),"PTD or reference number not in ascending order");
        }

        [Then(@"I verify wrong PTD and reference number are displayed in ascending order")]
        [When(@"I verify wrong PTD and reference number are displayed in ascending order")]
        public void WhenIVerifyWrongAscendingOderOfPTDReference()
        {
            Assert.False(refferedToSPSPage?.VerifyAscendingOderOfPTDReference(), "Wrong PTD or reference number in ascending order");
        }
    }
}

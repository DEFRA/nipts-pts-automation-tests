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
        private IReferredToSPSPage? referredToSPSPage => _objectContainer.IsRegistered<IReferredToSPSPage>() ? _objectContainer.Resolve<IReferredToSPSPage>() : null;

        public ReferredToSPSSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I verify Pet document details on Referred to SPS details")]
        [When(@"I verify Pet document details on Referred to SPS details")]
        public void WhenIVerifyPetDocumentDetailsReferredToSPSPage()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumberNew = ptdNumber.Substring(0, 5) + " " + ptdNumber.Substring(5, 3) + " " + ptdNumber.Substring(8, 3);
            var petType = _scenarioContext.Get<string>("PetType");
            var michrochipNo = _scenarioContext.Get<string>("MicrochipNumber");
            Assert.True(referredToSPSPage?.VerifyPetDocumentDetailsOnReferredToSPSPage(ptdNumberNew, petType, michrochipNo), "Pet document details not matching on Referred to SPS Page");
        }

        [Then(@"I verify Pet document detailsfor Pending and Unsuccessful Appl on Referred to SPS details")]
        [When(@"I verify Pet document detailsfor Pending and Unsuccessful Appl on Referred to SPS details")]
        public void WhenIVerifyPetDocumentDetailsPendingUnsuccessfulReferredToSPSPage()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            var petType = _scenarioContext.Get<string>("PetType");
            var michrochipNo = _scenarioContext.Get<string>("MicrochipNumber");
            Assert.True(referredToSPSPage?.VerifyPetDocumentDetailsOnReferredToSPSPage(AppReference, petType, michrochipNo), "Pet document details not matching on Referred to SPS Page");
        }


        [Then(@"I verify Pet departure details on Referred to SPS details")]
        [When(@"I verify Pet departure details on Referred to SPS details")]
        public void WhenIVerifyPetDepartureDetailsOnReferredToSPSPage()
        {
            Assert.True(referredToSPSPage?.VerifyDepartureDetailsOnReferredToSPSPage(), "Pet Departure details not matching on Referred to SPS Page");
        }

        [Then(@"I verify SPS outcome '([^']*)' on referred SPS page")]
        [When(@"I verify SPS outcome '([^']*)' on referred SPS page")]
        public void WhenIVerifySPSOutcome(string outcome)
        {
            referredToSPSPage?.VerifySPSOutcome(outcome);
        }

        [Then(@"I click on PTD number of the application")]
        [When(@"I click on PTD number of the application")]
        public void WhenIClickOnPTDNumberOfTheApplication()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumberNew = ptdNumber.Substring(0,5) + " " + ptdNumber.Substring(5,3) + " " + ptdNumber.Substring(8,3);
            referredToSPSPage?.ClickOnPTDNumberOfTheApplication(ptdNumberNew);
        }

        [Then(@"I click on Reference number of the application")]
        [When(@"I click on Reference number of the application")]
        public void WhenIClickOnReferenceNumberOfTheApplication()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            referredToSPSPage?.ClickOnPTDNumberOfTheApplication(AppReference);
        }


        [Then(@"I click on PTD '([^']*)' of the application")]
        [When(@"I click on PTD '([^']*)' of the application")]
        public void WhenIClickOnPTDNumberOfTheApplication(string ptdNumber)
        {
            var ptdNumberNew = "GB826" + " " + ptdNumber.Substring(0, 3) + " " + ptdNumber.Substring(3, 3);
            referredToSPSPage?.ClickOnPTDNumberOfTheApplication(ptdNumberNew);
        }

        [Then(@"I verify referred to SPS record count '([^']*)' on page")]
        [When(@"I verify referred to SPS record count '([^']*)' on page")]
        public void WhenIVerifyReferredToSPSRecordCount(int count)
        {
            Assert.True(referredToSPSPage?.VerifyReferredToSPSRecordCount(count), "Count not match on Referred to SPS page");
        }

        [Then(@"I click on page '([^']*)'")]
        [When(@"I click on page '([^']*)'")]
        public void WhenIClickOnPage(string pageNumber)
        {
            referredToSPSPage?.ClickOnPage(pageNumber);
        }

        [Then(@"I click on '([^']*)' page")]
        [When(@"I click on '([^']*)' page")]
        public void WhenIClickOnNextPage(string nextPage)
        {
            referredToSPSPage?.ClickOnNextPage(nextPage);
        }

        [Then(@"I get PTD or reference number and add it in collection")]
        [When(@"I get PTD or reference number and add it in collection")]
        public void ThenGetPTDReferenceAndAddInCollection()
        {
            referredToSPSPage?.GetPTDReferenceAndAddInCollection();
        }

        [Then(@"I arrange PTD or reference number in ascending order")]
        [When(@"I arrange PTD or reference number in ascending order")]
        public void ThenArrangePTDRefNumberInAscendingOrder()
        {
            referredToSPSPage?.ArrangePTDRefNumberInAscendingOrder();
        }

        [Then(@"I verify PTD and reference number are displayed in ascending order")]
        [When(@"I verify PTD and reference number are displayed in ascending order")]
        public void WhenIVerifyAscendingOderOfPTDReference()
        {
            Assert.True(referredToSPSPage?.VerifyAscendingOderOfPTDReference(),"PTD or reference number not in ascending order");
        }

        [Then(@"I verify wrong PTD and reference number are displayed in ascending order")]
        [When(@"I verify wrong PTD and reference number are displayed in ascending order")]
        public void WhenIVerifyWrongAscendingOderOfPTDReference()
        {
            Assert.False(referredToSPSPage?.VerifyAscendingOderOfPTDReference(), "Wrong PTD or reference number in ascending order");
        }
    }
}

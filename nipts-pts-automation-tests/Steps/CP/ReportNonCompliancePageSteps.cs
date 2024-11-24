using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class ReportNonCompliancePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPage? summaryPage => _objectContainer.IsRegistered<ISummaryPage>() ? _objectContainer.Resolve<ISummaryPage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IReportNonCompliancePage? _reportNonCompliancePage => _objectContainer.IsRegistered<IReportNonCompliancePage>() ? _objectContainer.Resolve<IReportNonCompliancePage>() : null;

        public ReportNonCompliancePageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should navigate to Report non-compliance page")]
        public void ThenIShouldNavigateToReportNon_CompliancePage()
        {
            Assert.IsTrue(_reportNonCompliancePage?.IsPageLoaded(), "Report non-compliance page not loaded ");
        }

        [When(@"I click Report non-compliance button from Report non-compliance page")]
        public void WhenIClickReportNon_ComplianceButtonFromReportNon_CompliancePage()
        {
            _reportNonCompliancePage?.SelectReportNonComplianceButton();
        }

        [Then(@"I click Pet Travel Document details link dropdown")]
        public void ThenIClickPetTravelDocumentDetailsLinkDropdown()
        {
            _reportNonCompliancePage?.ClickPetTravelDocumentDetailsLnk();
        }

        [Then(@"I Verify status '([^']*)' on Report non-compliance page")]
        public void ThenIVerifyStatusOnReportNon_CompliancePage(string applicationStatus)
        {
            Assert.IsTrue(_reportNonCompliancePage?.VerifyTheExpectedStatus(applicationStatus), "The submitted application is not in expected status");
        }

        [Then(@"I click '([^']*)' in Passenger details")]
        public void ThenIClickInPassengerDetails(string passengerType)
        {
            _reportNonCompliancePage?.SelectTypeOfPassenger(passengerType);
        }

        [Then(@"I should see an error message ""([^""]*)"" in Report non-compliance page")]
        public void ThenIShouldSeeAnErrorMessageInReportNon_CompliancePage(string errorMessage)
        {
            Assert.True(_reportNonCompliancePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

    }
}

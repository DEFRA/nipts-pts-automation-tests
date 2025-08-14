using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System.Diagnostics;

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

        [When(@"I click '([^']*)' in Passenger details")]
        [Then(@"I click '([^']*)' in Passenger details")]
        public void ThenIClickInPassengerDetails(string passengerType)
        {
            _reportNonCompliancePage?.SelectTypeOfPassenger(passengerType);
        }

        [When(@"I select '([^']*)' as non compliance reason")]
        [Then(@"I select '([^']*)' as non compliance reason")]
        public void ThenISelectNonComplianceReason(string nonComplianceReason)
        {
            _reportNonCompliancePage?.SelectNonComplianceReason(nonComplianceReason);
        }

        [Then(@"I should see an error message '([^']*)' in Report non-compliance page")]
        public void ThenIShouldSeeAnErrorMessageInReportNon_CompliancePage(string errorMessage)
        {
            Assert.True(_reportNonCompliancePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [When(@"I click '([^']*)' on SPS outcome")]
        [Then(@"I click '([^']*)' on SPS outcome")]
        public void ThenIClickOnSPSOutcome(string SPSStatus)
        {
            _reportNonCompliancePage?.ClickOnSPSOutcome(SPSStatus);
        }

        [When(@"I click on GB outcome")]
        [Then(@"I click on GB outcome")]
        public void ThenIClickOnGBOutcome()
        {
            _reportNonCompliancePage?.ClickOnGBOutcome();
        }

        [When(@"select Michrochip does not match the PTD checkbox")]
        [Then(@"select Michrochip does not match the PTD checkbox")]
        public void ThenIHaveTickedTheMicrochipDoesNotMatchThePTD()
        {
            _reportNonCompliancePage.TickMicrochipNoDoesNotMatchPTD();
        }

        [When(@"Enter michrochip Number in Michrochip Does not match PTD field '([^']*)'")]
        [Then(@"Enter michrochip Number in Michrochip Does not match PTD field '([^']*)'")]
        public void WhenEnterMichrochipNo(string michrochipNo)
        {
            _reportNonCompliancePage.EnterMichrochipNoDoesNotMatchPTD(michrochipNo);
        }

        [When(@"click on Save outcome")]
        [Then(@"click on Save outcome")]
        public void ThenClickOnSaveOutcome()
        {
            _reportNonCompliancePage.ClickOnSaveOutcome();
        }

        [When(@"I click on Save on update referral")]
        [Then(@"I click on Save on update referral")]
        public void ThenClickOnSaveOnUpdateReferral()
        {
            _reportNonCompliancePage.ClickOnSaveOnUpdateReferral();
        }

        [Then(@"verify hint text '([^']*)' for Other reason")]
        public void ThenVerifyOtherReasonHintText(string OtherReasonhintText)
        {
            Assert.True(_reportNonCompliancePage.VerifyOtherReasonHintTxt(OtherReasonhintText), "Invalid hint Text for Other reason on Report Non Compliance page");
        }

        [Then(@"verify hint text '([^']*)' for GB outcome")]
        public void ThenVerifyGBOutcomeMsg(string gbOutcomeMsg)
        {
            Assert.True(_reportNonCompliancePage.VerifyGBOutcomeHintTxt(gbOutcomeMsg), "Invalid GB Outcome Message on Report Non Compliance page");
        }

        [Then(@"verify hint text '([^']*)' for NI outcome")]
        public void ThenVerifyNIOutcomeMsg(string niOutcomeMsg)
        {
            Assert.True(_reportNonCompliancePage.VerifyNIOutcomeHintTxt(niOutcomeMsg), "Invalid NI Outcome Message on Report Non Compliance page");
        }

        [When(@"I Verify PTD number on Report non-compliance page")]
        [Then(@"I Verify PTD number on Report non-compliance page")]
        public void ThenVerifyPTDNumber()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumberNew = ptdNumber.Substring(0, 5) + " " + ptdNumber.Substring(5, 3) + " " + ptdNumber.Substring(8, 3);
            Assert.True(_reportNonCompliancePage.VerifyPTDNumber(ptdNumberNew), "Invalid PTD Number on Report Non Compliance page");
        }


        [When(@"I Verify Application Reference number on Report non-compliance page")]
        [Then(@"I Verify Application Reference number on Report non-compliance page")]
        public void ThenVerifyApplRefNumber()
        {
            var applRefNum = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_reportNonCompliancePage.VerifyApplicationReferenceNumber(applRefNum), "Invalid Application Reference Number on Report Non Compliance page");
        }

        [When(@"I select MicrochipReason '([^']*)' on Report non-compliance page")]
        [Then(@"I select MicrochipReason '([^']*)' on Report non-compliance page")]
        public void ThenSelectMicrochipReason(string MicrochipReason)
        {
            _reportNonCompliancePage.SelectMicrochipReason(MicrochipReason);
        }

        [When(@"I enter relevant comment '([^']*)'")]
        [Then(@"I enter relevant comment '([^']*)'")]
        public void ThenEnterAdditionalComment(string AdditionalComment)
        {
            _reportNonCompliancePage.EnterAdditionalComment(AdditionalComment);
        }

        [When(@"I select GB Outcome '([^']*)' on Report non-compliance page")]
        [Then(@"I select GB Outcome '([^']*)' on Report non-compliance page")]
        public void ThenSelectGBOutcome(string GBOutcome)
        {
            _reportNonCompliancePage.SelectGBOutcome(GBOutcome);
        }

        [When(@"I select Visual check '([^']*)' on Report non-compliance page")]
        [Then(@"I select Visual check '([^']*)' on Report non-compliance page")]
        public void ThenSelectVisualCheck(string VisualCheck)
        {
            _reportNonCompliancePage.SelectVisualCheck(VisualCheck);
        }

        [When(@"I select Other issues '([^']*)' on Report non-compliance page")]
        [Then(@"I select Other issues '([^']*)' on Report non-compliance page")]
        public void ThenSelectOtherIssues(string OtherIssues)
        {
            _reportNonCompliancePage.SelectOtherIssues(OtherIssues);
        }

        [When(@"I enter details of outcome '([^']*)'")]
        [Then(@"I enter details of outcome '([^']*)'")]
        public void ThenEnterDetailsOfOutCome(string DetailsOfOutCome)
        {
            _reportNonCompliancePage.EnterDetailsOfOutCome(DetailsOfOutCome);
        }

        [When(@"I verify the Reasons Heading structure")]
        [Then(@"I verify the Reasons Heading structure")]
        public void ThenVerifyTheReasonsHeadingStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyTheReasonsHeadingStructure(), "Reasons Heading structure not matching");
        }

        [When(@"I verify the Microchip Heading structure")]
        [Then(@"I verify the Microchip Heading structure")]
        public void ThenVerifyTheMicrochipHeadingStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyTheMicrochipHeadingStructure(), "Microchip Heading structure not matching");
        }

        [When(@"I click on Microchip details Heading structure")]
        [Then(@"I click on Microchip details Heading structure")]
        public void ThenClickOnMicrochipDetailsStructure()
        {
            _reportNonCompliancePage.ClickOnTheMicrochipDetailsHeadingStructure();
        }

        [When(@"I verify the Visual check Heading structure")]
        [Then(@"I verify the Visual check Heading structure")]
        public void ThenVerifyTheVisualCheckStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyTheVisualCheckHeadingStructure(), "Visual check Heading structure not matching");
        }

        [When(@"I click on Pet details Heading structure")]
        [Then(@"I click on Pet details Heading structure")]
        public void ThenClickOnPetDetailsStructure()
        {
            _reportNonCompliancePage.ClickOnPetDetailsHeadingStructure();
        }

        [When(@"I verify the Other Issues Heading structure")]
        [Then(@"I verify the Other Issues Heading structure")]
        public void ThenVerifyTheOtherIssuesStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyTheOtherIssuesHeadingStructure(), "Other Issues Heading structure not matching");
        }

        [When(@"I click on Pet owner details Heading structure")]
        [Then(@"I click on Pet owner details Heading structure")]
        public void ThenClickOnPetOwnerDetailsStructure()
        {
            _reportNonCompliancePage.ClickOnPetOwnerDetailsHeadingStructure();
        }

        [When(@"I verify the Any relevant comments Heading structure")]
        [Then(@"I verify the Any relevant comments Heading structure")]
        public void ThenVerifyTheAnyRelevantCommentsStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyTheAnyRelevantCommentsHeadingStructure(), "Any relevant comments Heading structure not matching");
        }

        [When(@"I verify the Record outcome Heading structure")]
        [Then(@"I verify the Record outcome Heading structure")]
        public void ThenVerifyTheRecordOutcomeStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyTheRecordOutcomeHeadingStructure(), "Record outcome Heading structure not matcging");
        }

        [When(@"I verify the Passanger details Heading structure")]
        [Then(@"I verify the Passanger details Heading structure")]
        public void ThenVerifyThePassengerDetailsStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyThePassengerDetailsHeadingStructure(), "Passanger details Heading structure not matcging");
        }

        [When(@"I verify the Pet Travel Document Heading structure")]
        [Then(@"I verify the Pet Travel Document Heading structure")]
        public void ThenVerifyThePetTravelDocumentStructure()
        {
            Assert.True(_reportNonCompliancePage.VerifyThePetTravelDocumentHeadingStructure(), "Pet Travel Document Heading structure not matcging");
        }
    }
}

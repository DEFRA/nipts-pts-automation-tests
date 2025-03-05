using BoDi;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
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

        [When(@"I click on Conduct an SPS check")]
        [Then(@"I click on Conduct an SPS check")]
        public void ThenIClickOnConductAnSPSCheck()
        {
            gBCheckReportPage.ClickOnConductAnSPSCheck();
        }

        [When(@"I verify GB check report with MicrochipReason '([^']*)','([^']*)','([^']*)'")]
        [Then(@"I verify GB check report with MicrochipReason '([^']*)','([^']*)','([^']*)'")]
        public void ThenIVerifyMicrochipReason(string NumberMicrochipReason,string MicrochipReason,string NumberOtherIssues)
        {
            Assert.True(gBCheckReportPage.VerifyMicrochipReason(NumberMicrochipReason,MicrochipReason, NumberOtherIssues), "Microchip Reason does not match");
        }

        [When(@"I verify GB check report with relevent comment '([^']*)'")]
        [Then(@"I verify GB check report with relevent comment '([^']*)'")]
        public void ThenIVerifyAdditionalComment(string AdditionalComment)
        {
            Assert.True(gBCheckReportPage.VerifyAdditionalComment(AdditionalComment), "Additional Comment does not match");
        }

        [When(@"I verify GB check report with GB Outcome '([^']*)','([^']*)'")]
        [Then(@"I verify GB check report with GB Outcome '([^']*)','([^']*)'")]
        public void ThenIVerifyGBOutcome(string NumberGBOutcome, string GBOutcome)
        {
            Assert.True(gBCheckReportPage.VerifyGBOutcome(NumberGBOutcome,GBOutcome), "GB Outcome does not match");
        }

        [When(@"I verify GB check report wiht Visual check '([^']*)'")]
        [Then(@"I verify GB check report wiht Visual check '([^']*)'")]
        public void ThenIVerifyGBOutcome(string PetDoesNotMatchThePTD)
        {
            Assert.True(gBCheckReportPage.VerifyVisualCheck(PetDoesNotMatchThePTD), "Visual Check does not match");
        }

        [When(@"I verify GB check report with Other issues '([^']*)','([^']*)'")]
        [Then(@"I verify GB check report with Other issues '([^']*)','([^']*)'")]
        public void ThenIVerifyOtherIssues(string NumberOtherIssues, string OtherIssues)
        {
            Assert.True(gBCheckReportPage.VerifyOtherIssues(NumberOtherIssues, OtherIssues), "Other Issues does not match");
        }

    }
}

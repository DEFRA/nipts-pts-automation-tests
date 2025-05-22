using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class CheckYourAnswersDeclarationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private ICheckYourAnswersDeclarationPage? checkAnsDeclarationPage => _objectContainer.IsRegistered<ICheckYourAnswersDeclarationPage>() ? _objectContainer.Resolve<ICheckYourAnswersDeclarationPage>() : null;
        public CheckYourAnswersDeclarationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }


        [When(@"confirm By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox")]
        [Then(@"confirm By sending this application, you confirm that you've given accurate and truthful information about your pet checkbox")]
        public void ThenIHaveTickedTheBySendingThisApplicationYouConfirmThatYouveGivenAccurateAndTruthfulInformationAboutYourPetCheckbox()
        {
            checkAnsDeclarationPage.TickAgreedToAccuracy();
        }

        [When(@"confirm Defra's privacy policy checkbox")]
        [Then(@"confirm Defra's privacy policy checkbox")]
        public void ThenIHaveTickedTheIAgreeToDefrasPrivacyPolicyCheckbox()
        {
            checkAnsDeclarationPage.TickAgreetToPrivacyPolicy();
        }

        [When(@"confirm the declaration checkbox")]
        [Then(@"confirm the declaration checkbox")]
        public void ThenIHaveTickedTheIAgreeToTheDeclarationCheckbox()
        {
            checkAnsDeclarationPage.TickAgreedToDeclaration();
        }

        [When(@"click Accept and Send button from Declaration page")]
        [Then(@"click Accept and Send button from Declaration page")]
        public void WhenIClickAcceptAndSendButtonFromDeclarationPage()
        {
            checkAnsDeclarationPage.ClickSendApplicationButton();
        }

        [When(@"click on Apply for another lifelong pet travel document link")]
        [Then(@"click on Apply for another lifelong pet travel document link")]
        public void WhenIHaveClickedTheApplyForAnotherLifelongPetTravelDocumentLink()
        {
            checkAnsDeclarationPage.ClickApplyForAnotherPetTravelDocument();
        }

        [When(@"click on View all lifelong pet travel document link")]
        [Then(@"click on View all lifelong pet travel document link")]
        public void WhenIHaveClickedTheViewAllLifelongPetTravelDocumentLink()
        {
            checkAnsDeclarationPage.ClickViewAllPetTravelDocument();
        }

        [Then(@"verify WELSH summary on the application summary page with field name '([^']*)' and field value '([^']*)'")]
        public void ThenVerifyWELSHSummaryApprovedPTD(string fieldName, string fieldValue)
        {
            Assert.True(checkAnsDeclarationPage.VerifyWELSHSummaryOnAppSummary(fieldName, fieldValue), "Summary mistmatch on Approved PTD");
        }

        [Then(@"verify gender on the application summary in WELSH as '([^']*)' '([^']*)'")]
        public void ThenVerifyGenderOnWELSHSummaryPTD(string fieldName, string fieldValue)
        {
            Assert.True(checkAnsDeclarationPage.VerifyGenderOnWELSHAppSummary(fieldName, fieldValue), "Summary mistmatch on Approved PTD");
        }

        [Then(@"verify pet owner details on the application summary in WELSH as '([^']*)' '([^']*)'")]
        public void ThenVerifyPetOwnerDetailsOnWELSHSummaryPTD(string fieldName, string fieldValue)
        {
            Assert.True(checkAnsDeclarationPage.VerifyPetOwnerDetailsOnAppSummaryInWELSH(fieldName, fieldValue), "Summary mistmatch on Approved PTD");
        }


        [Then(@"verify WELSH text for Michrochip Date '([^']*)' and Michrochip Date on application summary page")]
        public void ThenIVerifyMichrochipDateOnPTD(string michrochipDate)
        {
            string michrochipDateValue = _scenarioContext.Get<string>("MicrochippedDate");
            Assert.True(checkAnsDeclarationPage.VerifyMichrochipDateOnAppSummaryInWelsh(michrochipDate, michrochipDateValue), "Michrochip Date mismatch on approved PTD");
        }

        [Then(@"verify WELSH text for Pet DOB '([^']*)' and Pet DOB on application summary page")]
        public void ThenIVerifyPetDOBOnPTD(string petDOB)
        {
            string petDOBValue = _scenarioContext.Get<string>("DateOfBirth");
            Assert.True(checkAnsDeclarationPage.VerifyPetDOBOnAppSummaryInWelsh(petDOB, petDOBValue), "Pet DOB mismatch on approved PTD");
        }
    }
}

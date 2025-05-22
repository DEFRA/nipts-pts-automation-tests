using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using Microsoft.Identity.Client;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.CP.Pages;
using System.Text.RegularExpressions;
using System.Text;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;

        public ApplicationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on Welsh language")]
        [Then(@"click on Welsh language")]
        public void ThenClickOnWelshLang()
        {
            applicationPage.ClickOnWelshLang();
        }

        [When(@"click on English language")]
        [Then(@"click on English language")]
        public void ThenClickOnEnglishLang()
        {
            applicationPage.ClickOnEnglishLang();
        }

        [When(@"click on Apply for a document")]
        [Then(@"click on Apply for a document")]
        public void ThenClickOnApplyForADocument()
        {
            applicationPage.ClickOnApplyForADocument();
        }

        [When(@"click on continue")]
        [Then(@"click on continue")]
        public void ThenClickOnContinue()
        {
            applicationPage.ClickOnContinueWelsh();
        }

        [When(@"click on back")]
        [Then(@"click on back")]
        public void ThenClickOnBack()
        {
            applicationPage.ClickOnBackWelsh();
        }

        [Then(@"Close Current tab")]
        public void CloseCurrentTab()
        {
            applicationPage.CloseCurrentTab();
        }

        [When(@"click browser back")]
        [Then(@"click browser back")]
        public void ClickBrowserBack()
        {
            applicationPage.ClickBrowserBack();
        }

        [When(@"switch to next opened tab")]
        [Then(@"switch to next opened tab")]
        public void SwitchToTab()
        {
            applicationPage.SwitchToNextTab();
            _driver.ElementImplicitWait();
        }

        [When(@"switch to previous tab")]
        [Then(@"switch to previous tab")]
        public void SwitchToPreviousTab()
        {
            applicationPage.SwitchToPreviousOpenTab();
        }

        [Then(@"verify error message '([^']*)' on Pets")]
        public void ThenVerifyErrorMessage(string errorMessage)
        {
            Assert.True(applicationPage.VerifyErrorMessage(errorMessage), "Error message not matching");
        }

        [Then(@"verify displayed language at page footer '([^']*)'")]
        public void ThenVerifySignOutTextInSelectedLanguage(string DisplayedLang)
        {
            Assert.True(applicationPage.VerifyLanguageAtPageFooter(DisplayedLang), "Displayed language not matching at page footer");
        }

        [When(@"click on continue english")]
        [Then(@"click on continue english")]
        public void ThenClickOnContinueEng()
        {
            applicationPage.ClickOnContinueEng();
        }

        [Then(@"click on View your pet travel documents or apply new one")]
        public void ClickOnViewYourPetDocumentFromManageYourAccount()
        {
            applicationPage.ClickOnViewYourPetTravelDoc();
        }

        [When(@"I should see the application in '([^']*)' status")]
        [Then(@"I should see the application in '([^']*)' status")]
        public void ThenIShouldSeeTheApplicationInStatus(string applicationStatus)
        {
            var petName = _scenarioContext.Get<string>("PetName");

            Assert.IsTrue(applicationPage.VerifyTheExpectedStatus(petName, applicationStatus), $"The submitted application is not in expected status of '{applicationStatus}'");
        }

        [When(@"click on Get Help Welsh Link")]
        [Then(@"click on Get Help Welsh Link")]
        public void ThenClickOnGetHelpWelshLink()
        {
            applicationPage.ClickOnHelpWelshLink();
        }

        [Then(@"verify WELSH summary of Approved PTD field name '([^']*)' and field value '([^']*)'")]
        public void ThenVerifyWELSHSummaryApprovedPTD(string fieldName, string fieldValue)
        {
            Assert.True(applicationPage.VerifyWELSHApprovedPTD(fieldName,fieldValue), "Summary mistmatch on Approved PTD");
        }

        [Then(@"verify WELSH text for PTD Number '([^']*)' and PTD Number on approved PTD")]
        public void ThenIVerifyPTDNumberOnApprovedPTD(string ptdNumber)
        {
            string ptdNumberValue = _scenarioContext.Get<string>("PTDNumber");
            Assert.True(applicationPage.VerifyPTDNumberOnApprovedPTD(ptdNumber,ptdNumberValue), "PTD Number mismatch on approved PTD");
        }

        [Then(@"verify WELSH text for Michrochip Date '([^']*)' and Michrochip Date on approved PTD")]
        public void ThenIVerifyMichrochipDateOnApprovedPTD(string michrochipDate)
        {
            string michrochipDateValue = _scenarioContext.Get<string>("MicrochippedDate");
            Assert.True(applicationPage.VerifyMichrochipDateOnApprovedPTD(michrochipDate, michrochipDateValue), "Michrochip Date mismatch on approved PTD");
        }

        [Then(@"verify WELSH text for Pet DOB '([^']*)' and Pet DOB on approved PTD")]
        public void ThenIVerifyPetDOBOnApprovedPTD(string petDOB)
        {
            string petDOBValue = _scenarioContext.Get<string>("DateOfBirth");
            Assert.True(applicationPage.VerifyPetDOBOnApprovedPTD(petDOB, petDOBValue), "Pet DOB mismatch on approved PTD");
        }

        [When(@"I have clicked the Welsh change option for the '(.*)' from Pet owner details section")]
        [Then(@"I have clicked the Welsh change option for the '(.*)' from Pet owner details section")]
        public void ThenIHaveClickedTheChangeOptionForTheFromPetOwnerDetailsSection(string fieldName)
        {
            applicationPage?.ClickWelshPetOwnerChangeLink(fieldName);
        }

        [When(@"I have clicked the Welsh change option for the '(.*)' from Pet details section")]
        [Then(@"I have clicked the Welsh change option for the '(.*)' from Pet details section")]
        public void ThenIHaveClickedTheChangeOptionForTheFromPetDetailsSection(string fieldName)
        {
            applicationPage?.ClickWelshPetDetailsChangeLink(fieldName);
        }

        [When(@"I have clicked the Welsh change option for Ferret '(.*)' from Pet details section")]
        [Then(@"I have clicked the Welsh change option for Ferret '(.*)' from Pet details section")]
        public void ThenIHaveClickedTheChangeOptionForFerrerFromPetDetailsSection(string fieldName)
        {
            applicationPage?.ClickWelshPetDetailsChangeForFerretLink(fieldName);
        }

        [When(@"I have clicked the Welsh change option for the '(.*)' from Microchip information section")]
        [Then(@"I have clicked the Welsh change option for the '(.*)' from Microchip information section")]
        public void ThenIHaveClickedChangeOptionForTheFieldFromMicrochipInformationSection(string fieldName)
        {
            applicationPage?.ClickWelshMicrochipChangeLink(fieldName);
        }


        [Then(@"verify WELSH summary of Pending Appl for field name '([^']*)' and field value '([^']*)'")]
        public void ThenVerifyWELSHSummaryPendingAppl(string fieldName, string fieldValue)
        {
            Assert.True(applicationPage.VerifyWELSHFieldsAndValuesForPendingAppl(fieldName, fieldValue), "Summary mistmatch on Pending Appl");
        }

        [Then(@"verify WELSH text for Reference Number '([^']*)' and Reference Number on pending application")]
        public void ThenIVerifyRefernceNumberOnPendingAppl(string ReferenceNumberText)
        {
            string referenceNumberValue = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(applicationPage.VerifyReferenceNumberOnPendingAppl(ReferenceNumberText, referenceNumberValue), "Reference Number mismatch on Pending Appl");
        }

        [Then(@"verify WELSH text for Michrochip Date '([^']*)' and Michrochip Date on Pending Appl")]
        public void ThenIVerifyMichrochipDateOnPendingAppl(string michrochipDateText)
        {
            string michrochipDateValue = _scenarioContext.Get<string>("MicrochippedDate");
            Assert.True(applicationPage.VerifyMichrochipDateOnPendingAppl(michrochipDateText, michrochipDateValue), "Michrochip Date mismatch on Pending Appl");
        }

        [Then(@"verify WELSH text for Pet DOB '([^']*)' and Pet DOB on Pending Appl")]
        public void ThenIVerifyPetDOBOnPendingAppl(string petDOBText)
        {
            string petDOBValue = _scenarioContext.Get<string>("DateOfBirth");
            Assert.True(applicationPage.VerifyPetDOBOnPendingAppl(petDOBText, petDOBValue), "Pet DOB mismatch on Pending Appl");
        }

        [Then(@"verify WELSH heading text '([^']*)' on Summary page")]
        public void ThenIVerifyHeadingTextOnSummaryPage(string Heading)
        {
            Assert.True(applicationPage.VerifyHeadingTextOnSummaryPage(Heading), "Pet Heading mismatch on Summary page");
        }

        [Then(@"I verify the header Welsh petname '([^']*)' on homepage")]
        public void ThenVerifyWelshPetnameOnPage(string Petname)
        {
            Assert.IsTrue(applicationPage?.VerifyTheHeaderWelshPetname(Petname), "Link not matching ");
        }

        [Then(@"I verify the header Welsh Status '([^']*)' on homepage")]
        public void ThenVerifyWelshStatusOnPage(string Status)
        {
            Assert.IsTrue(applicationPage?.VerifyTheHeaderWelshStatus(Status), "Link not matching");
        }

        [Then(@"verify WELSH format of PTD number on search results page")]
        public void ThenIVerifyWELSHFormatofPTDNumber()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumber1 = ptdNumber.Substring(5);
            var ptdNumber2 = ptdNumber.Substring(0, 5);
            string ptdNumber3 = ptdNumber2.ToString();
            string ptdNumber4 = Regex.Replace(ptdNumber1, @"\w{3}", @" $0", RegexOptions.RightToLeft);
            StringBuilder sb = new StringBuilder();
            sb.Append(ptdNumber3);
            sb.Append(ptdNumber4);
            String finalPTD = sb.ToString();
            applicationPage.VerifyWELSHPTDNoOnSearchResultsPassFailPage(finalPTD);
        }
    }
}

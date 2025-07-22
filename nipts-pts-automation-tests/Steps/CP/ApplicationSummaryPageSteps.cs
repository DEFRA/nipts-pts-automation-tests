using Reqnroll.BoDi;
using nipts_pts_API_tests.Application;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class ApplicationSummaryPageSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSummaryPage? _applicationSummaryPage => _objectContainer.IsRegistered<IApplicationSummaryPage>() ? _objectContainer.Resolve<IApplicationSummaryPage>() : null;
        private IApplicationData? AppData => _objectContainer.IsRegistered<IApplicationData>() ? _objectContainer.Resolve<IApplicationData>() : null;
        public ApplicationResponse ApplicationResponse { get; set; }

        public ApplicationSummaryPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should see the application status in '([^']*)'")]
        [When(@"I should see the application status in '([^']*)'")]
        public void ThenIShouldSeeTheApplicationStatusIn(string applicationStatus)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheExpectedStatus(applicationStatus), "The submitted application is not in expected status");
        }

        [Then(@"I should see the application subtitle '([^']*)'")]
        [When(@"I should see the application subtitle '([^']*)'")]
        public void ThenIShouldSeeTheApplicationSubtitle(string applicationSubtitle)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheExpectedSubtitle(applicationSubtitle), "The submitted application is not in expected subtitle");
        }

        [Then(@"I should see the Search Results Heading '([^']*)'")]
        [When(@"I should see the Search Results Heading '([^']*)'")]
        public void ThenIShouldSeeTheSearchResultsHeading(string SearchResultsHeading)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheSearchResultsHeading(SearchResultsHeading), "The submitted application is not in expected subtitle");
        }

        [Then(@"I select Pass radio button")]
        [When(@"I select Pass radio button")]
        public void WhenISelectPassRadioButton()
        {
            _applicationSummaryPage?.SelectPassRadioButton();
        }

        [Then(@"I select Fail radio button")]
        [When(@"I select Fail radio button")]
        public void WhenISelectFailRadioButton()
        {
            _applicationSummaryPage?.SelectFailRadioButton();
        }

        [Then(@"I click save and continue button from application status page")]
        [When(@"I click save and continue button from application status page")]
        public void WhenIClickSaveAndContinueButtonFromApplicationStatusPage()
        {
            _applicationSummaryPage?.SelectSaveAndContinue();
        }

        [Then(@"I click continue button from application status page")]
        [When(@"I click continue button from application status page")]
        public void WhenIClickContinueButtonFromApplicationStatusPage()
        {
            _applicationSummaryPage?.SelectContinue();
        }

        [Then(@"I should see an error message ""([^""]*)"" in application status page")]
        public void ThenIShouldSeeAnErrorMessageInApplicationStatusPage(string errorMessage)
        {
            Assert.True(_applicationSummaryPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Given(@"Approve an application via backend")]
        [When(@"Approve an application via backend")]
        [Then(@"Approve an application via backend")]
        public void ThenApproveApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                string PTDNumber = AppData.GetApplicationToApprove(AppReference);
                _scenarioContext.Add("PTDNumber", PTDNumber);
                Console.WriteLine($"PTDNumber: {PTDNumber}");
            }
        }

        [Given(@"Approve suspended application via backend")]
        [When(@"Approve suspended application via backend")]
        [Then(@"Approve suspended application via backend")]
        public void ThenApproveSuspendedApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                AppData.GetApplicationToApprove(AppReference);
            }
        }

        [Given(@"Approve suspended application with PTDNumber via backend")]
        [When(@"Approve suspended application with PTDNumber via backend")]
        [Then(@"Approve suspended application with PTDNumber via backend")]
        public void ThenApproveSuspendedApplicationWithPTDNumberViaBackend()
        {
            lock (_lock)
            {
                string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
                AppData.GetSuspendedApplicationToApprove(PTDNumber);
            }
        }

        [Given(@"Suspend an Awaiting application via backend")]
        [When(@"Suspend an Awaiting application via backend")]
        [Then(@"Suspend an Awaiting application via backend")]
        public void ThenSuspendAwaitingApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                AppData.GetAwaitingApplicationToSuspend(AppReference);
            }
        }

        [Given(@"Suspend an Authorised application via backend")]
        [When(@"Suspend an Authorised application via backend")]
        [Then(@"Suspend an Authorised application via backend")]
        public void ThenSuspendAuthorisedApplicationViaBackend()
        {
            lock (_lock)
            {
                string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
                AppData.GetAuthorisedApplicationToSuspend(PTDNumber);
            }
        }

        [When(@"Revoke an application via backend")]
        [Then(@"Revoke an application via backend")]
        public void ThenRevokeApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                string PTDNumber = AppData.GetApplicationToRevoke(AppReference);
                _scenarioContext.Add("PTDNumber", PTDNumber);
            }
        }

        [When(@"Revoke Approved application via backend")]
        [When(@"Revoke Approved application via backend")]
        public void ThenRevokeApprovedApplicationViaBackend()
        {
            lock (_lock)
            {
                string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
                AppData.RevokeApprovedApplication(PTDNumber);
            }
        }

        [When(@"Reject an application via backend")]
        public void ThenRejectApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                string PTDNumber = AppData.GetApplicationToReject(AppReference);
                _scenarioContext.Add("PTDNumber", PTDNumber);
            }
        }

        [Given(@"Get an application via backend")]
        [Then(@"Get an application via backend")]
        public void ThenGetApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                AppData.GetApplication(AppReference);

            }
        }

        [Given(@"Create an application via backend")]
        [When(@"Create an application via backend")]
        public void ThenCreateApplicationViaBackend()
        {
            lock (_lock)
            {
                string AppId = _applicationSummaryPage.getNewID();
                string APIAppReference = AppData.CreateApplicationAPI(AppId);
                _scenarioContext.Add("ReferenceNumber", APIAppReference);
                Assert.True(AppData.writeApplicationToQueue(), "Pet Application not created through backend");
            }
        }

        [Given(@"Create an application via backend with Other Colour")]
        [When(@"Create an application via backend with Other Colour")]
        public void ThenCreateApplicationViaBackendWithOtherColour()
        {
            lock (_lock)
            {
                string AppId = _applicationSummaryPage.getNewID();
                string APIAppReference = AppData.CreateApplicationAPIWithOtherColour(AppId);
                _scenarioContext.Add("ReferenceNumber", APIAppReference);
                Assert.True(AppData.writeApplicationToQueue(), "Pet Application not created through backend");
            }
        }


        [Given(@"Create an application via backend with significant features option as No")]
        [When(@"Create an application via backend with significant features option as No")]
        public void ThenCreateApplicationViaBackendSigFeaturesNo()
        {
            lock (_lock)
            {
                string AppId = _applicationSummaryPage.getNewID();
                string APIAppReference = AppData.CreateApplicationSigFNoAPI(AppId);
                _scenarioContext.Add("ReferenceNumber", APIAppReference);
                Assert.True(AppData.writeApplicationToQueue(), "Pet Application not created through backend");
            }
        }

        [Given(@"Create an application with Mandatory address only via backend")]
        [When(@"Create an application with Mandatory address only via backend")]
        public void ThenCreateApplicationWithMandatoryAddressViaBackend()
        {
            lock (_lock)
            {
                string AppId = _applicationSummaryPage.getNewID();
                string APIAppReference = AppData.CreateApplicationWithMandatoryAddressFieldsAPI(AppId);
                _scenarioContext.Add("ReferenceNumber", APIAppReference);
                Assert.True(AppData.writeApplicationToQueue(), "Pet Application not created through backend");
            }
        }

        [Then(@"I have captured pet details")]
        [When(@"I have captured pet details")]
        public void ThenIHaveCapturedPetDetails()
        {
            lock (_lock)
            {
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                string PetType = AppData.GetPetDetails(AppReference);
                _scenarioContext.Add("PetType", PetType);
                string MicrochipNumber = AppData.GetMicrochipDetails(AppReference);
                _scenarioContext.Add("MicrochipNumber", MicrochipNumber);
            }
        }

        [Then(@"I verify backend SQL entries for GB Outcome")]
        [When(@"I verify backend SQL entries for GB Outcome")]
        public void ThenIVerifySQLEntriesForGBOutcome()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifyGBOutcomeWithSQLBackend(AppReference), "GB Outcome not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for SPS Outcome '([^']*)','([^']*)'")]
        [When(@"I verify backend SQL entries for SPS Outcome '([^']*)','([^']*)'")]
        public void ThenIVerifySQLEntriesForSPSOutcome(string TypeOfPassenger, string SPSOutcome)
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifySPSOutcomeWithSQLBackend(AppReference, TypeOfPassenger, SPSOutcome), "SPS Outcome not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for GB Summary Table")]
        [When(@"I verify backend SQL entries for GB Summary Table")]
        public void ThenIVerifySQLEntriesForGBSummary()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifyGBSummaryOutputWithSQLBackend(AppReference), "GB Summary not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for SPS Summary Table")]
        [When(@"I verify backend SQL entries for SPS Summary Table")]
        public void ThenIVerifySQLEntriesForSPSSummary()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifySPSSummaryOutputWithSQLBackend(AppReference), "SPS Summary not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for GB Summary Table for Pass appl")]
        [When(@"I verify backend SQL entries for SPS Summary Table for Pass appl")]
        public void ThenIVerifySQLEntriesForSPSSummaryForPassAppl()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifyGBSummaryForPassApplWithSQLBackend(AppReference), "GB Summary not matching with SQL Backend data");
        }

        [Given(@"Create an offline application via backend for '([^']*)'")]
        [When(@"Create an offline application via backend for '([^']*)'")]
        public void ThenCreateOfflineApplicationViaBackend(string Species)
        {
            lock (_lock)
            {
                string randonNumber = Utils.GenerateRandomApplicationNumber();
                string PTDNumber = AppData.writeOfflineApplicationToQueue(randonNumber, Species);
                _scenarioContext.Add("PTDNumber", PTDNumber);
                Console.WriteLine($"PTDNumber: {PTDNumber}");
            }
        }

        [Given(@"I click Accont on Home Page")]
        [When(@"I click Accont on Home Page")]
        public void ThenIClickAccontOnHomePage()
        {
            _applicationSummaryPage.ClickOnAccount();
        }

        [Given(@"Create an application via backend for '([^']*)' with custom values")]
        [When(@"Create an application via backend for '([^']*)' with custom values")]
        public void ThenCreateApplicationViaBackendWithCustomValues(string PetSpecies)
        {
            lock (_lock)
            {
                string AppId = _applicationSummaryPage.getNewID();
                string APIAppReference = AppData.CreateApplicationWithPetCustomValues(AppId, PetSpecies);
                _scenarioContext.Add("ReferenceNumber", APIAppReference);
                Assert.True(AppData.writeApplicationToQueue(), "Pet Application not created through backend");
            }
        }

        [Given(@"verify role '([^']*)' on manage account page")]
        [Then(@"verify role '([^']*)' on manage account page")]
        public void ThenIVerifyRole(string role)
        {
            _applicationSummaryPage.VerifyRole(role);
        }

        [Then(@"I verify backend SQL entries for Suspended Application")]
        [When(@"I verify backend SQL entries for Suspended Application")]
        public void ThenIVerifySQLEntriesForSuspendedApplication()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifySuspendedApplicationWithSQLBackend(AppReference), "Suspended Application Summary not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for Unsuspended Application")]
        [When(@"I verify backend SQL entries for Unsuspended Application")]
        public void ThenIVerifySQLEntriesForUnSuspendedApplication()
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifyUnSuspendedApplicationWithSQLBackend(AppReference), "UnSuspended Application Summary not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for Suspended Application with PTD number")]
        [When(@"I verify backend SQL entries for Suspended Application with PTD number")]
        public void ThenIVerifySQLEntriesForSuspendedApplicationWithPTD()
        {
            string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
            Assert.True(_applicationSummaryPage.VerifySuspendedApplicationWithSQLBackendWithPTD(PTDNumber), "Suspended Application Summary not matching with SQL Backend data");
        }

        [Then(@"I verify backend SQL entries for Unsuspended Application with PTD number")]
        [When(@"I verify backend SQL entries for Unsuspended Application with PTD number")]
        public void ThenIVerifySQLEntriesForUnSuspendedApplicationWithPTD()
        {
            string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
            Assert.True(_applicationSummaryPage.VerifyUnSuspendedApplicationWithSQLBackendWithPTD(PTDNumber), "UnSuspended Application Summary not matching with SQL Backend data");
        }

        [Then(@"I should see the suspended application warning '([^']*)'")]
        [When(@"I should see the suspended application warning '([^']*)'")]
        public void ThenIShouldSeeTheSuspendedApplicationWarning(string SuspendedApplicationWarning)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheSuspendedApplicationWarning(SuspendedApplicationWarning), "The Suspended Application warning is not as expected");
        }

        [Then(@"I verify continue button not displayed on search result page")]
        [When(@"I verify continue button not displayed on search result page")]
        public void ThenIVerifyContinueButtonNotDisplayedOnSearchResultPage()
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheContinueButtonNotDisplayed(), "Continue button should not displayed on Search Result page");
        }

        [Then(@"I verify pass button not displayed on search result page")]
        [When(@"I verify pass button not displayed on search result page")]
        public void ThenIVerifyPassButtonNotDisplayedOnSearchResultPage()
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyThePassButtonNotDisplayed(), "Pass button should not displayed on Search Result page");
        }

        [Then(@"I verify fail button not displayed on search result page")]
        [When(@"I verify fail button not displayed on search result page")]
        public void ThenIVerifyFailButtonNotDisplayedOnSearchResultPage()
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyTheFailButtonNotDisplayed(), "Fail button should not displayed on Search Result page");
        }
    }
}

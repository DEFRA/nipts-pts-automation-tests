using Reqnroll.BoDi;
using nipts_pts_API_tests.Application;
using nipts_pts_API_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
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

        /// <summary>
        /// Lazily acquires the backend / pts-pet-checker bearer tokens before a backend call. CP
        /// flows mint these on the route-checker page, but applicant-only flows never visit it, so
        /// without this the checker calls go out unauthenticated and fail with 401.
        /// </summary>
        private void EnsureBackendTokens()
        {
            BackendTokenProvider.EnsureTokens(_driver);
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

        [Then(@"I select Refer to SPS radio button")]
        [When(@"I select Refer to SPS radio button")]
        public void WhenISelectReferToSPSRadioButton()
        {
            _applicationSummaryPage?.SelectReferToSPSRadioButton();
        }

        [Then(@"I select Issue SUPTD radio button")]
        [When(@"I select Issue SUPTD radio button")]
        public void WhenISelectIssueSUPTDRadioButton()
        {
            _applicationSummaryPage?.SelectIssueSUPTDRadioButton();
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
                EnsureBackendTokens();
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
                EnsureBackendTokens();
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
                EnsureBackendTokens();
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
                EnsureBackendTokens();
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
                EnsureBackendTokens();
                string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
                AppData.GetAuthorisedApplicationToSuspend(PTDNumber);
            }
        }

        [Given(@"Authorise application with Id '([^']*)' via backend")]
        [When(@"Authorise application with Id '([^']*)' via backend")]
        [Then(@"Authorise application with Id '([^']*)' via backend")]
        public async Task ThenAuthoriseApplicationWithIdViaBackend(string applicationId)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(applicationId), "An applicationId must be provided to authorise an application.");

            string queueName = ServiceBusConnectionData.Configuration.ServiceBusQueueName;
            string todaysDate = DateTime.Now.ToString("yyyy-MM-dd");
            string dynamicId = Guid.NewGuid().ToString();

            // IMPORTANT: the trailing space in "Application.Id " is REQUIRED. The backend queue
            // consumer keys off that exact property name and silently ignores the message without
            // it, leaving the application stuck in 'AWAITING VERIFICATION'. Do not "tidy" it away.
            string messageBody = $"{{ \"Application.Id \": \"{applicationId}\", \"Application.DynamicId\": \"{dynamicId}\", \"Application.StatusId\": \"Authorised\", \"Application.DateAuthorised\": \"{todaysDate}\" }}";

            Console.WriteLine($"Sending Authorise message for ApplicationId: {applicationId} to queue: {queueName}");
            await ServiceBusConnection.SendMessageToQueue(messageBody, queueName);
            Console.WriteLine($"Authorise message sent for ApplicationId: {applicationId}");
        }

        [When(@"Revoke an application via backend")]
        [Then(@"Revoke an application via backend")]
        public void ThenRevokeApplicationViaBackend()
        {
            lock (_lock)
            {
                EnsureBackendTokens();
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
                EnsureBackendTokens();
                string PTDNumber = _scenarioContext.Get<string>("PTDNumber");
                AppData.RevokeApprovedApplication(PTDNumber);
            }
        }

        [When(@"Reject an application via backend")]
        public void ThenRejectApplicationViaBackend()
        {
            lock (_lock)
            {
                EnsureBackendTokens();
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
                EnsureBackendTokens();
                string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
                AppData.GetApplication(AppReference);

            }
        }

        /// <summary>
        /// Shared backend application-creation flow: generates the app id, invokes the supplied
        /// create call, stores the returned reference for later steps, then performs the queue
        /// write. The queue write is treated as optional - the application itself is already
        /// created, and the downstream dynamic-integration writetoqueue endpoint can return a
        /// transient 500 - so a failure is logged as a warning rather than failing the scenario.
        /// </summary>
        private void CreateApplicationViaBackend(Func<string, string> createApplication)
        {
            lock (_lock)
            {
                string appId = _applicationSummaryPage.getNewID();
                string apiAppReference = createApplication(appId);
                _scenarioContext.Add("ReferenceNumber", apiAppReference);

                // Queue write is optional - log warning if it fails but continue
                if (!AppData.writeApplicationToQueue())
                {
                    Console.WriteLine("WARNING: writeApplicationToQueue failed, but application was created. Continuing...");
                }
            }
        }

        [Given(@"Create an application via backend")]
        [When(@"Create an application via backend")]
        public void ThenCreateApplicationViaBackend()
        {
            CreateApplicationViaBackend(AppData.CreateApplicationAPI);
        }

        [Given(@"Create an application via backend with Other Colour")]
        [When(@"Create an application via backend with Other Colour")]
        public void ThenCreateApplicationViaBackendWithOtherColour()
        {
            CreateApplicationViaBackend(AppData.CreateApplicationAPIWithOtherColour);
        }


        [Given(@"Create an application via backend with significant features option as No")]
        [When(@"Create an application via backend with significant features option as No")]
        public void ThenCreateApplicationViaBackendSigFeaturesNo()
        {
            CreateApplicationViaBackend(AppData.CreateApplicationSigFNoAPI);
        }

        [Given(@"Create an application with Mandatory address only via backend")]
        [When(@"Create an application with Mandatory address only via backend")]
        public void ThenCreateApplicationWithMandatoryAddressViaBackend()
        {
            CreateApplicationViaBackend(AppData.CreateApplicationWithMandatoryAddressFieldsAPI);
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

        [Then(@"I verify backend SQL entries for SPS Outcome '([^']*)','([^']*)','([^']*)'")]
        [When(@"I verify backend SQL entries for SPS Outcome '([^']*)','([^']*)','([^']*)'")]
        public void ThenIVerifySQLEntriesForSPSOutcome(string TypeOfPassenger, string SPSOutcome, string DetailsOfOutCome)
        {
            string AppReference = _scenarioContext.Get<string>("ReferenceNumber");
            Assert.True(_applicationSummaryPage.VerifySPSOutcomeWithSQLBackend(AppReference, TypeOfPassenger, SPSOutcome, DetailsOfOutCome), "SPS Outcome not matching with SQL Backend data");
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
            CreateApplicationViaBackend(appId => AppData.CreateApplicationWithPetCustomValues(appId, PetSpecies));
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

        [Then(@"I verify warning message on search results page for status '([^']*)'")]
        [When(@"I verify warning message on search results page for status '([^']*)'")]
        public void ThenIVerifyWarningMessageOnSearchResultPage(string status)
        {
            Assert.IsTrue(_applicationSummaryPage?.VerifyWarningMessageOnSearchResultPage(status), "Waring message not matching on Search Result page");
        }
    }
}

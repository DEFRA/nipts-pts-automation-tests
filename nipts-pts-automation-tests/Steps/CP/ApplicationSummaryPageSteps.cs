﻿using Reqnroll.BoDi;
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

        [When(@"Revoke an application via backend")]
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
        [When(@"Get an application via backend")]
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
    }
}

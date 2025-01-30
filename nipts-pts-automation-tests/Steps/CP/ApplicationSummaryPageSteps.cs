using BoDi;
using nipts_pts_API_tests.Application;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

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


    }
}

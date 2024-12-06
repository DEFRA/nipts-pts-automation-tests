using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]

    public class SearchDocumentPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPage? summaryPage => _objectContainer.IsRegistered<ISummaryPage>() ? _objectContainer.Resolve<ISummaryPage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISearchDocumentPage? _searchDocumentPage => _objectContainer.IsRegistered<ISearchDocumentPage>() ? _objectContainer.Resolve<ISearchDocumentPage>() : null;
        private IReportNonCompliancePage? _reportNonCompliancePage => _objectContainer.IsRegistered<IReportNonCompliancePage>() ? _objectContainer.Resolve<IReportNonCompliancePage>() : null;

        public SearchDocumentPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I navigate to Find a document page")]
        public void ThenINavigateToFindADocumentPage()
        {
            Assert.True(_searchDocumentPage?.IsPageLoaded(), "Find a document page not loaded");
        }

        [Then(@"I provided the PTD number of the application")]
        public void ThenIProvidedThePTDNumberOfTheApplication()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumber1 = ptdNumber.Substring(5);
            _searchDocumentPage?.EnterPTDNumber(ptdNumber1);
        }

        [Then(@"I provided the Reference number of the application")]
        public void ThenIProvidedTheReferenceNumberOfTheApplication()
        {
            var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I provided the Microchip number of the application")]
        public void ThenIProvidedTheMicrochipNumberOfTheApplication()
        {
            var microchipNumber = _scenarioContext.Get<string>("MicrochipNumber");
            _searchDocumentPage?.EnterMicrochipNumber(microchipNumber);
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            _searchDocumentPage?.SearchButton();
        }

        [When(@"I click clear search button")]
        public void WhenIClickClearSearchButton()
        {
            _searchDocumentPage?.ClearSearchButton();
        }

        [Then(@"I provided the '([^']*)' of the application")]
        public void ThenIProvidedTheOfTheApplication(string ptdNumber)
        {
            _searchDocumentPage?.EnterPTDNumber(ptdNumber);
        }

        [Then(@"I provided the Reference number '([^']*)' of the application")]
        public void ThenIProvidedTheReferenceNumberOfTheApplication(string referenceNumber)
        {
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I provided the Microchip number '([^']*)' of the application")]
        public void ThenIProvidedTheMicrochipNumberOfTheApplication(string microchipNumber)
        {
            _searchDocumentPage?.EnterMicrochipNumber(microchipNumber);
        }

        [Then(@"I click search by '([^']*)' radio button")]
        public void ThenIClickSearchByRadioButton(string radioButton)
        {
            _searchDocumentPage?.SelectSearchRadioOption(radioButton);
        }

        [Then(@"I provided the Application Number '([^']*)' of the application")]
        public void ThenIProvidedTheApplicationNumberOfTheApplication(string referenceNumber)
        {
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I should see an error message ""([^""]*)"" in Find a document page")]
        public void ThenIShouldSeeAnErrorMessageInFindADocumentPage(string errorMessage)
        {
            Assert.True(_searchDocumentPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I provided the Invalid PTD number of the application")]
        public void ThenIProvidedTheInvalidPTDNumberOfTheApplication()
        {
            var ptdNumber1 = "'-'";
         //   var ptdNumber1 = ptdNumber.Substring(5);
            _searchDocumentPage?.EnterPTDNumber(ptdNumber1);
        }

        [Then(@"I provided the Invalid Reference number of the application")]
        public void ThenIProvidedTheInvalidReferenceNumberOfTheApplication()
        {
            var referenceNumber = "'-'";
            _searchDocumentPage?.EnterApplicationNumber(referenceNumber);
        }

        [Then(@"I provided the Invalid Microchip number of the application")]
        public void ThenIProvidedTheInvalidMicrochipNumberOfTheApplication()
        {
            var microchipNumber = "'-'";
            _searchDocumentPage?.EnterMicrochipNumber(microchipNumber);
        }

    }
}

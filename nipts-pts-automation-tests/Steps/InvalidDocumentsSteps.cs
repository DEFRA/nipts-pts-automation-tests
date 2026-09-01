using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class InvalidDocumentsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationPage applicationPage => _objectContainer.Resolve<IApplicationPage>();
        private IDataHelperConnections dataHelperConnections => _objectContainer.Resolve<IDataHelperConnections>();
        private IInvalidDocumentsPage invalidDocumentsPage => _objectContainer.Resolve<IInvalidDocumentsPage>();

        public InvalidDocumentsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click View Invalid documents link in WELSH")]
        [Then(@"click View Invalid documents link in WELSH")]
        public void ClickOnViewInvalidDocLink()
        {
            invalidDocumentsPage.ClickOnViewInvalidDocumentLinkWELSH();
        }

        [When(@"I have clicked the View hyperlink from invalid documents page")]
        public void WhenIHaveClickedTheViewHyperlinkFromInvalidDocPage()
        {
            var petName = _scenarioContext.Get<string>("PetName");
            invalidDocumentsPage?.ClickViewLnkInvalidDocPage(petName);
        }

        [Then(@"verify status on the application summary as '([^']*)' '([^']*)' on Invalid documents page")]
        public void ThenVerifyStatusOnInvalidDocWELSH(string fieldName, string fieldValue)
        {
            Assert.True(invalidDocumentsPage?.VerifyStatusOnInvalidDocsPTDWELSH(fieldName, fieldValue), "Status mistmatch on Pending application");
        }

        [Then(@"verify order of new application is displayed at the top of the page")]
        public void ThenVerifyOrderOfNewApplOnInvalidDocWELSH()
        {
            var petName = _scenarioContext.Get<string>("PetName");
            Assert.True(invalidDocumentsPage?.VerifyNewApplInvalidPage(petName), "Order mismatch for New application on Invalid Doc Page");
        }
    }
}

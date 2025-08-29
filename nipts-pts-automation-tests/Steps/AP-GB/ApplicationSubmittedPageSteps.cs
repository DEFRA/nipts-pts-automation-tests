using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.ApplicationSubmittedPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class ApplicationSubmittedPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationSubmissionPage? ApplicationSubmittedPage => _objectContainer.IsRegistered<IApplicationSubmissionPage>() ? _objectContainer.Resolve<IApplicationSubmissionPage>() : null;
        public ApplicationSubmittedPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should redirect to the Application submitted page")]
        public void ThenIShouldRedirectToTheApplicationSubmittedPage()
        {
            var pageTitle = "Application submitted";
            Assert.IsTrue(ApplicationSubmittedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I verify application submitted page title '([^']*)'")]
        [Then(@"I verify application submitted page title '([^']*)'")]
        public void ThenIVerifyApplicationSubmittedPageTitle()
        {
            var pageTitle = "Application submitted";
            Assert.IsTrue(ApplicationSubmittedPage?.VerifyApplicationSubmittedPageTitle(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I can see the application reference number")]
        public void ThenICanSeeTheApplicationReferenceNumber()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(ApplicationSubmittedPage?.GetApplicationReferenceNumber()), "There is an issue with application submission");
        }

    }
}

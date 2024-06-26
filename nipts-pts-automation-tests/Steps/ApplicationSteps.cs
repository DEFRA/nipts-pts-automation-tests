using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;

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

        [Then(@"verify next page '([^']*)' is loaded")]
        public void ThenVerifyNextPageIsLoaded(string pageName)
        {
            Assert.True(applicationPage.VerifyNextPageIsLoaded(pageName), "Expected page not loaded");
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
            Assert.True(applicationPage.VerifyErrorMessage(errorMessage), "Full Name error message not matching");
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
    }
}

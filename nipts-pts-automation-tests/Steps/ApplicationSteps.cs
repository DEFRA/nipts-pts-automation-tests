using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using nipts_pts_automation_tests.Data;
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
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

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

        [Then(@"verify displayed language at page footer '([^']*)'")]
        public void ThenVerifySignOutTextInSelectedLanguage(string DisplayedLang)
        {
            Assert.True(applicationPage.VerifyLanguageAtPageFooter(DisplayedLang), "Displayed language not matching at page footer");
        }

        [Then(@"I should navigate to Manage account")]
        public void ThenIShouldNavigateToManageAccount()
        {
            applicationPage.ClickOnManageAccountLink();
        }

        [Then(@"I click on Manage your account")]
        public void ThenIClickOnManageYourAccount()
        {
            applicationPage.ClickOnManageYourAccountLink();
        }

        [Then(@"click on View your pet travel documents or apply new one")]
        public void ClickOnViewYourPetDocumentFromManageYourAccount()
        {
            applicationPage.ClickOnViewYourPetTravelDoc();
        }
    }
}

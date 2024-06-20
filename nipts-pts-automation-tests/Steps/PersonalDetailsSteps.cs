using BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]
    public class PersonalDetailsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPersonalDetailsPage? personalDetailsPage => _objectContainer.IsRegistered<IPersonalDetailsPage>() ? _objectContainer.Resolve<IPersonalDetailsPage>() : null;

        public PersonalDetailsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on continue")]
        [Then(@"click on continue")]
        public void ThenClickOnContinue()
        {
            personalDetailsPage.ClickOnContinue();
        }

        [When(@"click on back")]
        [Then(@"click on back")]
        public void ThenClickOnBack()
        {
            personalDetailsPage.ClickOnBack();
        }

        [Then(@"verify Personal Details for user '([^']*)'")]
        public void ThenVerifyPersonalDetails(string user)
        {
            personalDetailsPage.VerifyPersonalDetails(user);
        }

        [When(@"select '([^']*)' on Personal Details page")]
        public void ThenSelectOptionOnPersonalDetailsPage(string option)
        {
            personalDetailsPage.SelectOptionOnPersonalDetailsPage(option);
        }

    }
}

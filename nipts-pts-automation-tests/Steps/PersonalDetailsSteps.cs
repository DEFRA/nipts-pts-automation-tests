using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]
    public class PersonalDetailsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationPage applicationPage => _objectContainer.Resolve<IApplicationPage>();
        private IDataHelperConnections dataHelperConnections => _objectContainer.Resolve<IDataHelperConnections>();
        private IPersonalDetailsPage personalDetailsPage => _objectContainer.Resolve<IPersonalDetailsPage>();

        public PersonalDetailsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }


        [Then(@"verify Personal Details for user '([^']*)'")]
        public void ThenVerifyPersonalDetails(string userType)
        {
            Assert.True(personalDetailsPage.VerifyPersonalDetails(userType),"Personal details not matching");
        }

        [When(@"select '([^']*)' on Personal Details page")]
        public void ThenSelectOptionOnPersonalDetailsPage(string option)
        {
            personalDetailsPage.SelectOptionOnPersonalDetailsPage(option);
        }

        [Then(@"verify error message '([^']*)' on Personal Details page")]
        public void ThenVerifyErrorMessageOnPersonalDetailsPage(string errorMessage)
        {
            Assert.True(personalDetailsPage.VerifyErrorMessageOnPersonalDetailsPage(errorMessage), "Invalid error on Personal Details Page");
        }

    }
}

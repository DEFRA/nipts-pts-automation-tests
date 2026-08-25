using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class FullNameSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationPage applicationPage => _objectContainer.Resolve<IApplicationPage>();
        private IFullNamePage fullNamePage => _objectContainer.Resolve<IFullNamePage>();

        public FullNameSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"enter your full name '([^']*)'")]
        public void WhenEnterYourFullName(string fullName)
        {
            fullNamePage.EnterFullName(fullName);
        }

        [Then(@"verify error message '([^']*)' on Pets full name page")]
        public void ThenVerifyErrorMessageOnPetsFullNamePage(string errorMessage)
        {
            Assert.True(fullNamePage.ThenVerifyErrorMessageOnPetsFullNamePage(errorMessage), "Full Name error message not matching");
        }


    }
}

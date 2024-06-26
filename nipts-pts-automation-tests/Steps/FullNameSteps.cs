using BoDi;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class FullNameSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IFullNamePage? fullNamePage => _objectContainer.IsRegistered<IFullNamePage>() ? _objectContainer.Resolve<IFullNamePage>() : null;

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

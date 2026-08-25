using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PhoneNumberSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationPage applicationPage => _objectContainer.Resolve<IApplicationPage>();
        private IPhoneNumberPage phoneNumberPage => _objectContainer.Resolve<IPhoneNumberPage>();

        public PhoneNumberSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"enter phone number '([^']*)'")]
        public void WhenEnterphoneNumber(string phoneNumber)
        {
            phoneNumberPage.EnterPhoneNumber(phoneNumber);
        }

        [Then(@"verify error message '([^']*)' on Pets telephone number page")]
        public void ThenVerifyErrorMessageOnPetsTelephoneNumberPage(string errorMessage)
        {
            Assert.True(phoneNumberPage.VerifyErrorMessageOnPetsTelephoneNumberPage(errorMessage), "Telephone number error message not matching");
        }


    }
}

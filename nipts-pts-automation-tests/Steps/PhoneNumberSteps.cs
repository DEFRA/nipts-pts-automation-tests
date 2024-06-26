using BoDi;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PhoneNumberSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IPhoneNumberPage? phoneNumberPage => _objectContainer.IsRegistered<IPhoneNumberPage>() ? _objectContainer.Resolve<IPhoneNumberPage>() : null;

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

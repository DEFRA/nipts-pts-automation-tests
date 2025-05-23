﻿using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetNameSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPetNamePage? petNamePage => _objectContainer.IsRegistered<IPetNamePage>() ? _objectContainer.Resolve<IPetNamePage>() : null;

        public PetNameSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Enter name of your pet '([^']*)'")]
        [Then(@"Enter name of your pet '([^']*)'")]
        public void WhenEnterNameOfPet(string petName)
        {
            petNamePage.EnterNameOfPet(petName);
            _scenarioContext.Add("PetName", petName);
        }

        [Then(@"verify error message '([^']*)' on enter pet name")]
        public void ThenVerifyErrorMessageOnSelectSexOfPetPage(string errorMessage)
        {
            Assert.True(petNamePage.VerifyErrorMessageOnEnterPetNamePage(errorMessage), "Invalid error on enter pet name page");
        }
    }
}

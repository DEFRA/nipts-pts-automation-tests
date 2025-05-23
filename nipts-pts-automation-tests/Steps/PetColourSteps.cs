﻿using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PetColourSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IPetColourPage? petcolorPage => _objectContainer.IsRegistered<IPetColourPage>() ? _objectContainer.Resolve<IPetColourPage>() : null;    
        public PetColourSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"Select pet color as '([^']*)'")]
        public void ThenIHaveSelectedTheOptionAsForColor(string color)
        {
            petcolorPage.SelectColorOption(color);
            
        }

        [Then(@"verify error message '([^']*)' on pet color page")]
        public void ThenVerifyErrorMessageOnPetColorPage(string errorMessage)
        {
            Assert.True(petcolorPage.VerifyErrorMessageOnPetColorPage(errorMessage), "Invalid error on select color of pet Page");
        }

        [When(@"Enter text in Other color '([^']*)' option")]
        [Then(@"Enter text in Other color '([^']*)' option")]
        public void WhenOtherColorOfPet(string petColour)
        {
            petcolorPage.EnterOtherColorText(petColour);
        }
    }
}

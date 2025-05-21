using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPNumberPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class PetOwnerPNumberPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerPhoneNumberPage? PetOwnerPNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;
        public PetOwnerPNumberPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner phone number page")]
        public void ThenIShouldNavigateToPetsOwnerPhoneNumberPage()
        {
            var pageTitle = $"What is your phone number?";
            Assert.IsTrue(PetOwnerPNumberPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provide Pets Owner '([^']*)' and continue")]
        public void WhenIProvidePetsOwnerAndContinue(string phoneNumber)
        {
            PetOwnerPNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            PetOwnerPNumberPage?.ClickContinueButton();
        }

    }
}

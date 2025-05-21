using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerNamePage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class PetOwnerNamePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerNamePage? PetOwnerNamePage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        public PetOwnerNamePageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner full name page")]
        public void ThenIShouldNavigateToPetsOwnerFullNamePage()
        {
            var pageTitle = $"What is your full name?";
            Assert.IsTrue(PetOwnerNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provided '([^']*)' and continue")]
        public void WhenIProvidedAndContinue(string userName)
        {
            PetOwnerNamePage?.EnterPetOwnerName(userName);
            PetOwnerNamePage?.ClickContinueButton();
        }

    }
}

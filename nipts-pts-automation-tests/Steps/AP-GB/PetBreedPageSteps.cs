using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetBreedPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetBreedPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetsBreedPage? PetBreedPage => _objectContainer.IsRegistered<IPetsBreedPage>() ? _objectContainer.Resolve<IPetsBreedPage>() : null;
        public PetBreedPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to What breed is your '([^']*)' page")]
        public void ThenIShouldNavigateToWhatBreedIsYourPage(string petType)
        {
            var pageTitle = $"What breed is your {petType.ToLower()}?";
            Assert.IsTrue(PetBreedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected from the dropdown as '([^']*)' for pet's and continue")]
        public void ThenIHaveSelectedFromTheDropdownAsForPetsAndContinue(string petBreed)
        {
            PetBreedPage?.EnterFreeTextBreed(petBreed);
            PetBreedPage?.ClickContinueButton();
        }

    }
}

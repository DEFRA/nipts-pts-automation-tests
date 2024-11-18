using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetSpeciesPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetCategoryPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetsSpeciesPage? PetCategoryPage => _objectContainer.IsRegistered<IPetsSpeciesPage>() ? _objectContainer.Resolve<IPetsSpeciesPage>() : null;
        public PetCategoryPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Is your pet a cat, dog or ferret page")]
        public void ThenIShouldNavigateToTheIsYourPetACatDogOrFerretPage()
        {
            var pageTitle = "Is your pet a dog, cat or ferret?";
            Assert.IsTrue(PetCategoryPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected radio button as '([^']*)' and continue")]
        public void ThenIHaveSelectedRadioButtonAsAndContinue(string petsType)
        {
            PetCategoryPage?.SelectSpecies(petsType);
            PetCategoryPage?.ClickContinueButton();
        }

    }
}

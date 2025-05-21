using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetColourPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetColourPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetsColourPage? PetColourPage => _objectContainer.IsRegistered<IPetsColourPage>() ? _objectContainer.Resolve<IPetsColourPage>() : null;
        public PetColourPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldNavigateToTheWhatIsTheMainColourOfYourPage(string petType)
        {
            var pageTitle = $"What is the main colour of your {petType.ToLower()}?";
            Assert.IsTrue(PetColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected the radio button as '([^']*)' for pet's")]
        public void WhenIHaveSelectedTheRadioButtonAsForPets(string colourOption)
        {
            PetColourPage?.SelectColorOption(colourOption);
        }

        [When(@"I have selected the radio button as '(.*)' for pet's and continue")]
        public void WhenIHaveSelectedTheRadioButtonAsForPetsAndContinue(string colourOption)
        {
            PetColourPage?.SelectColorOption(colourOption);
            PetColourPage?.ClickContinueButton();
        }

    }
}

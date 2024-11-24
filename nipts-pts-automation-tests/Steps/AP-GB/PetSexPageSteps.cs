using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetSexPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class PetSexPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetsSexPage? PetSexPage => _objectContainer.IsRegistered<IPetsSexPage>() ? _objectContainer.Resolve<IPetsSexPage>() : null;
        public PetSexPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the What sex is your pet page")]
        public void ThenIShouldNavigateToTheWhatSexIsYourPetPage()
        {
            var pageTitle = "What sex is your pet?";
            Assert.IsTrue(PetSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have selected the radio button as '([^']*)' for sex option and continue")]
        public void WhenIHaveSelectedTheRadioButtonAsForSexOptionAndContinue(string sexType)
        {
            PetSexPage?.SelectPetsSexOption(sexType);
            PetSexPage?.ClickContinueButton();
        }

    }
}

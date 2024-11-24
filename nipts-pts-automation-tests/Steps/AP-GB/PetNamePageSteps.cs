using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetNamePage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetNamePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetsNamePage? PetNamePage => _objectContainer.IsRegistered<IPetsNamePage>() ? _objectContainer.Resolve<IPetsNamePage>() : null;
        public PetNamePageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the What is your pet's name page")]
        public void ThenIShouldNavigateToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(PetNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided the Pets name as '([^']*)' and continue")]
        public void ThenIHaveProvidedThePetsNameAsAndContinue(string petName)
        {
            PetNamePage?.EnterPetsName(petName);
            PetNamePage?.ClickContinueButton();
        }

    }
}

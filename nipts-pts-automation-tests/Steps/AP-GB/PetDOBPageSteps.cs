using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetDOBPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetDOBPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetDOBPage? PetDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        public PetDOBPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Do you know your pet's date of birth page")]
        public void ThenIShouldNavigateToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(PetDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I have provided date of birth for pet and continue")]
        public void WhenIHaveProvidedDateOfBirthForPetAndContinue()
        {
            PetDOBPage?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            PetDOBPage?.ClickContinueButton();
        }

    }
}

using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressManuallyPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetOwnerAddressManuallyPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerAddressManuallyPage? PetOwnerAddressManuallyPage => _objectContainer.IsRegistered<IPetOwnerAddressManuallyPage>() ? _objectContainer.Resolve<IPetOwnerAddressManuallyPage>() : null;
        public PetOwnerAddressManuallyPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner manually address page")]
        public void ThenIShouldNavigateToPetsOwnerManuallyAddressPage()
        {
            var pageTitle = $"What is your address?";
            Assert.IsTrue(PetOwnerAddressManuallyPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I fill in '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'and continue")]
        public void WhenIFillInAndContinue(string firstLine, string secondLine, string city, string county, string postCode)
        {
            PetOwnerAddressManuallyPage?.EnterAddressManually(firstLine, secondLine, city, county, postCode);
            PetOwnerAddressManuallyPage?.ClickContinueButton();
        }

    }
}

using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPostCodePage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class PetOwnerPostCodePageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IPetOwnerPostCodePage? PetOwnerPostCodePage => _objectContainer.IsRegistered<IPetOwnerPostCodePage>() ? _objectContainer.Resolve<IPetOwnerPostCodePage>() : null;
        public PetOwnerPostCodePageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to Pets Owner address postcode page")]
        public void ThenIShouldNavigateToPetsOwnerAddressPostcodePage()
        {
            var pageTitle = $"What is your postcode?";
            Assert.IsTrue(PetOwnerPostCodePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provide Pets Owner '([^']*)' and click find address")]
        public void WhenIProvidePetsOwnerAndClickFindAddress(string postCode)
        {
            PetOwnerPostCodePage?.EnterPetOwnerPostCode(postCode);
            PetOwnerPostCodePage?.ClickFindAddressButton();
        }

        [When(@"I I click on Enter the address manually link from postcode page")]
        public void WhenIIClickOnEnterTheAddressManuallyLinkFromPostcodePage()
        {
            PetOwnerPostCodePage?.ClickManuallyAddressLink();
        }

    }
}

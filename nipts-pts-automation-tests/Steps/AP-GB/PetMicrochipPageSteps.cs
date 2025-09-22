using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipPage;
using NUnit.Framework;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetMicrochipPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IPetMicrochipPage? _petMicrochipPage => _objectContainer.IsRegistered<IPetMicrochipPage>() ? _objectContainer.Resolve<IPetMicrochipPage>() : null;
        public PetMicrochipPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the Is your pet microchipped page")]
        public void ThenIShouldNavigateToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "Is your pet microchipped?";
            Assert.IsTrue(_petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I selected the radio button '([^']*)' option")]
        public void ThenISelectedTheRadioButtonOption(string option)
        {
            _petMicrochipPage?.SelectMicrochippedOption(option);
        }

        [Then(@"provided microchip number as'([^']*)' and continue")]
        public void ThenProvidedMicrochipNumberAsAndContinue(string microchipNumber)
        {
            _petMicrochipPage?.EnterMicrochipNumber();
            _petMicrochipPage?.ClickContinueButton();
        }

    }
}

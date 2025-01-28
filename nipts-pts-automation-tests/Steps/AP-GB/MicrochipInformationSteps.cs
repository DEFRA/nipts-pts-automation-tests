using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.GetYourPetMicrochippedPage;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipDatePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipPage;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class MicrochipInformationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        private IPetMicrochipPage? petMicrochipPage => _objectContainer.IsRegistered<IPetMicrochipPage>() ? _objectContainer.Resolve<IPetMicrochipPage>() : null;
        private IPetMicrochipDatePage? petMicrochipDatePage => _objectContainer.IsRegistered<IPetMicrochipDatePage>() ? _objectContainer.Resolve<IPetMicrochipDatePage>() : null;
        private IGetYourPetMicrochippedPage? getYourPetMicrochippedPage => _objectContainer.IsRegistered<IGetYourPetMicrochippedPage>() ? _objectContainer.Resolve<IGetYourPetMicrochippedPage>() : null;

        public MicrochipInformationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to Apply for a pet travel document page")]
        public void ThenIShouldRedirectedToApplyForAPetTravelDocumentPage()
        {
            Assert.True(homePage?.IsPageLoaded(), "Apply for a pet travel document not loaded");
        }

        [When(@"I click Create a new pet travel document button")]
        public void WhenIClickCreateANewPetTravelDocumentButton()
        {
            homePage?.ClickApplyForPetTravelDocument();

            Thread.Sleep(2000);
        }

        [Then(@"I should redirected to the Is your pet microchipped page")]
        public void ThenIShouldRedirectedToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "Is your pet microchipped?";
            Assert.IsTrue(petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I selected the '([^']*)' option on pets")]
        public void ThenISelectedTheOption(string option)
        {
            petMicrochipPage?.SelectMicrochippedOption(option);
        }

        [Then(@"I provided microchip number as '([^']*)' on pets")]
        public void ThenProvidedMicrochipNumberAsOnPets(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", petMicrochipPage?.EnterMicrochipNumber());
        }

        [Then(@"enter microchip number as (.*)")]
        public void ThenEnterMicrochipNumberAs(string microchipNumber)
        {
            _scenarioContext.Add("MicrochipNumber", petMicrochipPage?.EnterGivenMicrochipNumber(microchipNumber));
        }

        [When(@"I click Continue button from microchipped page")]
        public void WhenIClickContinueButtonFromMicrochippedPage()
        {
            petMicrochipPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to When was your pet microchipped or last scanned page")]
        public void ThenIShouldRedirectedToWhenWasYourPetMicrochippedOrLastScannedPage()
        {
            var pageTitle = "When was your pet microchipped or last scanned?";
            Assert.IsTrue(petMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided date of PETS microchipped on pets")]
        public void ThenIHaveProvidedDateOfPETSMicrochipped()
        {
            var microchippedDate = petMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddYears(-3));
            _scenarioContext.Add("MicrochippedDate", microchippedDate);
        }

        [When(@"I click Continue button from When was your pet microchipped page")]
        public void WhenIClickContinueButtonFromWhenWasYourPetMicrochippedPage()
        {
            petMicrochipDatePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Get your pet microchipped before applying page")]
        public void ThenIShouldRedirectedToTheGetYourPetMicrochippedBeforeApplyingPage()
        {
            var pageTitle = "Get your pet microchipped before applying";
            Assert.IsTrue(getYourPetMicrochippedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

    }
}

using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.PetBreedPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetColourPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetDOBPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetNamePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetSexPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetSpeciesPage;
using nipts_pts_automation_tests.Pages.AP_GB.SignificantFeaturesPage;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]

    public class PetDetailsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IPetsSpeciesPage? petSpeciesPage => _objectContainer.IsRegistered<IPetsSpeciesPage>() ? _objectContainer.Resolve<IPetsSpeciesPage>() : null;
        private IPetsBreedPage? breedPage => _objectContainer.IsRegistered<IPetsBreedPage>() ? _objectContainer.Resolve<IPetsBreedPage>() : null;
        private IPetsNamePage? petNamePage => _objectContainer.IsRegistered<IPetsNamePage>() ? _objectContainer.Resolve<IPetsNamePage>() : null;
        private IPetsSexPage? petSexPage => _objectContainer.IsRegistered<IPetsSexPage>() ? _objectContainer.Resolve<IPetsSexPage>() : null;
        private IPetDOBPage? petDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        private IPetsColourPage? petColourPag => _objectContainer.IsRegistered<IPetsColourPage>() ? _objectContainer.Resolve<IPetsColourPage>() : null;
        private ISignificantFeaturesPage? significantFeaturesPage => _objectContainer.IsRegistered<ISignificantFeaturesPage>() ? _objectContainer.Resolve<ISignificantFeaturesPage>() : null;

        public PetDetailsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to the Is your pet a cat, dog or ferret page")]
        public void ThenIShouldRedirectedToTheIsYourPetACatDogOrFerretPage()
        {
            var pageTitle = "Is your pet a dog, cat or ferret?";
            Assert.IsTrue(petSpeciesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for pet")]
        public void ThenIHaveSelectedAnOptionAsForPet(string petType)
        {
            petSpeciesPage?.SelectSpecies(petType);
            _scenarioContext.Add("PetType", petType);
        }

        [When(@"I click on continue button from Is your pet a cat, dog or ferret page")]
        public void WhenIClickOnContinueButtonFromIsYourPetACatDogOrFerretPage()
        {
            petSpeciesPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What breed is your '([^']*)'? page")]
        public void ThenIShouldRedirectedToTheWhatBreedIsYourPage(string petType)
        {
            if (!petType.ToLower().Equals("ferret"))
            {
                var pageTitle = $"What breed is your {petType.ToLower()}?";
                Assert.IsTrue(breedPage.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
            }
        }

        [Then(@"I have selected (.*) as breed index from breed dropdownlist")]
        public void ThenIHaveSelectedAsBreedIndexFromBreedDropdownlist(int breedIndex)
        {
            var breed = breedPage?.SelectPetsBreed(breedIndex);
            _scenarioContext.Add("Breed", breed);
        }

        [Then(@"I have provided freetext breed as '([^']*)'")]
        public void ThenIHaveProvidedFreetextBreedAs(string breed)
        {
            breedPage?.EnterFreeTextBreed(breed);
            _scenarioContext.Add("Breed", breed);
        }

        [When(@"I click on continue button from What is your pet's breed page")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetssBreedPage()
        {
            breedPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What is your pet's name page")]
        public void ThenIShouldRedirectedToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(petNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [When(@"I provided the Pets name as '([^']*)'")]
        [Then(@"I provided the Pets name as '([^']*)'")]
        public void ThenIProvidedThePetsNameAs(string petName)
        {
            var petFullName = $"{petName} {Utils.GenerateRandomName()}";
            petNamePage?.EnterPetsName(petFullName);
            _scenarioContext.Add("PetName", petFullName);
        }

        [When(@"I click on continue button from What is your pet's name page")]
        public void WhenIClickOnContinueButtonFromWhatIsYourPetsNamePage()
        {
            petNamePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What sex is your pet page")]
        public void ThenIShouldRedirectedToTheWhatSexIsYourPetPage()
        {
            var pageTitle = "What sex is your pet?";
            Assert.IsTrue(petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected the option as '([^']*)' for sex")]
        public void ThenIHaveSelectedTheOptionAsForSex(string sex)
        {
            petSexPage?.SelectPetsSexOption(sex);
            _scenarioContext.Add("Sex", sex);
        }

        [When(@"I click on continue button from What sex is your pet page")]
        public void WhenIClickOnContinueButtonFromWhatSexIsYourPetPage()
        {
            petSexPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Do you know your pet's date of birth page")]
        public void ThenIShouldRedirectedToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided date of birth")]
        public void ThenIHaveProvidedDateOfBirth()
        {
            var dateOfBirth = petDOBPage?.EnterDateMonthYear(DateTime.Now.AddYears(-8));
            _scenarioContext.Add("DateOfBirth", dateOfBirth);
        }

        [When(@"I click on continue button from Do you know your pet's date of birth? page")]
        public void WhenIClickOnContinueButtonFromDoYouKnowYourPetsDateOfBirthPage()
        {
            petDOBPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldRedirectedToTheWhatIsTheMainColourOfYourPage(string petCategory)
        {
            var pageTitle = $"What is the main colour of your {petCategory.ToLower()}?";
            Assert.IsTrue(petColourPag?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected the option as '([^']*)' for color")]
        public void ThenIHaveSelectedTheOptionAsForColor(string color)
        {
            petColourPag?.SelectColorOption(color);
            _scenarioContext.Add("Color", color);
        }

        [Then(@"I provided other color of the pet as ""([^""]*)""")]
        public void ThenIProvidedOtherColorOfThePetAs(string otherColor)
        {
            petColourPag?.SelectOtherColorOption(otherColor);
            _scenarioContext.Add("OtherColor", otherColor);
        }

        [When(@"I click on continue button from What is the main colour of your pet page")]
        public void WhenIClickOnContinueButtonFromWhatIsTheMainColourOfYourPetPage()
        {
            petColourPag?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Does your pet have any significant features page")]
        public void ThenIShouldRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = "Does your pet have any significant features?";
            Assert.IsTrue(significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected an option as '([^']*)' for significant features")]
        public void ThenIHaveSelectedAnOptionAsForSignificantFeatures(string hasSignificantFeatures)
        {
            var significantFeature = significantFeaturesPage?.SelectSignificantFeaturesOption(hasSignificantFeatures);
            _scenarioContext.Add("SignificantFeatures", significantFeature);
        }

        [When(@"I click on continue button from Does your pet have any significant features page")]
        public void WhenIClickOnContinueButtonFromDoesYourPetHaveAnySignificantFeaturesPage()
        {
            significantFeaturesPage?.ClickContinueButton();
        }

    }
}

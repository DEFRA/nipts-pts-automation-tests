using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.AP_GB.LandingPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetBreedPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetColourPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetDOBPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipDatePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetNamePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerNamePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPNumberPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetSexPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetSpeciesPage;
using nipts_pts_automation_tests.Pages.AP_GB.SignificantFeaturesPage;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class ValidationsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IPetMicrochipPage? petMicrochipPage => _objectContainer.IsRegistered<IPetMicrochipPage>() ? _objectContainer.Resolve<IPetMicrochipPage>() : null;
        private IPetMicrochipDatePage? petMicrochipDatePage => _objectContainer.IsRegistered<IPetMicrochipDatePage>() ? _objectContainer.Resolve<IPetMicrochipDatePage>() : null;
        private IPetsSpeciesPage? petSpeciesPage => _objectContainer.IsRegistered<IPetsSpeciesPage>() ? _objectContainer.Resolve<IPetsSpeciesPage>() : null;
        private IPetsBreedPage? breedPage => _objectContainer.IsRegistered<IPetsBreedPage>() ? _objectContainer.Resolve<IPetsBreedPage>() : null;
        private IPetsNamePage? petNamePage => _objectContainer.IsRegistered<IPetsNamePage>() ? _objectContainer.Resolve<IPetsNamePage>() : null;
        private IPetsSexPage? petSexPage => _objectContainer.IsRegistered<IPetsSexPage>() ? _objectContainer.Resolve<IPetsSexPage>() : null;
        private IPetDOBPage? petDOBPage => _objectContainer.IsRegistered<IPetDOBPage>() ? _objectContainer.Resolve<IPetDOBPage>() : null;
        private IPetsColourPage? petColourPage => _objectContainer.IsRegistered<IPetsColourPage>() ? _objectContainer.Resolve<IPetsColourPage>() : null;
        private ISignificantFeaturesPage? significantFeaturesPage => _objectContainer.IsRegistered<ISignificantFeaturesPage>() ? _objectContainer.Resolve<ISignificantFeaturesPage>() : null;
        private IPetOwnerNamePage? petKeeperPage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        private IPetOwnerAddressPage? petOwnerAddressPage => _objectContainer.IsRegistered<IPetOwnerAddressPage>() ? _objectContainer.Resolve<IPetOwnerAddressPage>() : null;
        private IPetOwnerPhoneNumberPage? petOwnerPhoneNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;
        private ILandingPage? landingPage => _objectContainer.IsRegistered<ILandingPage>() ? _objectContainer.Resolve<ILandingPage>() : null;
        private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;

        public ValidationsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I have provided future date of birth from microchip scanned date")]
        public void ThenIHaveProvidedFutureDateOfBirthFromMicrochipScannedDate()
        {
            var microchippedDate = _scenarioContext.Get<string>("MicrochippedDate");
            petDOBPage?.EnterDateMonthYear(Utils.ConvertToDate(microchippedDate).AddDays(1));
        }

        [When(@"I have provided same date of birth as microchip scanned date")]
        [Then(@"I have provided same date of birth as microchip scanned date")]
        public void ThenIHaveProvidedSameDateOfBirthAsMicrochipScannedDate()
        {
            var microchippedDate = _scenarioContext.Get<string>("MicrochippedDate");
            petDOBPage?.EnterDateMonthYear(Utils.ConvertToDate(microchippedDate));
        }


        [Then(@"I should not be redirected to the What is the main colour of your '([^']*)' page")]
        public void ThenIShouldNotBeRedirectedToTheWhatIsTheMainColourOfYourPage(string petCategory)
        {
            var pageTitle = $"What is your pet's date of birth?";
            Assert.IsTrue(petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message ""(.*)"" in pets date of birth page")]
        public void ThenIShouldSeeAnErrorMessageInPetsDateOfBirthPage(string errorMessage)
        {
            Assert.True(petDOBPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should see an error message ""(.*)"" in Is your pet microchipped page")]
        public void ThenIShouldSeeAnErrorMessageInPetsMicrochippedPage(string errorMessage)
        {
            Assert.True(petMicrochipPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not be redirected to When was your pet microchipped or last scanned? page")]
        public void ThenIShouldNotBeRedirectedToWhenWasYourPetMicrochippedOrLastScannedPage()
        {
            var pageTitle = $"Is your pet microchipped";
            Assert.IsTrue(petMicrochipPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided future date of PETS microchipped")]
        public void ThenIHaveProvidedFutureDateOfPETSMicrochipped()
        {
            petMicrochipDatePage?.EnterDateMonthYear(DateTime.Now.AddDays(10));
        }

        [Then(@"I should not be redirected to Is your pet a dog, cat or ferret? page")]
        public void ThenIShouldNotBeRedirectedToIsYourPetADogCatOrFerretPage()
        {
            var pageTitle = $"When was your pet microchipped or last scanned?";
            Assert.IsTrue(petMicrochipDatePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message ""(.*)"" in pets microchipped or last scanned page")]
        public void ThenIShouldSeeAnErrorMessageInPetMicrochippedOrLastScannedPage(string errorMessage)
        {
            Assert.True(petMicrochipDatePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I have provided older than expected date of PETS microchipped")]
        public void ThenIHaveProvidedOlderThanExpectedDateMicrochipped()
        {
            petMicrochipDatePage?.EnterDateMonthYear(new DateTime(1989, 1, 1));
        }

        [Then(@"I have provided older than expected date of PETS date of birth")]
        public void ThenIHaveProvidedOlderThanExpectedDateOfPetsDateOfBirth()
        {
            petDOBPage?.EnterDateMonthYear(new DateTime(1989, 1, 1));
        }

        [Then(@"I should not be redirected to What is the main colour of your '(.*)' page")]
        public void ThenIShouldNotBeRedirectedToWhatIsTheMainColourOfYourPage(string petType)
        {
            var pageTitle = "What is your pet's date of birth?";
            Assert.IsTrue(petDOBPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided future date of PETS date of birth")]
        public void ThenIHaveProvidedFutureDateOfPETSDateOfBirth()
        {
            petDOBPage?.EnterDateMonthYear(DateTime.Now.AddDays(10));
        }

        [Then(@"I should not be redirected to What is your postcode page")]
        public void ThenIShouldNotBeRedirectedToWhatIsYourPostcodePage()
        {
            var pageTitle = "What is your full name?";
            Assert.IsTrue(petKeeperPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is your full name page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourFullNamePage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(petKeeperPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message ""(.*)"" in Is your pet a dog, cat or ferret page")]
        public void ThenIShouldSeeAnErrorMessageInIsYourPetADogCatOrFerretPage(string errorMessage)
        {
            Assert.True(petSpeciesPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not be redirected to What breed is your '(.*)' page")]
        public void ThenIShouldNotBeRedirectedToWhatBreedIsYourPage(string petType)
        {
            var pageTitle = "Is your pet a dog, cat or ferret?";
            Assert.IsTrue(petSpeciesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is your pets name page")]
        public void ThenIShouldSeeAnErrorMessageSNamePage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(petNamePage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to What sex is your pet page")]
        public void ThenIShouldNotBeRedirectedToWhatSexIsYourPetPage()
        {
            var pageTitle = "What is your pet's name?";
            Assert.IsTrue(petNamePage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I provided the invalid Pets name as '(.*)'")]
        public void ThenIProvidedThePetsNameAs(string petName)
        {
            petNamePage?.EnterPetsName(petName);
        }

        [Then(@"I should see an error message ""(.*)"" in What sex is your pet page")]
        public void ThenIShouldSeeAnErrorMessageInWhatSexIsYourPetPage(string errorMessage)
        {
            Assert.True(petSexPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
        }

        [Then(@"I should not redirected to the Do you know your pet's date of birth page")]
        public void ThenIShouldNotRedirectedToTheDoYouKnowYourPetsDateOfBirthPage()
        {
            var pageTitle = "What sex is your pet?";
            Assert.IsTrue(petSexPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in microchipped page")]
        public void ThenIShouldSeeAnErrorMessageInMicrochippedPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(petMicrochipPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message '(.*)' in What is your phone number page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourPhoneNumberPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(petOwnerPhoneNumberPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to the Is your pet microchipped page")]
        public void ThenIShouldNotBeRedirectedToTheIsYourPetMicrochippedPage()
        {
            var pageTitle = "What is your phone number?";
            Assert.IsTrue(petOwnerPhoneNumberPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided other colour value as '(.*)'")]
        public void ThenIHaveProvidedOtherColourValueAs(string otherColor)
        {
            petColourPage?.SelectOtherColorOption(otherColor);
        }

        [Then(@"I should not be redirected to the Does your pet have any significant features page")]
        public void ThenIShouldNotBeRedirectedToTheDoesYourPetHaveAnySignificantFeaturesPage()
        {
            var pageTitle = $"What is the main colour of your";
            Assert.IsTrue(petColourPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is the main colour of your pet page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsTheMainColourOfYourPetPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(petColourPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should see an error message '(.*)' in Does your pet have any significant features page")]
        public void ThenIShouldSeeAnErrorMessageInDoesYourPetHaveAnySignificantFeaturesPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(significantFeaturesPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to the Check your answers and sign the declaration page")]
        public void ThenIShouldNotBeRedirectedToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = $"Does your pet have any significant features?";
            Assert.IsTrue(significantFeaturesPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have provided significant features as '(.*)'")]
        public void ThenIHaveProvidedSignificantFeaturesValueAs(string significantFeatures)
        {
            significantFeaturesPage?.EnterSignificantFeatures(significantFeatures);
        }

        [Then(@"I have provided breed value as '(.*)' in breed dropdownlist")]
        public void ThenIHaveProvidedBreedValueAsInBreedDropdownlist(string breed)
        {
            breedPage?.EnterFreeTextBreed(breed);
        }

        [Then(@"I should see an error message '(.*)' in What breed is your pet page")]
        public void ThenIShouldSeeAnErrorMessageInWhatBreedIsYourDogPage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(breedPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I should not be redirected to the What is your pet's name page")]
        public void ThenIShouldNotBeRedirectedToTheWhatIsYourPetsNamePage()
        {
            var pageTitle = $"What breed is your dog?";
            Assert.IsTrue(breedPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should see an error message '(.*)' in What is your postcode page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourPostcodePage(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(petOwnerAddressPage?.IsError(errorMessage), $"There is no error message found with - {errorMessage}");
            }
        }

        [Then(@"I have provided address details as '(.*)' for each field")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourAddressDetaislPage(string address)
        {
            petOwnerAddressPage?.EnterAddressManually(address, address, address, address, address);
        }

        [When(@"I click Continue button from What is your address page")]
        public void WhenIClickContinueButtonFromWhatIsYourAddressPage()
        {
            petOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I should see an error message '(.*)' in What is your address page")]
        public void ThenIShouldSeeAnErrorMessageInWhatIsYourAddressPage(string errorMessage)
        {
            var errorMessages = errorMessage.Split(',');
            foreach (var error in errorMessages)
            {
                Assert.True(petOwnerAddressPage?.IsError(error), $"There is no error message found with - {error}");
            }
        }

        [Then(@"verify next page '([^']*)' is loaded")]
        public void ThenVerifyNextPageIsLoaded(string pageName)
        {
            Assert.True(landingPage.VerifyNextPageIsLoaded(pageName), "Expected page not loaded");
        }

        [Then(@"I verify the link '([^']*)' on page")]
        [When(@"I verify the link '([^']*)' on page")]
        public void ThenVerifyLinkOnPage(string link)
        {
            Assert.IsTrue(homePage?.VerifyTheLink(link), "Link not matching ");
        }
    }
}

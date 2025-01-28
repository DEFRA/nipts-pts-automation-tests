using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.ApplicationSubmittedPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerNamePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPNumberPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class PetOwnerDetailsSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IApplicationSubmissionPage? applicationSubmissionPage => _objectContainer.IsRegistered<IApplicationSubmissionPage>() ? _objectContainer.Resolve<IApplicationSubmissionPage>() : null;
        private IPetOwnerNamePage? petOwnerNamePage => _objectContainer.IsRegistered<IPetOwnerNamePage>() ? _objectContainer.Resolve<IPetOwnerNamePage>() : null;
        private IPetOwnerAddressPage? petOwnerAddressPage => _objectContainer.IsRegistered<IPetOwnerAddressPage>() ? _objectContainer.Resolve<IPetOwnerAddressPage>() : null;
        private IPetOwnerPhoneNumberPage? petOwnerPhoneNumberPage => _objectContainer.IsRegistered<IPetOwnerPhoneNumberPage>() ? _objectContainer.Resolve<IPetOwnerPhoneNumberPage>() : null;

        public PetOwnerDetailsSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"I should redirected to the What is your full name page")]
        public void ThenIShouldRedirectedToTheWhatIsYourFullNamePage()
        {
            Assert.True(petOwnerNamePage?.IsNextPageLoaded("What is your full name?"), "Application page not loaded");
        }

        [Then(@"I provided the full name of the pet keeper as '(.*)'")]
        public void ThenIProvidedTheFullNameOfThePetKeeperAs(string fullName)
        {
            petOwnerNamePage?.EnterPetOwnerName(fullName);
            _scenarioContext.Add("FullName", fullName);
        }

        [When(@"I click Continue button from What is your full name page")]
        public void WhenIClickContinueButtonFromWhatIsYourFullNamePage()
        {
            petOwnerNamePage?.ClickContinueButton();
        }

        [Then(@"I should redirected to What is your postcode page")]
        public void ThenIShouldRedirectedToWhatIsYourPostcodePage()
        {
            Assert.True(petOwnerAddressPage?.IsNextPageLoaded("What is your postcode?"), "Application page not loaded");
        }

        [Then(@"I should redirected to What is the pet keeper's postcode\?")]
        public void ThenIShouldRedirectedToWhatIsThePetKeepersPostcode()
        {
            Assert.True(petOwnerAddressPage?.IsNextPageLoaded("What is the pet keeper's postcode?"), "Application page not loaded");
        }

        [When(@"I click Continue button from What is the pet keeper's postcode\?")]
        public void WhenIClickContinueButtonFromWhatIsThePetKeepersPostcode()
        {
            petOwnerAddressPage?.ClickContinueButton();
        }

        [Then(@"I provided the postcode '([^']*)'")]
        public void ThenIProvidedThePostcode(string postCode)
        {
            petOwnerAddressPage?.EnterPostCode(postCode);
            _scenarioContext.Add("Postcode", postCode);
        }

        [When(@"I click Search button")]
        public void WhenIClickSearchButton()
        {
            petOwnerAddressPage?.ClickSearchButton();
        }

        [Then(@"I should see a list of address in dropdownlist")]
        public void ThenIShouldSeeAListOfAddressInDropdownlist()
        {
            Assert.True(petOwnerAddressPage?.IsAddressListFound());
        }

        [Then(@"I select the index (.*) from address list")]
        public void ThenISelectTheIndexFromAddressList(int addressIndex)
        {
            var addressLines = petOwnerAddressPage?.SelectAnAddress(addressIndex);
            _scenarioContext.Add("Address", addressLines);
        }

        [When(@"I click Continue button from What is your postcode page")]
        public void WhenIClickContinueButtonFromWhatIsYourPostcodePage()
        {
            petOwnerAddressPage?.ClickContinueButton();
        }

        [When(@"I click the link Enter the address manually")]
        public void WhenIClickTheLinkEnterTheAddressManually()
        {
            petOwnerAddressPage?.ClickEnterAddressManuallyLink();
        }

        [When(@"I provided address details with postcode '([^']*)'")]
        public void WhenIProvidedAddressDetailsWithPostcode(string postCode)
        {
            petOwnerAddressPage?.EnterAddressManually("5 AddressLine1", string.Empty, "Coventry", string.Empty, postCode);

            var addressLines = new string[] { "5 AddressLine1", "Coventry", "Coventry", postCode };
            _scenarioContext.Add("Address", addressLines);
        }

        [Then(@"I should redirected to What is your phone number page")]
        public void ThenIShouldRedirectedToWhatIsYourPhoneNumberPage()
        {
            Assert.True(petOwnerPhoneNumberPage?.IsNextPageLoaded("What is your phone number?"), "Application page not loaded");
        }

        [Then(@"I provided the phone number '([^']*)'")]
        public void ThenIProvidedThePhoneNumber(string phoneNumber)
        {
            petOwnerPhoneNumberPage?.EnterPetOwnerPNumber(phoneNumber);
            _scenarioContext.Add("PhoneNumber", phoneNumber);
        }

        [When(@"I click Continue button from What is your phone number page")]
        public void WhenIClickContinueButtonFromWhatIsYourPhoneNumberPage()
        {
            petOwnerPhoneNumberPage?.ClickContinueButton();
        }

        [Then(@"I should redirected to the Application submitted page")]
        public void ThenIShouldRedirectedToTheApplicationSubmittedPage()
        {
            var pageTitle = "Application submitted";
            Assert.IsTrue(applicationSubmissionPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I can see the unique application reference number")]
        public void ThenICanSeeTheSignificantApplicationReferenceNumber()
        {
            var applicationReferenceNumber = applicationSubmissionPage?.GetApplicationReferenceNumber();

            _scenarioContext.Add("ReferenceNumber", applicationReferenceNumber);

            var windowHandles = _driver.WindowHandles.ToList();

            _scenarioContext.Add("WindowHandle", windowHandles[0].ToString());

            Assert.IsTrue(!string.IsNullOrEmpty(applicationReferenceNumber), "There is an issue with application submission");
        }

        [When(@"I have clicked the View all your lifelong pet travel documents link")]
        public void WhenIHaveClickedTheViewAllYourLifelongPetTravelDocumentsLink()
        {
            applicationSubmissionPage?.ClickViewAllSubmittedPetTravelDocument();
        }

        [When(@"I click Apply for another lifelong pet travel document link")]
        public void ThenIClickApplyForAnotherLifelongPetTravelDocumentLink()
        {
            applicationSubmissionPage?.ClickApplyForAnotherPetTravelDocument();
        }

    }
}

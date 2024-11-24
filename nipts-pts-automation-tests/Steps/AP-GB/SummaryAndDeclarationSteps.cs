using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.ApplicationDeclarationPage;
using nipts_pts_automation_tests.Pages.AP_GB.ChangeDetails;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class SummaryAndDeclarationSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPage? summaryPage => _objectContainer.IsRegistered<ISummaryPage>() ? _objectContainer.Resolve<ISummaryPage>() : null;
        private IApplicationDeclarationPage? declarationPage => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPage>() : null;
        private IChangeDetailsPage? changeDetailsPage => _objectContainer.IsRegistered<IChangeDetailsPage>() ? _objectContainer.Resolve<IChangeDetailsPage>() : null;
        private IHomePage? homePage => _objectContainer.IsRegistered<IHomePage>() ? _objectContainer.Resolve<IHomePage>() : null;
        public SummaryAndDeclarationSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"The submitted application should be displayed in summary view")]
        public void ThenTheSubmittedApplicationShouldBeDisplayedInSummaryView()
        {
            var pageTitle = "Your application summary";
            Assert.IsTrue(declarationPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have verified microchip details in declaration page")]
        public void ThenIHaveVerifiedMicrochipDetailsInDeclarationPage()
        {
            VerifyMicrodhipInformation(false);
        }

        [Then(@"I have verified pet details in declaration page")]
        public void ThenIHaveVerifiedPetDetailsInDeclarationPage()
        {
            VerifyPetsDetails(false);
        }

        [Then(@"I have verified pet owner details in declaration page")]
        public void ThenIHaveVerifiedPetOwnerDetailsInDeclarationPage()
        {
            VerifyPetOwnerDetails(false);
        }

        [Then(@"I have ticked the I agree to the declaration checkbox")]
        public void ThenIHaveTickedTheIAgreeToTheDeclarationCheckbox()
        {
            declarationPage?.TickAgreedToDeclaration();
        }

        [When(@"I click Accept and Send button from Declaration page")]
        public void WhenIClickAcceptAndSendButtonFromDeclarationPage()
        {
            declarationPage?.ClickSendApplicationButton();
        }

        [Then(@"I should redirected to the Check your answers and sign the declaration page")]
        public void ThenIShouldRedirectedToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = "Check your answers and sign the declaration";
            Assert.IsTrue(declarationPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have verified microchip details in summary page")]
        public void ThenIHaveVerifiedMicrochipDetailsInSummaryPage()
        {
            VerifyMicrodhipInformation();
        }

        [Then(@"I have verified pet details in summary page")]
        public void ThenIHaveVerifiedPetDetailsInSummaryPage()
        {
            VerifyPetsDetails();
        }

        [Then(@"I click download link in summary page")]
        public void ThenIClickDownloadLinkInSummaryPage()
        {
            summaryPage?.ClickPDFDownloadLink();
        }

        [Then(@"I click print link in summary page")]
        public void ThenIClickPrintLinkInSummaryPage()
        {
            Assert.IsTrue(summaryPage?.ClickPrintdLink(), "Print window not opened successfully");
        }

        [Then(@"I have verified pet owner details in summary page")]
        public void ThenIHaveVerifiedPetOwnerDetailsInSummaryPage()
        {
            VerifyPetOwnerDetails();
        }

        [Then(@"I should redirected to the Are your details correct page")]
        public void ThenIShouldRedirectedToTheAreYourDetailsCorrectPage()
        {
            var pageTitle = "Are your details correct?";
            Assert.IsTrue(changeDetailsPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have selected '([^']*)' option")]
        public void ThenIHaveSelectedOption(string option)
        {
            changeDetailsPage?.SelectOption(option);
            _scenarioContext.Add("AreDetailsCorrect", option);
        }

        [When(@"I click on continue button from Are your details correct page")]
        public void WhenIClickOnContinueButtonFromAreYourDetailsCorrectPage()
        {
            changeDetailsPage?.ClickContinueButton();
        }

        [When(@"I captured Application PTD number")]
        public void WhenICapturedApplicationPTDNumber()
        {
            var summary = summaryPage?.GetSummaryDetails();
            _scenarioContext.Add("PTDNumber", summary.PTDNumber);
        }

        private void VerifyMicrodhipInformation(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPage?.GetSummaryDetails() : declarationPage?.GetSummaryDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            var microchipNumber = _scenarioContext.Get<string>("MicrochipNumber");
            var microchippedDate = _scenarioContext.Get<string>("MicrochippedDate");

            Assert.AreEqual(microchipNumber, summary?.MicrochipNumber, $"Microchip number is not matching in {pageName} page!");
            Assert.AreEqual("Under the skin", summary?.ImplantLocation, $"Implant location is not matching in {pageName} page!");
            Assert.AreEqual(microchippedDate, summary?.ImplantOrScanDate, $"Implant or scan date is not matchin in {pageName} page!");
        }

        private void VerifyPetsDetails(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPage?.GetSummaryDetails() : declarationPage?.GetSummaryDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";

            var petName = _scenarioContext.Get<string>("PetName");
            var petType = _scenarioContext.Get<string>("PetType");

            //var breed = petType.ToLower().Equals("ferret") ? isSummaryPage ? "-" : null : _scenarioContext.Get<string>("Breed");
            var breed = petType.ToLower().Equals("ferret") ? "-" : _scenarioContext.Get<string>("Breed");

            var sex = _scenarioContext.Get<string>("Sex");
            var dateOfBirth = _scenarioContext.Get<string>("DateOfBirth");
            var color = _scenarioContext.Get<string>("Color");
            var significantFeatures = _scenarioContext.Get<string>("SignificantFeatures");

            if (color.Equals("Other"))
            {
                color = _scenarioContext.Get<string>("OtherColor");
            }

            Assert.AreEqual(petName, summary?.PetName, $"Pet name is not matchin in {pageName} page!");
            Assert.AreEqual(petType, summary?.Species, $"Species is not matching in {pageName} page!");
            Assert.AreEqual(breed, summary?.Breed, $"Breed is not matching in {pageName} page!");
            Assert.AreEqual(sex, summary?.Sex, $"Sex is not matching in {pageName} page!");
            Assert.AreEqual(dateOfBirth, summary?.DateOfBirth, $"Date of birth is not matching in {pageName} page!");
            Assert.AreEqual(color, summary?.Colour, $"Color is not matching in {pageName} page!");
            Assert.AreEqual(significantFeatures, summary?.SignificantFeatures, $"Significant feature is not matching in {pageName} page!");
        }

        private void VerifyPetOwnerDetails(bool isSummaryPage = true)
        {
            var summary = isSummaryPage ? summaryPage?.GetSummaryDetails() : declarationPage?.GetSummaryDetails();
            var registeredUserDetails = changeDetailsPage?.GetRegisteredUserDetails();
            var pageName = isSummaryPage ? "summary" : "declaration";
            string[] address;
            var email = registeredUserDetails?.Email;

            var areDetailsCorrect = _scenarioContext.Get<string>("AreDetailsCorrect");

            string? fullName;
            string? phoneNumber;

            if (areDetailsCorrect.ToLower().Equals("yes"))
            {
                fullName = registeredUserDetails?.Name;
                address = registeredUserDetails?.Address?.Split(new string("\r\n"));
                phoneNumber = registeredUserDetails?.PhoneNumber;
            }
            else
            {
                fullName = _scenarioContext.Get<string>("FullName");
                address = _scenarioContext.Get<string[]>("Address");
                phoneNumber = _scenarioContext.Get<string>("PhoneNumber");
            }

            Assert.AreEqual(email, summary?.Email, $"Email is not matching in {pageName} page!");
            Assert.AreEqual(fullName, summary?.Name, $"Pet owner name is not matching in {pageName} page!");
            Assert.AreEqual(phoneNumber, summary?.PhoneNumber, $"Phone number is not matching in {pageName} page!");

            foreach (var lineItem in address)
            {
                Assert.IsTrue(summary?.Address.Contains(lineItem.Trim()), $"Address is not matching in {pageName} page!");
            }

            if (isSummaryPage)
            {
                var referenceNumber = _scenarioContext.Get<string>("ReferenceNumber");
                var date = DateTime.Now.ToString("dd/MM/yyyy");

                Assert.AreEqual(referenceNumber, summary?.ReferenceNumber, $"Reference number is not matching in {pageName} page!");
                Assert.AreEqual(date, summary?.Date, $"Microchip number is not matching in {pageName} page!");
            }
        }

        [Then(@"I should not see the application in the Dashboard")]
        public void ThenIShouldNotSeeTheApplicationInTheDashboard()
        {
            var petName = _scenarioContext.Get<string>("PetName");
            Assert.IsTrue(homePage?.VerifyTheApplicationIsNotAvailable(petName), $"The application is available in Dashboard!");
        }

    }
}

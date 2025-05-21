using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class SearchResultsPassFailPage : ISearchResultsPassFail
    {
        private readonly IObjectContainer _objectContainer;

        public SearchResultsPassFailPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        private IWebElement PTDNumberEle => _driver.WaitForElement(By.XPath("(//dl[contains(@class,'govuk-summary-list')]/div[1]/dd)[1]"));
        private IWebElement SigFeaturesEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Significant features')]/following-sibling::dd"));
        private IWebElement PetClrEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Colour')]/following-sibling::dd"));
        private IWebElement PetBreedEle => _driver.WaitForElementExists(By.XPath("(//dl[contains(@class,'govuk-summary-list')]/div[3]/dd)[1]"));
        private IWebElement PetNameEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Pet name')]/following-sibling::dd"));
        private IWebElement PetSpeciesEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Species')]/following-sibling::dd"));
        private IWebElement PetSexEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Sex')]/following-sibling::dd"));
        private IWebElement PetMicrochipNumEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Microchip number')]/following-sibling::dd"));
        private IWebElement PetMicrochipDateEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Implant or scan date')]/following-sibling::dd"));
        private IWebElement PetsDateOfBirthEle => _driver.WaitForElementExists(By.XPath("//dt[contains(text(),'Date of birth')]/following-sibling::dd"));

        #endregion

        #region Methods
        public bool VerifyPTDNoOnSearchResultsPassFailPage(string finalPTD)
        {
            return PTDNumberEle.Text.Equals(finalPTD);
        }

        public bool VerifySignificantFeaturesOption(string sigFeatures)
        {
            string SigFeatures = SigFeaturesEle.Text;
            return SigFeaturesEle.Text.Contains(sigFeatures);
        }

        public bool VerifyOtherClrOption(string otherClr)
        {
            return PetClrEle.Text.Contains(otherClr);
        }
        public bool VerifyPetBreedOption(string petBreed)
        {
            string PetBreed = PetBreedEle.Text;
            return PetBreedEle.Text.Contains(petBreed);
        }

        public bool VerifyPetpetMicrochipNumber(string petMicrochipNumber)
        {
            string PetMicrochipNum = PetMicrochipNumEle.Text;
            return PetMicrochipNumEle.Text.Contains(petMicrochipNumber);
        }

        public bool VerifyPetSexOption(string petSex)
        {
            string petsex = PetSexEle.Text;
            return PetSexEle.Text.Contains(petSex);
        }

        public bool VerifyPetSpeciesOption(string petSpecies)
        {
            string PetSpecies = PetSpeciesEle.Text;
            return PetSpeciesEle.Text.Contains(petSpecies);
        }

        public bool VerifyPetNameOption(string petName)
        {
            string PetName = PetNameEle.Text;
            return PetNameEle.Text.Contains(petName);
        }

        public bool VerifypetsDateOfBirth(string petsDateOfBirth)
        {
            string PetsDateOfBirth = PetsDateOfBirthEle.Text;
            return PetsDateOfBirthEle.Text.Contains(petsDateOfBirth);
        }
        public bool VerifyPetpetMicrochipDate(string petMicrochipDate)
        {
            string PetMicrochipDate = PetMicrochipDateEle.Text;
            return PetMicrochipDateEle.Text.Contains(petMicrochipDate);
        }

        #endregion

    }
}

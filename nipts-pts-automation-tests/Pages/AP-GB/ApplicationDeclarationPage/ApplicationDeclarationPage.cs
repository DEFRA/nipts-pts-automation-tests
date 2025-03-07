using BoDi;
using Defra.UI.Tests.Contracts;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.ApplicationDeclarationPage
{
    public class ApplicationDeclarationPage : IApplicationDeclarationPage
    {
        private readonly IObjectContainer _objectContainer;

        public ApplicationDeclarationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-heading-xl"), true);
        public IWebElement CustomPageHeading => _driver.WaitForElement(By.XPath("//div[@class='govuk-grid-row']//h1[@class='govuk-heading-l']"), true);
        private IWebElement SendApplicationButton => _driver.WaitForElementExists(By.XPath("//button[contains(text(),'Send application')]"));
        private IWebElement chkAgreesToDeclaration => _driver.WaitForElementExists(By.XPath("//input[@id='AgreedToDeclaration']"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationTitleList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dt"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationValueList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dd[1]"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationActionList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> divPetDetailsTitleList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dt"));
        private IReadOnlyCollection<IWebElement> divPetDetailsValueList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dd[1]"));
        private IReadOnlyCollection<IWebElement> divPetDetailsActionList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsTitleList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dt"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsValueList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dd[1]"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsActionList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dd[2]/a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public bool IsCustomPageLoaded(string pageTitle)
        {
            return CustomPageHeading.Text.Contains(pageTitle);
        }

        public void TickAgreedToDeclaration()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,1000)", "");
            chkAgreesToDeclaration.Click();
        }

        public void ClickSendApplicationButton()
        {
            SendApplicationButton.Click();
        }

        public Summary GetSummaryDetails()
        {
            var summary = new Summary();

            for (int i = 0; i < divMicrochipInformationTitleList.Count; i++)
            {
                var elementTitle = divMicrochipInformationTitleList.ElementAt(i)?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = divMicrochipInformationValueList.ElementAt(i).Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "MICROCHIP NUMBER":
                        summary.MicrochipNumber = elementValue;
                        break;
                    case "IMPLANT OR SCAN DATE":
                        summary.ImplantOrScanDate = elementValue;
                        break;
                }
            }

            for (int i = 0; i < divPetDetailsTitleList.Count; i++)
            {
                var elementTitle = divPetDetailsTitleList.ElementAt(i)?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = divPetDetailsValueList.ElementAt(i).Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.PetName = elementValue;
                        break;
                    case "SPECIES":
                        summary.Species = elementValue;
                        break;
                    case "BREED":
                        summary.Breed = elementValue;
                        break;
                    case "SEX":
                        summary.Sex = elementValue;
                        break;
                    case "DATE OF BIRTH":
                        summary.DateOfBirth = elementValue;
                        break;
                    case "COLOUR":
                        summary.Colour = elementValue;
                        break;
                    case "SIGNIFICANT FEATURES":
                        summary.SignificantFeatures = elementValue;
                        break;
                }

            }

            for (int i = 0; i < divPetOwnerDetailsTitleList.Count; i++)
            {
                var elementTitle = divPetOwnerDetailsTitleList.ElementAt(i)?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = divPetOwnerDetailsValueList.ElementAt(i).Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.Name = elementValue;
                        break;
                    case "ADDRESS":
                        summary.Address = elementValue;
                        break;
                    case "PHONE NUMBER":
                        summary.PhoneNumber = elementValue;
                        break;
                    case "EMAIL":
                        summary.Email = elementValue;
                        break;
                }
            }

            summary.Date = DateTime.Now.ToString("dd/MM/yyyy");

            return summary;
        }

        public void ClickMicrochipChangeLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "MICROCHIP NUMBER":
                    divMicrochipInformationActionList.ElementAt(0)?.Click();
                    break;
                case "IMPLANT OR SCAN DATE":
                    divMicrochipInformationActionList.ElementAt(1)?.Click();
                    break;
            }
        }

        public void ClickPetDetailsChangeLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NAME":
                    divPetDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "SPECIES":
                    divPetDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "BREED":
                    divPetDetailsActionList.ElementAt(2)?.Click();
                    break;
                case "SEX":
                    divPetDetailsActionList.ElementAt(3)?.Click();
                    break;
                case "DATE OF BIRTH":
                    divPetDetailsActionList.ElementAt(4)?.Click();
                    break;
                case "COLOUR":
                    divPetDetailsActionList.ElementAt(5)?.Click();
                    break;
                case "SIGNIFICANT FEATURES":
                    divPetDetailsActionList.ElementAt(6)?.Click();
                    break;
            }
        }

        public void ClickPetDetailsChangeForFerretLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NAME":
                    divPetDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "SPECIES":
                    divPetDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "SEX":
                    divPetDetailsActionList.ElementAt(2)?.Click();
                    break;
                case "DATE OF BIRTH":
                    divPetDetailsActionList.ElementAt(3)?.Click();
                    break;
                case "COLOUR":
                    divPetDetailsActionList.ElementAt(4)?.Click();
                    break;
                case "SIGNIFICANT FEATURES":
                    divPetDetailsActionList.ElementAt(5)?.Click();
                    break;
            }
        }

        public void ClickPetOwnerChangeLink(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NAME":
                    divPetOwnerDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "ADDRESS":
                    divPetOwnerDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "PHONE NUMBER":
                    divPetOwnerDetailsActionList.ElementAt(2)?.Click();
                    break;
            }
        }

        #endregion
    }
}
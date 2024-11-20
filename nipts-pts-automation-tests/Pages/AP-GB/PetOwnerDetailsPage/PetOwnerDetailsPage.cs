using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerDetailsPage
{
    public class PetOwnerDetailsPage : IPetOwnerDetailsPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetOwnerDetailsPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PetOwnerDetailsPageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement DetailsRadioButtonYes => _driver.WaitForElementExists(By.CssSelector("#Yes"));
        private IWebElement DetailsRadioButtonNo => _driver.WaitForElementExists(By.CssSelector("#No"));
        public IWebElement petOwnersPhoneNumber => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Phone Number']/following-sibling::dd"), true);
        public IWebElement petOwnerName => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Name']/following-sibling::dd"));
        public IWebElement updatedPetOwnerAddress => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Address']//following-sibling::dd"), true);
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PetOwnerDetailsPageHeading.Text.Contains(pageTitle);
        }
        public void SelectIsOwnerDetailsCorrect(string radioOption)
        {
            if (radioOption.Equals("Yes"))
            {
                DetailsRadioButtonYes.Click();
            }
            else
            {
                DetailsRadioButtonNo.Click();
            }
        }
        public void ClickContinueButton()
        {
            _driver.ContinueButton();
        }
        public bool VerifyUpdatedPhoneNumber(String phoneNumber)
        {
            return petOwnersPhoneNumber.Text.Equals(phoneNumber);
        }
        public bool VerifyUpdatedName(string name)
        {
            return petOwnerName.Text.Equals(name);
        }
        public bool VerifyUpdatedPetOwnerAddress(string PetOwnerPostcode)
        {
            var updatedAddress = updatedPetOwnerAddress.Text.Replace("\r\n", "");
            return updatedAddress.Contains(PetOwnerPostcode);
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
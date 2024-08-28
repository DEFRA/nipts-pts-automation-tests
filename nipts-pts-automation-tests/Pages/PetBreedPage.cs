using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages
{
    public class PetBreedPage : IPetBreedPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
       
        public IWebElement BreedTypeEle => _driver.WaitForElementExists(By.Id("BreedId"));

        private By ErrorMessage => By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a");

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetBreedPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public void EnterFreeTextBreed(string breed)
        {
            if (!breed.Equals(""))
            {
                BreedTypeEle.Click();
                BreedTypeEle.SendKeys(breed);
            }
        }

        public bool VerifyErrorMessageOnPetBreedPage(string errorMessage)
        {
            return _driver.FindElement(ErrorMessage).Text.Contains(errorMessage);
        }


        #endregion Page Methods


    }
}

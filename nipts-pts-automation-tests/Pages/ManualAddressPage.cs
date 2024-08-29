using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nipts_pts_automation_tests.Pages
{
    public class ManualAddressPage : IManualAddressPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement cannotFindAddressInList => _driver.WaitForElement(By.XPath("//a[@href='/TravelDocument/PetKeeperAddressManual']"));
        private IWebElement enterAddressManually => _driver.WaitForElement(By.XPath("//a[contains(text(),'Rhowch y cyfeiriad eich hunan')]"));
        private IWebElement enterAddressLineOne => _driver.WaitForElement(By.Id("AddressLineOne"));
        private IWebElement enterAddressLineTwo => _driver.WaitForElement(By.Id("AddressLineTwo"));
        private IWebElement enterTownorCity => _driver.WaitForElement(By.Id("TownOrCity"));
        private IWebElement enterCountry => _driver.WaitForElement(By.Id("County"));
        private IWebElement enterPostcode => _driver.WaitForElement(By.Id("Postcode"));
        private By ErrorMessage => By.XPath("//div[contains(@class,'govuk-error-summary__body')]//a");

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ManualAddressPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void ClickEnterAddressManually()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", enterAddressManually);
        }

        public void EnterAddress(string addline1, string addline2, string city, string country, string postcode)
        {
            enterAddressLineOne.SendKeys(addline1);
            enterAddressLineTwo.SendKeys(addline2);
            enterTownorCity.SendKeys(city);
            enterPostcode.SendKeys(postcode);   
            enterCountry.SendKeys(country); 
        }

        public bool VerifyErrorMessageOnManualAddressPage(string errorMessage)
        {
            return _driver.FindElement(ErrorMessage).Text.Contains(errorMessage);
        }

        public void ClickOnCannotFindTheAddressInTheList()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", cannotFindAddressInList);
        }
        #endregion Page Methods

    }
}

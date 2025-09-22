using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressPage
{

    public class PetOwnerAddressPage : IPetOwnerAddressPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetOwnerAddressPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1//label[contains(@class,'govuk-label--xl')] "));
        private IWebElement btnFindAddress => _driver.WaitForElement(By.XPath("//button[@type='submit']"));
        private IWebElement txtPostCode => _driver.WaitForElement(By.Id("Postcode"), true);
        private IWebElement drpAddress => _driver.WaitForElement(By.CssSelector("#Address"));
        private IWebElement lnkEnterAddress => _driver.WaitForElement(By.XPath("//a[contains(text(),'Enter the address manually')]"));
        private IWebElement txtAddressLineOne => _driver.WaitForElement(By.Id("AddressLineOne"));
        private IWebElement txtAddressLineTwo => _driver.WaitForElement(By.Id("AddressLineTwo"));
        private IWebElement txtTownOrCity => _driver.WaitForElement(By.Id("TownOrCity"));
        private IWebElement txtCounty => _driver.WaitForElement(By.Id("County"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));

        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void ClickContinueButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,500)", "");
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", btnContinue);
            //btnContinue.Click();
            //_driver.ContinueButton();
        }

        public void ClickSearchButton()
        {
            btnFindAddress.Click();
        }

        public void EnterPostCode(string postCode)
        {
            txtPostCode.Clear();
            txtPostCode.SendKeys(postCode);
        }

        public string[] SelectAnAddress(int index)
        {
            var addressElement = new SelectElement(drpAddress);
            addressElement.SelectByIndex(index);

            return addressElement.SelectedOption.Text.Split(',');
        }

        public bool IsAddressListFound()
        {
            return drpAddress.Displayed;
        }

        public void ClickEnterAddressManuallyLink()
        {
            lnkEnterAddress.Click();
        }

        public void EnterAddressManually(string addressLine1, string addressLine2, string town, string county, string postCode)
        {
            txtAddressLineOne.SendKeys(addressLine1);
            txtAddressLineTwo.SendKeys(addressLine2);
            txtTownOrCity.SendKeys(town);
            txtCounty.SendKeys(county);
            txtPostCode.SendKeys(postCode);
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
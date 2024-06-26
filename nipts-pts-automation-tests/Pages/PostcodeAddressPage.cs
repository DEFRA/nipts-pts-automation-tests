using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nipts_pts_automation_tests.Pages
{
    public class PostcodeAddressPage : IPostcodeAddressPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement PostcodeEle => _driver.WaitForElement(By.Id("Postcode"));
        private IWebElement SelectAddresEle => _driver.WaitForElement(By.Id("Address"));
        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//ul[contains(@class,'govuk-error-summary__list')]//a"));
        private IWebElement FindAddressWelshEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Dod o hyd i gyfeiriad')]"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PostcodeAddressPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterPostcode(string postcode)
        {
            PostcodeEle.SendKeys(postcode);
            FindAddressWelshEle.Click();
        }

        public void SelectAddress()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(500,4000)", "");
            SelectElement s = new SelectElement(SelectAddresEle);
            s.SelectByIndex(1);
        }

        public bool ThenVerifyErrorMessageOnPetsPostcodePage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
        }


        #endregion Page Methods


    }
}

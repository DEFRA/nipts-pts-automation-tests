using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPostCodePage
{
    public class PetOwnerPostCodePage : IPetOwnerPostCodePage
    {
        private readonly IObjectContainer _objectContainer;
        public PetOwnerPostCodePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PetOwnerPostCodePageHeading => _driver.WaitForElement(By.CssSelector(".govuk-label.govuk-label--xl"), true);
        public IWebElement PostCodeTextBox => _driver.WaitForElement(By.CssSelector("#Postcode"));
        public IWebElement FindAddressButton => _driver.WaitForElement(By.XPath("//button[contains(text(),'Find address')]"));
        public IWebElement ManuallyAddressLink => _driver.WaitForElement(By.XPath("//*[@id='main-content']/div/div/p/a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void EnterPetOwnerPostCode(string PostCode)
        {
            PostCodeTextBox.Click();
            PostCodeTextBox.SendKeys(PostCode);
        }

        public void ClickFindAddressButton()
        {
            FindAddressButton.Click();
        }

        public void ClickManuallyAddressLink()
        {
            ManuallyAddressLink.Click();
        }
        #endregion
    }
}
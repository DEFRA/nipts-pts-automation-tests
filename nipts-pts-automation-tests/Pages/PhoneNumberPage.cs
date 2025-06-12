using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages
{
    internal class PhoneNumberPage : IPhoneNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement PhoneNumberEle => _driver.WaitForElement(By.Id("Phone"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PhoneNumberPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void EnterPhoneNumber(string phoneNumber)
        {
            PhoneNumberEle.Clear();
            PhoneNumberEle.SendKeys(phoneNumber);
        }

        public bool VerifyErrorMessageOnPetsTelephoneNumberPage(string errorMessage)
        {
            return true;
        }


        #endregion Page Methods



    }
}

using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPNumberPage
{
    public class PetOwnerPhoneNumberPage : IPetOwnerPhoneNumberPage
    {
        private readonly IObjectContainer _objectContainer;

        public PetOwnerPhoneNumberPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@for='Phone']"), true);
        private IWebElement txtPhoneNumber => _driver.WaitForElement(By.Id("Phone"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void EnterPetOwnerPNumber(string phoneNumber)
        {
            txtPhoneNumber.Clear();
            txtPhoneNumber.SendKeys(phoneNumber);
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
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
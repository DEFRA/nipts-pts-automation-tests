using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class PersonalDetailsPage : IPersonalDetailsPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement UserNameEle => _driver.WaitForElement(By.XPath("//dl[contains(@class,'govuk-summary-list')]/div/dd[1]"));
        private IWebElement UserEmailEle => _driver.WaitForElement(By.XPath("//dl[contains(@class,'govuk-summary-list')]/div[2]/dd"));
        private IWebElement UserAddressEle => _driver.WaitForElement(By.XPath("//dl[contains(@class,'govuk-summary-list')]/div[3]/dd"));
        private IWebElement UserPhoneNumEle => _driver.WaitForElement(By.XPath("//dl[contains(@class,'govuk-summary-list')]/div[4]/dd"));
        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//a[@href='#UserDetailsAreCorrect']"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PersonalDetailsPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyPersonalDetails(string userType)
        {
            var user = UserObject.GetUserById(userType);
            _objectContainer.RegisterInstanceAs(user);

            if (UserNameEle.Text.Contains(user.UserName) && UserEmailEle.Text.Contains(user.UserEmail) && UserAddressEle.Text.Contains(user.Useraddress) && UserPhoneNumEle.Text.Contains(user.UserPhoneNumber))
                return true;
            else
                return false;
        }

        public void SelectOptionOnPersonalDetailsPage(string option)
        {
            _driver.ClickRadioButton(option);

        }

        public bool VerifyErrorMessageOnPersonalDetailsPage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
        }

        #endregion Page Methods



    }
}

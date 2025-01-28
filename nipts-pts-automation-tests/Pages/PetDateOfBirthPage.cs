using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages
{
    public class PetDateOfBirthPage : IPetDateOfBirthPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement txtDay => _driver.WaitForElement(By.Id("Day"));
        private IWebElement txtMonth => _driver.WaitForElement(By.Id("Month"));
        private IWebElement txtYear => _driver.WaitForElement(By.Id("Year"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetDateOfBirthPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public string EnterDateMonthYear(DateTime dateTime)
        {
            var day = dateTime.ToString("dd");
            var month = dateTime.ToString("MM");
            var year = dateTime.ToString("yyyy");

            txtDay.Clear();
            txtMonth.Clear();
            txtYear.Clear();

            txtDay.SendKeys(day);
            txtMonth.SendKeys(month);
            txtYear.SendKeys(year);

            return $"{day}/{month}/{year}";
        }
        public void EnterPetsDateOfBirth(string PetDOBDay, string PetDOBMonth, string PetDOBYear)
        {
            txtDay.Clear();
            txtMonth.Clear();
            txtYear.Clear();

            txtDay.SendKeys(PetDOBDay);
            txtMonth.SendKeys(PetDOBMonth);
            txtYear.SendKeys(PetDOBYear);

        }

        #endregion Page Methods

    }
}

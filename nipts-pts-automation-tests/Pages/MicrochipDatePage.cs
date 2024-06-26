using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class MicrochipDatePage : IMicrochipDatePage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement txtDay => _driver.WaitForElement(By.Id("Day"));
        private IWebElement txtMonth => _driver.WaitForElement(By.Id("Month"));
        private IWebElement txtYear => _driver.WaitForElement(By.Id("Year"));


        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public MicrochipDatePage(IObjectContainer container)
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


        #endregion Page Methods

    }
}
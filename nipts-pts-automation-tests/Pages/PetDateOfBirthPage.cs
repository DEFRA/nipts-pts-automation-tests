using Reqnroll.BoDi;
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

            SetDateField(By.Id("Day"), day);
            SetDateField(By.Id("Month"), month);
            SetDateField(By.Id("Year"), year);

            return $"{day}/{month}/{year}";
        }
        public void EnterPetsDateOfBirth(string PetDOBDay, string PetDOBMonth, string PetDOBYear)
        {
            SetDateField(By.Id("Day"), PetDOBDay);
            SetDateField(By.Id("Month"), PetDOBMonth);
            SetDateField(By.Id("Year"), PetDOBYear);
        }

        // The govuk date inputs sit below the HMRC session-timeout dialog, which can overlay them and
        // make Selenium report the field as not visible; WaitForElement then burns its whole 30s
        // budget per access (six accesses here compounded to ~122s) and the step fails with "Element
        // is not visible". Clear the overlay first, resolve the field by presence (not visibility),
        // scroll it into view, then type with a JS value-set fallback for when SendKeys is blocked.
        private void SetDateField(By by, string value)
        {
            _driver.DismissTimeoutOverlayIfPresent();
            var field = _driver.WaitForElementExists(by);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", field);
            try
            {
                field.Clear();
                field.SendKeys(value);
            }
            catch (Exception)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "arguments[0].value=arguments[1];arguments[0].dispatchEvent(new Event('input',{bubbles:true}));",
                    field, value);
            }
        }

        #endregion Page Methods

    }
}

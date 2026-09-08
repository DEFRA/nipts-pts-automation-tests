using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetDOBPage
{
    public class PetDOBPage : IPetDOBPage
    {
        private readonly IObjectContainer _objectContainer;

        public PetDOBPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"), true);
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));

        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));

        #endregion

        #region Methods

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

        // Resolve each field once by PRESENCE. The old forceWait visibility properties slept 10s on
        // every access (6 accesses = ~60s per run) and tipped into "Element is not visible" whenever
        // a govuk input reported Displayed=false on BrowserStack. JS-set the value if the native
        // SendKeys is rejected as not-interactable.
        private void SetDateField(By by, string value)
        {
            var field = _driver.WaitForElementExists(by);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", field);
            try
            {
                field.Clear();
                field.SendKeys(value);
            }
            catch (WebDriverException)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript(
                    "arguments[0].value=arguments[1]; arguments[0].dispatchEvent(new Event('input',{bubbles:true}));",
                    field, value);
            }
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            return _driver.IsHeadingLoaded(pageTitle);
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

        public void ClickContinueButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,500)", "");
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", btnContinue);
            //btnContinue.Click();
            //_driver.ContinueButton();
        }

        #endregion
    }
}
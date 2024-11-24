using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetSexPage
{
    public class PetsSexPage : IPetsSexPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetsSexPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        public IWebElement rdoFemale => _driver.WaitForElementExists(By.CssSelector("#Female"), true);
        public IWebElement rdoMale => _driver.WaitForElementExists(By.CssSelector("#Male"), true);
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void SelectPetsSexOption(string sex)
        {
            if (sex.ToLower().Equals("male"))
            {
                rdoMale.Click();
            }
            else
            {
                try
                {
                    rdoFemale.Click();
                }
                catch
                {
                    rdoFemale.FindElement(By.CssSelector("#Female")).Click();
                }
            }
        }

        public void ClickContinueButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,500)", "");
            btnContinue.Click();
            //_driver.ContinueButton();
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
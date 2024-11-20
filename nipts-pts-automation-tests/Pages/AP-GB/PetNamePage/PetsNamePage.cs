using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetNamePage
{
    public class PetsNamePage : IPetsNamePage
    {
        private readonly IObjectContainer _objectContainer;
        public PetsNamePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@for='PetName']"), true);
        private IWebElement txtPetsName => _driver.WaitForElement(By.Id("PetName"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));

        #endregion

        #region Methods

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void EnterPetsName(string petName)
        {
            txtPetsName.Clear();
            txtPetsName.SendKeys(petName);
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
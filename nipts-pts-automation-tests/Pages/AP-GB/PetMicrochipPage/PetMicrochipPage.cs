using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Tools;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipPage
{
    public class PetMicrochipPage : IPetMicrochipPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetMicrochipPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-fieldset__heading']"), true);
        //private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[@type='submit']"), true);
        private IWebElement rdoYes => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='MicrochippedYes']"));
        private IWebElement rdoNo => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='MicrochippedNo']"));
        private IWebElement txtMicroshipNumber => _driver.WaitForElement(By.XPath("//input[@id='MicrochipNumber']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));

        #endregion

        #region Methods
        public void ClickContinueButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,500)", "");
            btnContinue.Click();
            //_driver.ContinueButton();
        }

        public string EnterMicrochipNumber()
        {
            var microchipNumber = Utils.GenerateMicrochipNumber();
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microchipNumber);
            return microchipNumber;
        }

        public string EnterGivenMicrochipNumber(string microChipNumber)
        {
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microChipNumber);
            return microChipNumber;
        }

        public void UpdateMicrochipNumber(string microChipNumber)
        {
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microChipNumber);
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void SelectMicrochippedOption(string option)
        {
            var microChipOrTattoOption = option.ToLower();

            if (microChipOrTattoOption.Equals("yes"))
            {
                rdoYes.Click();
            }
            else if (microChipOrTattoOption.Equals("no"))
            {
                rdoNo.Click();
            }
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
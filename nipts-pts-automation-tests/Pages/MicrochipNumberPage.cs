using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using NUnit.Framework;
using OpenQA.Selenium;



namespace nipts_pts_automation_tests.Pages
{
    public class MicrochipNumberPage : IMicrochipNumberPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement rdoYes => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='Yes']"));
        private IWebElement rdoNo => _driver.WaitForElement(By.XPath("//div[@class='govuk-radios__item']/label[@for='No']"));

        private IWebElement txtMicroshipNumber => _driver.WaitForElement(By.XPath("//input[@id='microchipinput']"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public MicrochipNumberPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
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
        public string EnterMicrochipNumber(string microchipNumber)
        {
            //var microchipNumber = Utils.GenerateMicrochipNumber();
            txtMicroshipNumber.Clear();
            txtMicroshipNumber.SendKeys(microchipNumber);
            return microchipNumber;
        }


        #endregion Page Methods

    }
}


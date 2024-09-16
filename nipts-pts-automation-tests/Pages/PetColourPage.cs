using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages
{
    public class PetColourPage : IPetColourPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//a[@href='#PetColour'] | //a[@href='#PetColourOther']"));
        private IWebElement OtherClrEle => _driver.WaitForElement(By.Id("PetColourOther"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetColourPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public void SelectColorOption(string color)
        {
            if (!string.IsNullOrEmpty(color))
            {
                var rdoColor = _driver.WaitForElement(By.XPath($"//div[@class='govuk-radios__item']/label[contains(text(),'{color.Replace(" ", string.Empty)}')]"));
                rdoColor.Click();
            }
        }

        public bool VerifyErrorMessageOnPetColorPage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
        }

        public void EnterOtherColorText(string petColour)
        {
            OtherClrEle.Clear();
            OtherClrEle.SendKeys(petColour);
        }

        #endregion Page Methods

    }
}

using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetColourPage
{
    public class PetsColourPage : IPetsColourPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetsColourPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PetColourPageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement PetColourOtherRadioButton => _driver.WaitForElement(By.CssSelector("#PetColourOther"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement txtPetColorOther => _driver.WaitForElement(By.Id("PetColourOther"));

        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PetColourPageHeading.Text.Contains(pageTitle);
        }

        public void SelectOtherColorOption(string otherColor)
        {
            txtPetColorOther.Clear();
            txtPetColorOther.SendKeys(otherColor);
        }

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
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

        public void SelectColorOption(string color)
        {
            if (color.Equals("Other"))
            {
                var rdoColor = _driver.WaitForElement(By.XPath($"//div[@class='govuk-radios__item']/label[@for='rBtnPetColourOther']"));
                rdoColor.Click();
            }
            else if (!string.IsNullOrEmpty(color))
            {
                var rdoColor = _driver.WaitForElement(By.XPath($"//div[@class='govuk-radios__item']/label[@for='{color.Replace(" ", string.Empty)}']"));
                rdoColor.Click();
            }
        }

        #endregion
    }
}
using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetSpeciesPage
{
    public class PetsSpeciesPage : IPetsSpeciesPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetsSpeciesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-fieldset__heading"), true);
        private IWebElement DogRadioButton => _driver.WaitForElementExists(By.CssSelector("#Dog"));
        private IWebElement CatRadioButton => _driver.WaitForElementExists(By.CssSelector("#Cat"));
        private IWebElement FerretRadioButton => _driver.WaitForElementExists(By.CssSelector("#Ferret"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }
        public void SelectSpecies(string species)
        {
            {
                switch (species)
                {
                    case "Dog":
                        DogRadioButton.Click();
                        break;
                    case "Cat":
                        CatRadioButton.Click();
                        break;
                    case "Ferret":
                        FerretRadioButton.Click();
                        break;
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
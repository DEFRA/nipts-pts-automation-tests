using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class EnterSpeciesPage : IEnterSpeciesPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//a[@href='#PetSpecies']"));
        private IWebElement DogRadioButton => _driver.WaitForElementExists(By.CssSelector("#Dog"));
        private IWebElement CatRadioButton => _driver.WaitForElementExists(By.CssSelector("#Cat"));
        private IWebElement FerretRadioButton => _driver.WaitForElementExists(By.CssSelector("#Ferret"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public EnterSpeciesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyErrorMessageOnEnterSpeciesPage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
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

        #endregion Page Methods

    }
}
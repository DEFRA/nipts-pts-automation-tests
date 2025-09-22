using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class PetSpeciesPage : IPetSpeciesPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement DogRadioButton => _driver.WaitForElementExists(By.CssSelector("#Dog"));
        private IWebElement CatRadioButton => _driver.WaitForElementExists(By.CssSelector("#Cat"));
        private IWebElement FerretRadioButton => _driver.WaitForElementExists(By.CssSelector("#Ferret"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public PetSpeciesPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void SelectSpecies(string species)
        {
            {
                switch (species)
                {
                    case "Dog":
                    case "Ci":
                        DogRadioButton.Click();
                        break;
                    case "Cat":
                    case "Cath":
                        CatRadioButton.Click();
                        break;
                    case "Ferret":
                    case "Ffured":
                        FerretRadioButton.Click();
                        break;
                }
            }
        }

        #endregion Page Methods

    }
}
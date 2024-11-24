using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.PetBreedPage
{
    public class PetsBreedPage : IPetsBreedPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetsBreedPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"), true);
        public IWebElement drpBreedType => _driver.WaitForElementExists(By.XPath("//*[@id='BreedId']"));
        private IWebElement txtBreed => _driver.WaitForElement(By.Name("BreedName"));
        private IWebElement drpBreedsListBox => _driver.WaitForElement(By.Id("BreedId__listbox"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            string temp = PageHeading.Text;
            return PageHeading.Text.Contains(pageTitle);
        }

        public string SelectPetsBreed(int breedIndex)
        {
            //Thread.Sleep(2000);
            drpBreedType.Click();
            var selectedBread = string.Empty;

            var breadList = drpBreedsListBox.FindElements(By.TagName("li"));

            for (var index = 0; index < breadList.Count; index++)
            {
                if (index.Equals(breedIndex))
                {
                    selectedBread = breadList[index].Text;
                    breadList[index].Click();
                    break;
                }
            }

            return selectedBread;
        }

        public void ClickContinueButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,500)", "");
            btnContinue.Click();
            //Thread.Sleep(2000);
            //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", btnContinue);
        }

        public void EnterFreeTextBreed(string breed)
        {
            drpBreedType.Click();

            txtBreed.SendKeys(breed);
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
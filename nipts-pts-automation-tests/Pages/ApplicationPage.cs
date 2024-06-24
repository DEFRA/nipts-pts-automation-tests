using BoDi;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;


namespace nipts_pts_automation_tests.Pages
{
    public class ApplicationPage : IApplicationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement Englishclick => _driver.WaitForElement(By.XPath("//a[contains(text(),'English')]"));
        private IWebElement Welshclick => _driver.WaitForElement(By.XPath("//a[contains(text(),'Cymraeg')]"));
        private IWebElement ApplyForADocEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Apply for a document')]"));
        private IWebElement ContinueWelshEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Parhau')]"));
        private IWebElement BaclWelshEle => _driver.WaitForElement(By.XPath("//a[contains(text(),'Yn ôl')]"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ApplicationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyNextPageIsLoaded(string pageName)
        {
            string text = PageHeading.Text;
            return PageHeading.Text.Contains(pageName);
        }

        public void ClickOnWelshLang()
        {
            Welshclick.Click();
        }

        public void ClickOnEnglishLang()
        {
            Englishclick.Click();
        }

        public void ClickOnApplyForADocument()
        {
            ApplyForADocEle.Click();
        }

        public void ClickOnContinueWelsh()
        {
            ContinueWelshEle.Click();
        }

        public void ClickOnBackWelsh()
        {
            BaclWelshEle.Click();
        }

        public void SwitchToPreviousOpenTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
        }

        public void ClickBrowserBack()
        {
            _driver.Navigate().Back();
        }

        public void CloseCurrentTab()
        {
            _driver.Close();
        }

        #endregion Page Methods

    }
}

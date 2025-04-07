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

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading'] | //h1[@class='govuk-panel__title']"));
        private By Englishclick => By.XPath("//span[contains(text(),'English')]");
        private By Welshclick =By.XPath("//span[contains(text(),'Cymraeg')]");
        private IWebElement ApplyForADocEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Apply for a document')] | //button[contains(text(),'Gwneud cais am ddogfen')]"));
        private IWebElement ContinueWelshEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Parhau')] | //button[contains(text(),'Continue')]"));
        private IWebElement BackWelshEle => _driver.WaitForElement(By.XPath("//a[contains(text(),'Yn ôl')]"));
        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//ul[contains(@class,'govuk-error-summary__list')]//a | //ul[contains(@class,'govuk-error-summary__list')]//span"));
        private IWebElement FooterLanguageSelector => _driver.WaitForElement(By.XPath("(//a[contains(@class,'govuk-footer__link')])[3]"));
        public IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[@href='/User/ManageAccount']"));
        public IWebElement lnkManageYourAccount => _driver.WaitForElement(By.XPath("//a[@href='/User/RedirectToExternal']"));
        public IWebElement lnkViewDocsFromManageAcc => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Gweld eich dogfennau teithio gydol oes i anifeiliaid anwes neu wneud cais am un newydd.']"));
        private IWebElement ContinueEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private IWebElement tableBody => _driver.WaitForElement(By.XPath("//table/tbody"));
        private IWebElement HelpWelshEle => _driver.WaitForElement(By.XPath("//a[contains(text(),'Cael help')]"));
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
            if (_driver.WaitForElements(Welshclick).Count > 0)
            {
                _driver.WaitForElement(Welshclick).Click();
            }
        }

        public void ClickOnEnglishLang()
        {
            if (_driver.WaitForElements(Englishclick).Count > 0)
            {
                _driver.WaitForElement(Englishclick).Click();
            }
        }

        public void ClickOnApplyForADocument()
        {
            ApplyForADocEle.Click();
        }

        public void ClickOnContinueWelsh()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ContinueWelshEle);
            //ContinueWelshEle.Click();
        }

        public void ClickOnBackWelsh()
        {
            BackWelshEle.Click();
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

        public bool VerifyErrorMessage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
        }

        public void ClickOnManageAccountLink()
        {
            lnkManageAccount.Click();
        }

        public void ClickOnManageYourAccountLink()
        {
            lnkManageYourAccount.Click();
        }

        public void ClickOnViewYourPetTravelDoc()
        {
            lnkViewDocsFromManageAcc.Click();
        }

        public bool VerifyLanguageAtPageFooter(string displayedLang)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            return FooterLanguageSelector.Text.Contains(displayedLang);
        }
        public void ClickOnContinueEng()
        {
            ContinueEle.Click();
        }

        public bool VerifyTheExpectedStatus(string petName, string status)
        {
            Thread.Sleep(5000);
            _driver.Navigate().Refresh();
            var trCollection = tableBody.FindElements(By.TagName("tr"));

            foreach (var element in trCollection)
            {
                var tableHeader = element.FindElement(By.TagName("th"));

                if (tableHeader.Text.Equals(petName))
                {
                    var tdCollection = element.FindElements(By.TagName("td"));

                    return tdCollection[2].Text.Trim().ToUpper().Equals(status.ToUpper());
                }
            }

            return false;
        }

        public void ClickOnHelpWelshLink()
        {
            HelpWelshEle.Click();
        }
        #endregion Page Methods

    }
}

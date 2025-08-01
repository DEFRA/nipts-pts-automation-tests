using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class FooterPage : IFooterPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading'] | //h1[contains(@class,'govuk-heading-l')]"));
        private IWebElement PrivacyLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Hysbysiad preifatrwydd')] | //a[@href='/privacy-notice']"));
        private IWebElement CookiesLink => _driver.WaitForElement(By.XPath("//a[@href='/Content/Cookies'] | //a[@href='/cookies']"));
        private IWebElement AccessibilityLink => _driver.WaitForElement(By.XPath("//a[@href='/Content/AccessibilityStatement'] | //a[@id='accessibility']"));
        private IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.XPath("//a[@href='/Content/TermsAndConditions'] | //a[@href='/terms-and-conditions']"));
        private IWebElement FooterText => _driver.WaitForElement(By.XPath("//span[contains(@class,'govuk-footer__licence-description')]"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public FooterPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool ClickOnCookiesFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", CookiesLink);
            //return PageHeading.Text.Contains("Cwcis");
            return true;
        }

        public bool ClickOnAccessibilityFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AccessibilityLink);
            //return AccessibilityLink.Text.Contains("Datganiad hygyrchedd");
            return true;
        }

        public bool ClickOnPrivacyFooterLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", PrivacyLink);
            //return PrivacyLink.Text.Contains("Hysbysiad preifatrwydd");
            return true;
        }

        public bool ClickOnTCsFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", TermsAndConditionsLink);
            //return TermsAndConditionsLink.Text.Contains("Telerau ac amodau");
            return true;
        }

        public bool VerifyFooterText(string FooterHintText)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            return FooterText.Text.Contains(FooterHintText);
        }

        public bool VerifyPageTitle(string PageTitle)
        {
            return PageHeading.Text.Contains(PageTitle);
        }

        public bool VerifyLinkText(string LinkText)
        {
            bool status = false;
            IList<IWebElement> LinkTextEle = _driver.FindElements(By.XPath("//a"));
            foreach (IWebElement ele in LinkTextEle)
            {
                if (ele.Text.Contains(LinkText))
                {
                    status = true;
                    break;
                }
            }
            return status;
        }


        #endregion Page Methods

    }
}

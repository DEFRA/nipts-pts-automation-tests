using BoDi;
using Defra.UI.Framework.Driver;
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

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement PrivacyLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Hysbysiad preifatrwydd')]"));
        private IWebElement CookiesLink => _driver.WaitForElementExists(By.XPath("//a[contains(text(),'Cwcis')]"));
        private IWebElement AccessibilityLink => _driver.WaitForElement(By.XPath("//a[@href='/Content/AccessibilityStatement']"));
        private IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.XPath("//a[@href='/Content/TermsAndConditions']"));
        private IWebElement FooterText => _driver.WaitForElement(By.XPath("//span[contains(@class,'govuk-footer__licence-description')]"));
        public IWebElement YesRadiobtn => _driver.WaitForElementExists(By.CssSelector("#yes"));
        public IWebElement NoRadiobtn => _driver.WaitForElementExists(By.CssSelector("#no"));
        private IWebElement SaveGoogleAnlyticsbtn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save cookies settings')]"));
        private IWebElement GoogleAnalyticsHeading => _driver.WaitForElement(By.XPath("//p[contains(@class,'govuk-notification-banner__heading')]"));
        private IWebElement Accept_Cookies => _driver.WaitForElement(By.XPath("//button[contains(text(),'Accept additional cookies')]"));
        private IWebElement Reject_Cookies => _driver.WaitForElement(By.XPath("//button[contains(text(),'Reject additional cookies')]"));
        private IWebElement Hide_Cookies => _driver.WaitForElement(By.XPath("//button[contains(text(),'Hide cookie message')]"));
        private IWebElement ChangeCookieSettingsLink => _driver.WaitForElementExists(By.XPath("(//a[contains(text(),'change your cookie settings')])[2]"));

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
            return CookiesLink.Text.Contains("Cwcis");
        }

        public bool ClickOnAccessibilityFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", AccessibilityLink);
            return AccessibilityLink.Text.Contains("Datganiad hygyrchedd");
        }

        public bool ClickOnPrivacyFooterLink()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", PrivacyLink);
            return PrivacyLink.Text.Contains("Hysbysiad preifatrwydd");
        }

        public bool ClickOnTCsFooterLink()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", TermsAndConditionsLink);
            return TermsAndConditionsLink.Text.Contains("Telerau ac amodau");
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

        public void SelectGoogleAnalyticsOption(string googleAnalytics)
        {
            if (googleAnalytics.ToLower().Equals("yes"))
            {
                YesRadiobtn.Click();
            }
            else
            {
                NoRadiobtn.Click();
            }
        }

        public void ClickOnSaveGoogleAnalyticsBtn()
        {
            SaveGoogleAnlyticsbtn.Click();
        }

        public bool VerifyGoogleAnalyticsBanner(string BannerText)
        {
            return GoogleAnalyticsHeading.Text.Contains(BannerText);
        }

        public void SelectGoogleAnalyticsOptionOnHeader(string googleAnalyticsOption)
        {
            if (googleAnalyticsOption.ToLower().Equals("accept"))
            {
                Accept_Cookies.Click();
            }
            else
            {
                Reject_Cookies.Click();
            }
        }

        public void ClickOnHideCookiesBtn()
        {
            Hide_Cookies.Click();
        }

        public void ClickChangeCookieSettingslnk()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", ChangeCookieSettingsLink);

        }

        public bool VerifyHideCookieMessageButtonOnGoogleAnalyticsBanner()
        {
            try
            {
                if (Hide_Cookies.Displayed)
                    return true;
                else return false;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
        }

       
        #endregion Page Methods

    }
}

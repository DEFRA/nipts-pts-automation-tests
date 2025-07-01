using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages
{
    public class HeaderPage : IHeaderPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement GOVLink => _driver.WaitForElement(By.XPath("//*[name()='svg' and @class='govuk-header__logotype']"));
        private IWebElement Feedbacktext => _driver.WaitForElement(By.XPath("//div[@class='QuestionText BorderColor']//p"));
        private IWebElement FeedbackHeading => _driver.WaitForElement(By.XPath("//div[@class='QuestionText BorderColor']//h1"));
        private IWebElement GOVUKPage => _driver.WaitForElement(By.XPath("//a[@href='https://www.gov.uk']"));
        private IWebElement GenericGOVPage => _driver.WaitForElement(By.XPath("//span[contains(@class,'homepage-header__intro')]"));
        private IWebElement feedbacklink => _driver.WaitForElement(By.XPath("//a[contains(text(),' adborth (yn agor mewn tab newydd)')]"));
        private IWebElement HeaderTitle => _driver.WaitForElement(By.XPath("//div[@class='govuk-header__content']/a[contains(@class,'govuk-header')]"));
        private IWebElement HeaderBanner => _driver.WaitForElement(By.XPath("//span[@class='govuk-phase-banner__text']"));
        private IWebElement CookiesBannerHeaderText => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-grid-column-two-thirds')]//h2"));
        private IWebElement CookiesBannerText => _driver.WaitForElement(By.XPath("(//div[contains(@class,'govuk-cookie-banner__content')]//p)[3]"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public HeaderPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public void ClickGOVHeaderLink()
        {
            GOVLink.Click();
        }

        public void ClickOnFeedBackLink()
        {
            feedbacklink.Click();
        }

        public bool VerifyFeedbackPageLoaded()
        {
            return FeedbackHeading.Text.Contains("Give feedback on Taking a pet from Great Britain to Northern Ireland");
        }

        public bool? VerifyFeedbackPageText(string text)
        {
            return Feedbacktext.Text.Contains(text);
        }

        public bool? VerifyLinkOnFeedbackPage(string link)
        {
            string Feedbacklink = $"//a[contains(text(),'{link}')]";
            if (_driver.FindElements(By.XPath(Feedbacklink)).Count() > 0)
                return true;
            else 
                return false;
        }

        public bool VerifyGenericGOVPageLoaded()
        {
            if (GOVUKPage.Enabled && GenericGOVPage.Text.Contains("The best place to find government services and information"))
                return true;
            else
                return false;
        }

        public bool VerifyHeaderTitle(string pageTitle)
        {
            return HeaderTitle.Text.Contains(pageTitle);
        }

        public bool VerifyHeaderBanner(string bannerText)
        {
            return HeaderBanner.Text.Contains(bannerText);
        }

        public void DeleteBrowserCookies()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        public bool VerifyCookiesBannerWelsh(string cookiesWELSHText)
        {
            return CookiesBannerHeaderText.Text.Contains(cookiesWELSHText);
        }

        public bool VerifyCookiesPrefTextWelsh(string cookiesText)
        {
            string CookiesText = "//p[contains(text(),'" + cookiesText + "')]";
            return _driver.WaitForElement(By.XPath(CookiesText)).Text.Contains(cookiesText);
        }

        public void ClickCookiesPrefButton(string prefBtn)
        {
            string CookiesPref = "//button[contains(text(),'" + prefBtn + "')]";
            _driver.WaitForElement(By.XPath(CookiesPref)).Click();
        }

        #endregion Page Methods

    }
}

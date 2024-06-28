using BoDi;
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
        private IWebElement Feedbacktext => _driver.WaitForElement(By.XPath("//div[@id='QID3']//div[@class='QuestionText BorderColor']"));
        private IWebElement GenericGOVPage => _driver.WaitForElement(By.XPath("//span[contains(@class,'govuk-!-margin-bottom-2 govuk-!-display-block')]"));
        private IWebElement feedbacklink => _driver.WaitForElement(By.XPath("//a[contains(text(),'eich adborth')]"));
        private IWebElement HeaderTitle => _driver.WaitForElement(By.XPath("//div[@class='govuk-header__content']/a[contains(@class,'govuk-header')]"));
        private IWebElement HeaderBanner => _driver.WaitForElement(By.XPath("//span[@class='govuk-phase-banner__text']"));

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
            return Feedbacktext.Text.Contains("Overall, how did you feel about the service you used today?");
        }

        public bool VerifyGenericGOVPageLoaded()
        {
            return GenericGOVPage.Text.Contains("GOV.UK");
        }

        public bool VerifyHeaderTitle(string pageTitle)
        {
            return HeaderTitle.Text.Contains(pageTitle);
        }

        public bool VerifyHeaderBanner(string bannerText)
        {
            return HeaderBanner.Text.Contains(bannerText);
        }

        #endregion Page Methods

    }
}

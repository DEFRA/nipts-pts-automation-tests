using BoDi;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Tools;


namespace nipts_pts_automation_tests.Pages
{
    public class ApplicationPage : IApplicationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
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

        #endregion Page Methods

    }

}

using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class WelcomePage : IWelcomePage
    {
        private readonly IObjectContainer _objectContainer;

        public WelcomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(text(),'Checks')]"));
        private IWebElement iconSearch => _driver.WaitForElement(By.XPath("//a[@href='/checker/document-search']//*[name()='svg']"));
        private IWebElement iconHome => _driver.WaitForElement(By.XPath("//span[normalize-space()='Home']"));
        private IWebElement lnkHeadersChange => _driver.WaitForElement(By.XPath("//a[normalize-space()='Change']"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Checks");
        }

        public void FooterSearchButton()
        {
            iconSearch.Click();
        }

        public void HeadersChangeLink()
        {
            lnkHeadersChange.Click();
        }

        public void FooterHomeIcon()
        {
            iconHome.Click();
        }
        #endregion
    }
}

using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.ApplicationSubmittedPage
{
    public class ApplicationSubmissionPage : IApplicationSubmissionPage
    {
        private readonly IObjectContainer _objectContainer;
        public ApplicationSubmissionPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.ClassName("govuk-panel__title"), true);
        private IWebElement lblUniqueReferenceNumber => _driver.WaitForElement(By.XPath("//div[@class='govuk-panel__body']/strong"));
        private IWebElement lnkApplyForAnother => _driver.WaitForElement(By.XPath("//a[contains(text(),'Apply for another')]"));
        private IWebElement lnkViewAllSubmittedApplications => _driver.WaitForElement(By.XPath("//a[contains(text(),'View all your lifelong')]"));
        private IWebElement SubmittedPageHeading => _driver.WaitForElement(By.XPath("//h1[@id='documents']"));
        #endregion

        #region Methods

        public bool VerifyApplicationSubmittedPageTitle(string pageTitle)
        {
            return SubmittedPageHeading.Text.Contains(pageTitle);
        }
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }
        public string GetApplicationReferenceNumber()
        {
            return lblUniqueReferenceNumber.Text;
        }
        public void ClickApplyForAnotherPetTravelDocument()
        {
            lnkApplyForAnother.Click();
        }
        public void ClickViewAllSubmittedPetTravelDocument()
        {
            lnkViewAllSubmittedApplications.Click();
        }

        #endregion
    }
}
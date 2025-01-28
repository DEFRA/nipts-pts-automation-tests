using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using System.Data;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class ApplicationSummaryPage : IApplicationSummaryPage
    {
        private readonly IObjectContainer _objectContainer;

        public ApplicationSummaryPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement rdoPass => _driver.WaitForElement(By.XPath("//label[normalize-space()='Pass']"));
        private IWebElement rdoFail => _driver.WaitForElement(By.XPath("//label[normalize-space()='Fail or referred to SPS']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//*[@id='saveAndContinue']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        #endregion

        #region Methods
        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"(//h1[normalize-space()='{status}'])[1]")).Text.Trim().Equals(status);
        }

        public bool VerifyTheExpectedSubtitle(string applicationSubtitle)
        {
            return _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-panel__title')]/../following-sibling::h1")).Text.Trim().Equals(applicationSubtitle);
        }

        public void SelectPassRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoPass);
            rdoPass.Click();
        }
        public void SelectFailRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoFail);
            rdoFail.Click();
        }

        public void SelectSaveAndContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnSaveAndContinue);
            btnSaveAndContinue.Click();
        }

        public void SelectContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnContinue);
            btnContinue.Click();
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

        public string getNewID()
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string getNewId = "SELECT NEWID()";
            string NewIdString = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                NewIdString = dataHelperConnections.ExecuteQuery(connectionString, getNewId);
            }
            return NewIdString;
        }

        #endregion
    }
}

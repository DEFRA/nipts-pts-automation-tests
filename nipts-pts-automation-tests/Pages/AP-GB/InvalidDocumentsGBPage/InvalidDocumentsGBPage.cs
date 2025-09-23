using Defra.UI.Framework.Driver;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using Reqnroll.BoDi;


namespace nipts_pts_automation_tests.Pages.AP_GB.InvalidDocumentsGBPage
{
    public class InvalidDocumentsGBPage : IInvalidDocumentsGBPage
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public InvalidDocumentsGBPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects

        #endregion

        #region Methods

        public bool VerifyStatusOnInvalidDocsPTD(string fieldName, string fieldValue)
        {
            string FieldName = "(//dt[contains(text(),'Status')])";
            string FieldValue = "((//dt[contains(text(),'Status')]))/following-sibling::dd[1]";
            return (_driver.WaitForElement(By.XPath(FieldName)).Text.Contains(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue));
        }

        #endregion
    }
}

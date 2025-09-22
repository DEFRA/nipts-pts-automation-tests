using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages
{
    public class InvalidDocumentsPage : IInvalidDocumentsPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;

        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement lnkInvalidDocs => _driver.WaitForElement(By.XPath("//a[contains(text(),'Gweld dogfennau annilys')] | //a[contains(text(),'View invalid documents')]"));
        private IReadOnlyCollection<IWebElement> tableRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr"), true);
        private IReadOnlyCollection<IWebElement> tableHeaderRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/th"), true);
        private IReadOnlyCollection<IWebElement> tableActionRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/td[2]//a"), true);

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public InvalidDocumentsPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
       
        public void ClickOnViewInvalidDocumentLinkWELSH()
        {
            
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", lnkInvalidDocs);
        }

        public void ClickViewLnkInvalidDocPage(string petName)
        {
            IWebElement? lnkview = null;

            var rowCount = tableRows.Count - 1;

            for (var elementIndex = rowCount; elementIndex > 0; elementIndex--)
            {
                
                var tableHeader = tableHeaderRows.ElementAt(0).Text.Replace("\r\n", string.Empty).Trim().ToUpper();

                if (tableHeader.Equals(petName.ToUpper()))
                {
                    lnkview = tableActionRows.ElementAt(0);

                    break;
                }
            }

            lnkview?.Click();
            Thread.Sleep(2000);
        }

        public bool VerifyStatusOnInvalidDocsPTDWELSH(string fieldName, string fieldValue)
        {
            string FieldName = "(//dt[contains(text(),'Statws')])";
            string FieldValue = "((//dt[contains(text(),'Statws')]))/following-sibling::dd[1]";
            return (_driver.WaitForElement(By.XPath(FieldName)).Text.Contains(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue));
        }


        public bool VerifyNewApplInvalidPage(string petName)
        {
            var tableHeader = tableHeaderRows.ElementAt(0).Text.Replace("\r\n", string.Empty).Trim().ToUpper();

            if ((tableHeader.ToUpper()).Equals(petName.ToUpper()) || (tableHeader.Equals(petName)))
            {
                return true;
            }
            else { 
                return false;
                 }
            
        }

        #endregion Page Methods

    }
} 

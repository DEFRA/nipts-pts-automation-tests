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
            // The "View invalid documents" link only appears on the DASHBOARD once the asynchronous
            // backend revoke (Service Bus message -> Dynamics) has moved the document into the
            // invalid/cancelled bucket. The preceding "click on back" can leave the session on the
            // application-details page (not the dashboard), so a plain Refresh would poll the wrong
            // page forever. Navigate to the dashboard each iteration and poll by presence until the
            // link lands, then JS-click it.
            var linkBy = By.XPath("//a[contains(text(),'Gweld dogfennau annilys')] | //a[contains(text(),'View invalid documents')]");
            var appUrl = ConfigSetup.BaseConfiguration.TestConfiguration.AppPortalUrl;
            var globalWaits = ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds;
            var deadline = DateTime.UtcNow.AddSeconds(globalWaits * 4);
            IWebElement? link = null;

            while (DateTime.UtcNow < deadline)
            {
                try
                {
                    _driver.DismissTimeoutOverlayIfPresent();
                    link = _driver.FindElements(linkBy).FirstOrDefault();
                    if (link != null)
                        break;
                }
                catch (Exception ex) when (ex is StaleElementReferenceException
                                           || ex is NoSuchElementException
                                           || ex is WebDriverException)
                {
                    // Dashboard re-rendering or a slow/degraded session; re-check next iteration.
                }

                try
                {
                    if (!string.IsNullOrWhiteSpace(appUrl))
                        _driver.Navigate().GoToUrl(appUrl);
                    else
                        _driver.Navigate().Refresh();
                }
                catch (WebDriverException) { /* slow/wedged nav - retry next iteration */ }
                Thread.Sleep(3000);
            }

            if (link == null)
                throw new ElementNotVisibleException(
                    $"The 'View invalid documents' link did not appear within {globalWaits * 4}s (backend revoke latency).");

            var jsExecutor = (IJavaScriptExecutor)_driver;
            try { jsExecutor.ExecuteScript("arguments[0].scrollIntoView({block:'center'});", link); }
            catch (Exception) { }
            jsExecutor.ExecuteScript("arguments[0].click();", link);
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

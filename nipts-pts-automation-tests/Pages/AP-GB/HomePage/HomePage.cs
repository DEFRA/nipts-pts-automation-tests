using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages.AP_GB.HomePage
{
    public class HomePage : IHomePage
    {
        private readonly IObjectContainer _objectContainer;

        public HomePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"), true);
        public IWebElement btnApplyForDocumentButton => _driver.WaitForElement(By.ClassName("govuk-button"));
        public IWebElement FeedbackLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'feedback')]"));
        public IWebElement GetHelpLink => _driver.WaitForElement(By.ClassName("govuk-link--inverse"));
        public IWebElement GethelpHeader => _driver.WaitForElement(By.ClassName("govuk-heading-xl"));
        public IWebElement AccessibilityStatementLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Accessibility statement')]"));
        public IWebElement CookiesLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Cookies')]"));
        public IWebElement PrivacyNoticeLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Privacy notice')]"));
        public IWebElement TermsAndConditionsLink => _driver.WaitForElement(By.XPath("//a[contains(text(),'Terms and conditions')]"));
        public IWebElement CrownCopyrightLink => _driver.WaitForElement(By.XPath("/html/body/footer/div/div/div[2]/a"));
        private IWebElement btnApplyForDocument => _driver.WaitForElement(By.XPath("//button[contains(text(),'Apply for a document')]"), true);
        private IReadOnlyCollection<IWebElement> tableRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr"), true);
        private IReadOnlyCollection<IWebElement> tableHeaderRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/th"), true);
        private IReadOnlyCollection<IWebElement> tableActionRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/td[2]//a"), true);
        public IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[@href='/User/ManageAccount']"));
        public IWebElement lifelongPetTraveDocuments => _driver.WaitForElement(By.XPath("//li[@class='login-nav__list-item']//a[@href='/TravelDocument']"));
        public IWebElement SuspendedMsgEle => _driver.WaitForElement(By.XPath("//div[contains(@class,'govuk-warning-text')]/strong"));

        #endregion

        #region Methods

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Lifelong pet travel documents");
        }

        public void ClickFeedbackLink()
        {
            FeedbackLink.Click();
        }

        public void ClickGethelpLink()
        {
            GetHelpLink.Click();
        }

        public bool IsNextPageLoaded(string pageTitle)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
            return GethelpHeader.Text.Contains(pageTitle);
        }

        public void ClickAccessibilityStatementLink()
        {
            AccessibilityStatementLink.Click();
        }

        public void ClickCookiesLink()
        {
            CookiesLink.Click();
        }

        public void ClickPrivacyNoticeLink()
        {
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,5000)", "");
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", PrivacyNoticeLink);
            //PrivacyNoticeLink.Click();
        }

        public void ClickTermsAndConditionsLink()
        {
            TermsAndConditionsLink.Click();
        }

        public void ClickCrownCopyrightLink()
        {
            CrownCopyrightLink.Click();
        }

        public void ClickApplyForPetTravelDocument()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,300)", "");
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", btnApplyForDocument);
            //btnApplyForDocument.Click();
        }

        public bool VerifyTheExpectedStatus(string petName, string status)
        {
            // Status transitions (e.g. Pending -> Approved) are driven by an asynchronous backend
            // process (a Service Bus message consumed and written back to Dynamics), so the new
            // status is not visible immediately. Poll by refreshing and re-checking until the
            // expected status appears or the timeout elapses, rather than checking only once.
            var timeout = TimeSpan.FromMinutes(6);
            var pollInterval = TimeSpan.FromSeconds(5);
            var deadline = DateTime.UtcNow + timeout;

            do
            {
                _driver.Navigate().Refresh();
                Thread.Sleep(pollInterval);

                try
                {
                    if (IsStatusDisplayed(petName, status))
                        return true;
                }
                catch (Exception ex) when (ex is StaleElementReferenceException
                                           || ex is NoSuchElementException
                                           || ex is WebDriverException)
                {
                    // Table re-rendering, or a slow/degraded BrowserStack session making a single
                    // WebDriver command block (~90s command timeout) or drop the connection. Treat
                    // as "not ready yet" and re-check next iteration; the deadline bounds the wait.
                }
            }
            while (DateTime.UtcNow < deadline);

            return false;
        }

        private bool IsStatusDisplayed(string petName, string status)
        {
            // Locate the pet's status cell with a single direct XPath instead of iterating every
            // row and issuing a child FindElement per row. On a degraded session each WebDriver
            // command can block for the full command timeout (~90s), so a per-row loop could cost
            // (rows x 90s) per poll. FindElements returns empty (no throw) when the row is absent;
            // the last match is the most recent row (bottom of the table).
            var statusPath = $"//tr//th[contains(text(),'{petName}')]/../td[1]/strong";
            var cells = _driver.FindElements(By.XPath(statusPath));
            return cells.Count > 0
                   && cells[cells.Count - 1].Text.Replace("\r\n", string.Empty).Trim().ToUpper().Contains(status.ToUpper());
        }

        public bool VerifyTheApplicationIsNotAvailable(string petName)
        {
            _driver.Navigate().Refresh();
            //_driver.WaitForPageToLoad();
            Thread.Sleep(5000);
            _driver.Navigate().Refresh();
            //_driver.WaitForPageToLoad();

            var t = _driver.FindElements(By.XPath("//th[text() = '" + petName + "']")).Count;
            if (_driver.FindElements(By.XPath("//th[text() = '" + petName + "']")).Count.Equals(0))
            {
                return true;
            }
            return false;
        }

        public void ClickViewLink(string petName)
        {
            // Re-query the row collections on each attempt so a DOM re-render between
            // capturing the rows and clicking the link does not throw a stale element error.
            var lnkview = _driver.RetryOnStaleElement(() =>
            {
                IWebElement? link = null;

                var rowCount = tableRows.Count - 1;

                for (var elementIndex = 0; elementIndex <= rowCount; elementIndex++)
                {
                    var tableHeader = tableHeaderRows.ElementAt(elementIndex).Text.Replace("\r\n", string.Empty).Trim().ToUpper();

                    if (tableHeader.Equals(petName.ToUpper()))
                    {
                        link = tableActionRows.ElementAt(elementIndex);

                        break;
                    }
                }

                return link;
            });

            if (lnkview != null)
                _driver.SafeClick(lnkview);
            Thread.Sleep(2000);
        }

        public void ClickOnManageAccountLink()
        {
            lnkManageAccount.Click();
        }

        public void ClickOnLifelongPetTravelDocumentsFromHeader()
        {
            lifelongPetTraveDocuments.Click();
        }

        public bool VerifyTheLink(string link)
        {
            string outageLinkEle = $"//a[contains(text(),'{link}')]";
            if (_driver.FindElements(By.XPath(outageLinkEle)).Count > 0)
                return true;
            else
                return false;
        }

        public bool VerifyPTDTableHeading(string heading)
        {
            var headingEle = "//th[contains(text(),'" + heading + "')]";
            if (_driver.FindElements(By.XPath(headingEle)).Count > 0)
            {
                if (_driver.FindElement(By.XPath(headingEle)).Text.Equals(heading))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        public bool VerifySuspendedWarningMsg(string warningMsg)
        {
            String fontWeight = SuspendedMsgEle.GetCssValue("font-weight");
            Console.WriteLine($"FontSize: {fontWeight}");
            
            if(Int32.Parse(fontWeight) > 600 && SuspendedMsgEle.Text.Contains(warningMsg))
                return true;
            else
                return false;
        }

        public bool VerifyApplyBtnNotDisplayedSuspendedUser()
        {

            try
            {
                if (btnApplyForDocumentButton.Displayed)
                    return true;
                else return false;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
        }

        #endregion
    }
}

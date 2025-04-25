using BoDi;
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
        private IReadOnlyCollection<IWebElement> tableActionRows => _driver.WaitForElements(By.XPath("//table/tbody/descendant::tr/td[4]//a"), true);
        public IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[@href='/User/ManageAccount']"));
        public IWebElement lifelongPetTraveDocuments => _driver.WaitForElement(By.XPath("//li[@class='login-nav__list-item']//a[@href='/TravelDocument']"));

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

            _driver.Navigate().Refresh();
            //_driver.WaitForPageToLoad();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            var reversedTrCollection = tableRows.Reverse();

            foreach (var element in reversedTrCollection)
            {
                var tableHeader = element.FindElement(By.TagName("th"));

                if (tableHeader.Text.Replace("\r\n", string.Empty).Trim().ToUpper().Equals(petName.ToUpper()))
                {
                    var tdCollection = element.FindElements(By.TagName("td"));

                    return tdCollection[2].Text.Replace("\r\n", string.Empty).Trim().ToUpper().Equals(status.ToUpper());
                }
            }

            return false;
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
            IWebElement? lnkview = null;

            var rowCount = tableRows.Count - 1;

            for (var elementIndex = rowCount; elementIndex > 0; elementIndex--)
            {
                var tableHeader = tableHeaderRows.ElementAt(elementIndex).Text.Replace("\r\n", string.Empty).Trim().ToUpper();

                if (tableHeader.Equals(petName.ToUpper()))
                {
                    lnkview = tableActionRows.ElementAt(elementIndex);

                    break;
                }
            }

            lnkview?.Click();
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


        #endregion
    }
}
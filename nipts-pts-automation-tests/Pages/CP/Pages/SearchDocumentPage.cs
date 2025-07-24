using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;


namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class SearchDocumentPage : ISearchDocumentPage
    {
        private readonly IObjectContainer _objectContainer;

        public SearchDocumentPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement btnSearch => _driver.WaitForElement(By.XPath("//button[normalize-space()='Search']"));
        private IWebElement btnClearSearch => _driver.WaitForElement(By.XPath("//a[@id='clearSearchButton']"));
        private IWebElement txtPTDSearchBox => _driver.WaitForElementExists(By.XPath("//input[@id='ptdNumberSearch']"));
        private IWebElement txtApplicationNumberSearchBox => _driver.WaitForElement(By.XPath("//input[@id='applicationNumberSearch']"));
        private IWebElement txtMicrochipNumberSearchBox => _driver.WaitForElement(By.XPath("//input[@id='microchipNumber']"));
        private By rdoPTDInput => By.XPath("//input[@id='documentSearch-1'][@aria-labelledby='documentSearch-1-label'][@aria-expanded='false']");
        private IWebElement rdoPTDNumber => _driver.WaitForElementExists(By.XPath("//label[@id='documentSearch-1-label'][normalize-space()='Search by PTD number']"));
        private By rdoApplicationInput => By.XPath("//input[@id='documentSearch-2'][@aria-labelledby='documentSearch-2-label'][@aria-expanded='false']");
        private IWebElement rdoApplicatioNumbere => _driver.WaitForElementExists(By.XPath("//label[@id='documentSearch-2-label'][normalize-space()='Search by application number']"));
        private By rdoMicrochipInput => By.XPath("//input[@id='documentSearch-3'][@aria-labelledby='documentSearch-3-label'][@aria-expanded='false']");
        private IWebElement rdoMicrochipNumbere => _driver.WaitForElementExists(By.XPath("//label[@id='documentSearch-3-label'][normalize-space()='Search by microchip number']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Find a document");
        }
        public void SelectSearchRadioOption(string radioButtonValue)
        {
            if (radioButtonValue == "Search by PTD number")
            {
                if (_driver.FindElements(rdoPTDInput).Count>0)
                {
                    rdoPTDNumber.Click();
                }
            }
            else if (radioButtonValue == "Search by application number")
            {
                if (!rdoApplicatioNumbere.Selected)
                {
                    if (_driver.FindElements(rdoApplicationInput).Count > 0)
                    {
                        rdoApplicatioNumbere.Click();
                    }
                }
            }
            else if (radioButtonValue == "Search by microchip number")
            {
                if (!rdoMicrochipNumbere.Selected)
                {
                    if (_driver.FindElements(rdoMicrochipInput).Count > 0)
                    {
                        rdoMicrochipNumbere.Click();
                    }
                }
            }
        }
        public void EnterPTDNumber(string ptdNumber1)
        {
            txtPTDSearchBox.SendKeys(ptdNumber1);
        }

        public void EnterMicrochipNumber(string microchipNumber)
        {
            txtMicrochipNumberSearchBox.SendKeys(microchipNumber);
        }

        public void EnterApplicationNumber(string applicationNumber)
        {
            
            txtApplicationNumberSearchBox.SendKeys(applicationNumber);
        }

        public void SearchButton()
        {

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,2000)", "");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", btnSearch);
        }

        public void ClearSearchButton()
        {
            btnClearSearch.Click();
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

        public bool VerifyTextOnSearchDocPage(string textboxValue,string radioButtonValue)
        {
            if (radioButtonValue == "Search by PTD number")
            {
                string ptdNumberVal = txtPTDSearchBox.GetAttribute("value");
                return ptdNumberVal.Equals(textboxValue);
            }
            else if (radioButtonValue == "Search by application number")
            {
                string appNumberVal = txtApplicationNumberSearchBox.GetAttribute("value");
                return appNumberVal.Equals(textboxValue);
            }
            else if (radioButtonValue == "Search by microchip number")
            {
                string microchipNumberVal = txtMicrochipNumberSearchBox.GetAttribute("value");
                return microchipNumberVal.Equals(textboxValue);
            }
            return false;
        }
        #endregion
    }
    }


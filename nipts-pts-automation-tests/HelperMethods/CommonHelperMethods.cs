using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.HelperMethods
{
    public static class CommonHelperMethods
    {
        public static void SelectFromDropdown(this IWebDriver driver, IWebElement Element, string Text)
        {
            SelectElement dropDown = new SelectElement(Element);
            dropDown.SelectByText(Text);
        }
        public static void ClickRadioButton(this IWebDriver driver, string code)
        {
            // Re-find the label on each attempt: the outcome pages can re-render between locating
            // the label and the JS click, staling the reference ("element does not exist in cache").
            driver.RetryOnStaleElement(() =>
            {
                IWebElement commLabel = driver.WaitForElement(By.XPath($"//label[contains(.,'{code}')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", commLabel);
                return true;
            });
        }

        public static void ClickFristRadioButton(this IWebDriver driver, string code)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(d => d.FindElement(By.XPath($"//label[contains(text(),'{code}')]")).Text.Contains(code));
        }

        public static void ContinueButton(this IWebDriver driver)
        {
            IWebElement? continueLabel = null;
            try
            {
                continueLabel = driver.WaitForElement(By.ClassName("govuk-button"), true);
            }
            catch
            {
                continueLabel = driver.FindElement(By.ClassName("govuk-button"));
            }

            continueLabel.Click();
        }
    }

}

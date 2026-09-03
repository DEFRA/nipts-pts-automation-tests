using System.Linq;
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
            var js = (IJavaScriptExecutor)driver;
            // Click the radio input directly and confirm it is selected. A JS click on the govuk
            // label alone does not reliably toggle the (visually hidden) input on mobile, which left
            // the form invalid and blocked navigation to the next page. Re-find each attempt so a
            // mid-poll re-render can't stale the reference.
            driver.RetryOnStaleElement(() =>
            {
                IWebElement commLabel = driver.WaitForElement(By.XPath($"//label[contains(.,'{code}')]"));
                js.ExecuteScript("arguments[0].scrollIntoView({block:'center'});", commLabel);

                var inputId = commLabel.GetAttribute("for");
                IWebElement? input = string.IsNullOrEmpty(inputId)
                    ? null
                    : driver.FindElements(By.Id(inputId)).FirstOrDefault();

                if (input != null)
                {
                    js.ExecuteScript("arguments[0].click();", input);
                    if (!input.Selected)
                        js.ExecuteScript("arguments[0].click();", commLabel);
                }
                else
                {
                    js.ExecuteScript("arguments[0].click();", commLabel);
                }
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

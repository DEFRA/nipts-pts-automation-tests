using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using SeleniumExtras.WaitHelpers;


namespace nipts_pts_automation_tests.HelperMethods
{
    internal static class Waits
    {
        private static int GlobalWaits => ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds;

        public static IWebElement WaitForElement(this IWebDriver driver, By elementBy, bool forceWait = false)
        {
            try
            {
                if (forceWait)
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                return driverWait.Until(ExpectedConditions.ElementIsVisible(elementBy));
            }
            catch (Exception ex)
            {
                throw new ElementNotVisibleException("Element is not visible");
            }
        }

        public static IReadOnlyCollection<IWebElement> WaitForElements(this IWebDriver driver, By elementBy, bool forceWait = false)
        {
            try
            {
                if (forceWait)
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                driverWait.Until(ExpectedConditions.ElementIsVisible(elementBy));
                return driver.FindElements(elementBy);
            }
            catch (Exception ex)
            {
                throw new ElementNotVisibleException("Element is not visible");
            }
        }

        public static TResult WaitForElementCondition<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                return driverWait.Until(condition);
            }
            catch (Exception ex)
            {
                throw new Exception("Element exception " + ex.Message);
            }
        }

        public static void WaitForAjax(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public static bool WaitForSpinnerToAppearAndDisappear(this IWebDriver driver, By elementBy)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                return driverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementBy));
            }
            catch (Exception ex)
            {
                throw new Exception("Loading spinner has not disappeared" + ex);
            }
        }

        public static void ElementImplicitWait(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public static IWebElement WaitForElementClickable(this IWebDriver driver, By elementBy)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                return driverWait.Until(ExpectedConditions.ElementToBeClickable(elementBy));
            }
            catch (Exception ex)
            {
                throw new Exception("Element exception " + ex.Message);
            }
        }

        public static IWebElement WaitForElementExists(this IWebDriver driver, By elementBy, bool forceWait = false)
        {
            try
            {
                if (forceWait)
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                return driverWait.Until(ExpectedConditions.ElementExists(elementBy));
            }
            catch (Exception ex)
            {
                throw new ElementNotVisibleException("Element is not visible");
            }
        }
    }

}

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using SeleniumExtras.WaitHelpers;


namespace nipts_pts_automation_tests.HelperMethods
{
    internal static class Waits
    {
        private static int GlobalWaits => ConfigSetup.BaseConfiguration.TestConfiguration.GlobalWaitsInSeconds;

        // Ground truth captured from the live BrowserStack session (see CaptureDeviceFromDriver).
        // Set once per scenario when the driver is created; true only when caps positively say iOS.
        private static bool _isIosFromDriver;

        /// <summary>
        /// Reads the real platform from the live BrowserStack session capabilities and latches it for
        /// <see cref="IsIosDevice"/>. This is the reliable signal: in CI the artifact's appsettings
        /// DeviceName can be stale/unpatched (it read back non-iOS on a real iPhone 14, so the iOS
        /// heals were silently disabled and sign-in only got the 90s budget). Called once per
        /// scenario right after the driver is created. Only ever latches TRUE so it can never
        /// downgrade a correct config value; logs the probed caps so CI is self-diagnosing.
        /// </summary>
        public static void CaptureDeviceFromDriver(IWebDriver driver)
        {
            try
            {
                if (driver is not IHasCapabilities hasCaps)
                    return;

                var caps = hasCaps.Capabilities;
                var probe = string.Join(" | ", new[]
                    {
                        "platformName", "platform", "os", "osVersion", "deviceName",
                        "device", "browserName", "realMobile"
                    }
                    .Select(k => $"{k}={caps.GetCapability(k)}"));

                var isIos = probe.IndexOf("ios", StringComparison.OrdinalIgnoreCase) >= 0
                            || probe.IndexOf("iphone", StringComparison.OrdinalIgnoreCase) >= 0
                            || probe.IndexOf("ipad", StringComparison.OrdinalIgnoreCase) >= 0;

                if (isIos)
                    _isIosFromDriver = true;

                Console.WriteLine($"CaptureDeviceFromDriver: isIos={isIos}, caps=[{probe}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine("CaptureDeviceFromDriver failed (keeping config detection): " + ex.Message);
            }
        }

        /// <summary>
        /// True when the run is on a real iOS device (iPhone/iPad). iOS Safari/WebKit on
        /// BrowserStack is materially slower through the Government Gateway sign-in redirect chain
        /// and uniquely pops native prompts (e.g. the "Save Password" sheet) that block WebDriver
        /// commands. Heading polls key off this to wait longer and to dismiss native alerts, which is
        /// why every other platform passes while iOS was flaking. Prefers the live-session capability
        /// latch (CaptureDeviceFromDriver) and falls back to the configured DeviceName, so a stale
        /// appsettings value in CI can no longer silently disable the iOS heals.
        /// </summary>
        public static bool IsIosDevice()
        {
            if (_isIosFromDriver)
                return true;

            var device = ConfigSetup.BaseConfiguration.TestConfiguration.DeviceName ?? string.Empty;
            return device.IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0
                || device.IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Best-effort dismissal of a native browser/OS alert. On iOS Safari the native "Save
        /// Password"/AutoFill sheet appears right after a Government Gateway sign-in and blocks every
        /// subsequent WebDriver command - which is exactly why reading the URL returned
        /// '(unavailable)' and the home page heading never confirmed on iOS while all other platforms
        /// passed. Dismissing (then accepting as a fallback) clears the sheet so the session can
        /// proceed. Never throws, so it is safe to call inside every poll iteration.
        /// </summary>
        public static void DismissNativeAlertIfPresent(this IWebDriver driver)
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                try { alert.Dismiss(); }
                catch (Exception) { try { alert.Accept(); } catch (Exception) { } }
            }
            catch (NoAlertPresentException) { /* nothing blocking - the common case */ }
            catch (Exception) { /* never throw from best-effort dismissal */ }
        }

        public static IWebElement WaitForElement(this IWebDriver driver, By elementBy, bool forceWait = false)
        {
            try
            {
                if (forceWait)
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                var element = driverWait.Until(ExpectedConditions.ElementIsVisible(elementBy));
                // Clear any HMRC session-timeout dialog now, before the caller clicks the element,
                // so a raw .Click() is not intercepted by the dialog on slower (Android) sessions.
                driver.DismissTimeoutOverlayIfPresent();
                return element;
            }
            catch (Exception)
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
            catch (Exception)
            {
                throw new ElementNotVisibleException("Element is not visible");
            }
        }

        /// <summary>
        /// Robust page-loaded check for mobile/BrowserStack: polls for a heading (h1 or fieldset
        /// legend) whose text contains <paramref name="pageTitle"/>. Reads textContent as a fallback
        /// because govuk headings frequently report Displayed=false on mobile, which makes strict
        /// visibility waits (WaitForElement forceWait) throw "Element is not visible" even though the
        /// page has loaded. Waits GlobalWaits*3 to tolerate ~2x slower mobile renders, ignores stale
        /// re-renders mid-poll, and never throws - it returns false if the heading never appears.
        /// </summary>
        public static bool IsHeadingLoaded(this IWebDriver driver, string pageTitle)
        {
            try { driver.WaitForAjax(); } catch (Exception) { /* best-effort readiness check */ }
            var headingBy = By.XPath("//h1 | //legend");
            // iOS Safari is ~2-3x slower through the sign-in/redirect chain than every other
            // platform, so give it a much larger budget (x6) before declaring the heading missing;
            // other platforms keep the proven x3. This is the single biggest reason iOS was the only
            // pipeline flaking on "page not loaded".
            var headingWaitMultiplier = IsIosDevice() ? 6 : 3;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits * headingWaitMultiplier));
            try
            {
                return wait.Until(d =>
                {
                    try
                    {
                        // A native iOS Safari prompt (e.g. "Save Password") can block every command
                        // and stall the whole poll; clear it first each iteration so the session
                        // keeps responding.
                        d.DismissNativeAlertIfPresent();
                        // On slow runs the HMRC session-timeout dialog can appear on the page during
                        // this poll, covering the heading and (if left) redirecting to a signed-out
                        // page - dismiss it each iteration so the session stays alive and the heading
                        // stays visible.
                        d.DismissTimeoutOverlayIfPresent();
                        return d.FindElements(headingBy).Any(h =>
                        {
                            var text = h.Text;
                            if (string.IsNullOrEmpty(text)) text = h.GetAttribute("textContent") ?? string.Empty;
                            return text.Contains(pageTitle);
                        });
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                });
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Executes the supplied function and retries it if a
        /// <see cref="StaleElementReferenceException"/> is thrown. This protects against
        /// elements being re-rendered between being located and being used, which happens
        /// frequently on slower (e.g. mobile/Android) BrowserStack sessions.
        /// The function should re-query any elements it uses on each attempt so that fresh,
        /// non-stale references are obtained.
        /// </summary>
        public static TResult RetryOnStaleElement<TResult>(this IWebDriver driver, Func<TResult> action, int maxAttempts = 3)
        {
            StaleElementReferenceException? lastException = null;
            for (var attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    return action();
                }
                catch (StaleElementReferenceException ex)
                {
                    lastException = ex;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }

            throw lastException ?? new StaleElementReferenceException("Element remained stale after retries");
        }

        private static readonly By TimeoutOverlayBy = By.CssSelector("#hmrc-timeout-overlay, .hmrc-timeout-overlay, #hmrc-timeout-dialog, .hmrc-timeout-dialog");
        private static readonly By TimeoutKeepSignedInBy = By.CssSelector("#hmrc-timeout-keep-signin-btn, .hmrc-timeout-keep-signin-btn");

        /// <summary>
        /// The HMRC session timeout warning renders a full page overlay (id="hmrc-timeout-overlay")
        /// and a modal dialog (id="hmrc-timeout-dialog") - either of which intercepts clicks. It
        /// appears more frequently on slower (e.g. mobile/Android) BrowserStack sessions. This keeps
        /// the user signed in (clicking "Stay signed in" when available, falling back to the button
        /// text) and waits for the dialog/overlay to disappear so subsequent clicks are not
        /// intercepted. It is best-effort and never throws, so callers can safely invoke it before
        /// any click.
        /// </summary>
        public static void DismissTimeoutOverlayIfPresent(this IWebDriver driver)
        {
            try
            {
                var overlays = driver.FindElements(TimeoutOverlayBy);
                if (!overlays.Any(o => o.Displayed))
                    return;

                // Keep the session alive by clicking "Stay signed in". Prefer the known id/class;
                // fall back to any visible button/link in the dialog whose text keeps the session.
                var keepSignedIn = driver.FindElements(TimeoutKeepSignedInBy).FirstOrDefault(b => b.Displayed)
                    ?? driver.FindElements(By.CssSelector("#hmrc-timeout-dialog button, #hmrc-timeout-dialog a"))
                        .FirstOrDefault(b => b.Displayed
                            && (b.Text.IndexOf("Stay signed in", StringComparison.OrdinalIgnoreCase) >= 0
                                || b.Text.IndexOf("Continue", StringComparison.OrdinalIgnoreCase) >= 0));
                if (keepSignedIn != null)
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", keepSignedIn);

                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                driverWait.Until(d =>
                {
                    try
                    {
                        var current = d.FindElements(TimeoutOverlayBy);
                        return current.Count == 0 || current.All(o => !o.Displayed);
                    }
                    catch (StaleElementReferenceException)
                    {
                        return true;
                    }
                });
            }
            catch (Exception)
            {
                // Best-effort dismissal - never fail a test purely because overlay handling errored.
            }
        }

        /// <summary>
        /// Clicks an element after dismissing the HMRC session timeout overlay if it is
        /// intercepting clicks. Falls back to a JavaScript click when the native click is still
        /// intercepted, which is common on slower mobile/Android sessions.
        /// </summary>
        public static void SafeClick(this IWebDriver driver, IWebElement element)
        {
            driver.DismissTimeoutOverlayIfPresent();
            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                driver.DismissTimeoutOverlayIfPresent();
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
                try
                {
                    element.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                }
            }
        }

        public static TResult WaitForElementCondition<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition)
        {
            try
            {
                WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalWaits));
                // A re-render mid-poll (common on mobile/Android) can stale elements the predicate
                // touches; keep polling instead of failing the step.
                driverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
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
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.ToString() == "complete");
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
                var element = driverWait.Until(ExpectedConditions.ElementToBeClickable(elementBy));
                // Clear any HMRC session-timeout dialog before the caller clicks the element.
                driver.DismissTimeoutOverlayIfPresent();
                return element;
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
                var element = driverWait.Until(ExpectedConditions.ElementExists(elementBy));
                // Clear any HMRC session-timeout dialog before the caller clicks the element.
                driver.DismissTimeoutOverlayIfPresent();
                return element;
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException("Element is not visible");
            }
        }
    }

}

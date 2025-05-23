using Reqnroll.BoDi;
using Defra.UI.Framework.Driver;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class SignInCPPage : ISignInCPPage
    {
        private readonly IObjectContainer _objectContainer;

        public SignInCPPage(IObjectContainer container)
        {
            _objectContainer = container;
        }


        #region Page objects
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement btnSignIn => _driver.WaitForElement(By.XPath("//a[contains(text(),'Sign in')]"));
        private By signInConfirmBy => By.XPath("//h1[contains(@class,'govuk-heading-xl')]");
        private IWebElement UserId => _driver.FindElement(By.CssSelector("#user_id"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("#password"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//button[contains(@id,'continue')]"));
        private IWebElement txtLoging => _driver.WaitForElement(By.XPath("//input[@id='password']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[normalize-space()='Continue']"));
        private IWebElement signOutBy => _driver.WaitForElement(By.XPath("//a[@href='/signout']//*[name()='svg']"));
        private IWebElement SignOut => _driver.WaitForElement(By.XPath("//a[@href='/signout']"));
        private IWebElement AcceptAdditionalCookies => _driver.WaitForElement(By.XPath("//button[contains(text(),'Accept analytics cookies')]"));
        private IWebElement HideCookieMessage => _driver.WaitForElement(By.XPath("//a[contains(text(),'Hide cookie message')]"));
        #endregion

        #region Methods
        public void ClickSignInButton()
        {
            btnSignIn.Click();
            Thread.Sleep(1000);
            if (_driver.FindElements(By.XPath("//button[contains(text(),'Accept analytics cookies')]")).Count() > 0)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", AcceptAdditionalCookies);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", HideCookieMessage);
            }
        }

        public void IsSignedIn(string userName, string password)
        {
            if (PageHeading.Text == "Sign in using Government Gateway")
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", SignIn);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", UserId);
                UserId.SendKeys(userName);
                Password.SendKeys(password);
                //_driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", SignIn);
                Thread.Sleep(2000);
            }
        }

        public bool IsSignedOut()
        {
            //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", SignOut);
            //signOutBy.Click();
            Thread.Sleep(1000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", SignOut);
            Thread.Sleep(2000);
            return PageHeading.Text.Contains("You have signed out") || PageHeading.Text.Contains("Your Defra account");
        }

        public void EnterPassword()
        {
            Thread.Sleep(1000);
            if(PageHeading.Text == "This is a test environment")
            {
                string envPassword = ConfigSetup.BaseConfiguration.TestConfiguration.EnvPassword;
                IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
                Thread.Sleep(3000);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnContinue);
                jsExecutor.ExecuteScript("arguments[0].click();", btnContinue);
                Thread.Sleep(5000);
                txtLoging.SendKeys(envPassword);
                //jse.ExecuteScript("arguments[0].setAttribute('value','" + envPassword + "')", txtLoging);
                Thread.Sleep(3000);
                jsExecutor.ExecuteScript("arguments[0].click();", btnContinue);
                Thread.Sleep(5000);
            }
        }
        #endregion

    }
}

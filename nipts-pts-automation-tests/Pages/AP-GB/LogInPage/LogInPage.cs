using BoDi;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;


namespace nipts_pts_automation_tests.Pages.AP_GB.LogInPage
{
    public class LogInPage : ILogInPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects
        private IWebElement StartNew => _driver.WaitForElement(By.Id("button-rbIndexSave"));
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl'] | //h1[@class='govuk-heading-l'] | //h1[@class='govuk-fieldset__heading']"), true);
        private IWebElement UserId => _driver.FindElement(By.Id("user_id"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement SignIn => _driver.WaitForElement(By.XPath("//button[contains(text(),'Sign in')]"));
        private IWebElement SignInConfirm => _driver.WaitForElement(By.Id("Link-SignOut"));
        private By SignInConfirmBy => By.XPath("//a[@href='/User/OSignOut']");
        private IWebElement CreateSignInDetails => _driver.WaitForElement(By.XPath("//a[contains(text(),'Create sign in')]"));
        private IWebElement SignOutSUSConfirmMessage => _driver.WaitForElement(By.CssSelector("[href='/management']"));
        private IWebElement SignOutGCConfirmMessage => _driver.WaitForElement(By.CssSelector("h1.govuk-heading-xl"));
        private IWebElement EnvPassword => _driver.WaitForElement(By.Id("password"));
        private IWebElement DynamicsUserId => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Sign in']/following::input[1]"));
        private IWebElement BtnNext => _driver.WaitForElement(By.XPath("//*[@value='Next']"));
        private IWebElement DynamicsPassword => _driver.WaitForElement(By.XPath("//*[normalize-space(text())='Enter password']/following::input[1]"));
        private IWebElement BtnSignin => _driver.WaitForElement(By.XPath("//*[@value='Sign in']"));
        private IWebElement Signin => _driver.WaitForElement(By.XPath("//*[normalize-space(text()) ='Sign In']"));
        private IWebElement SigninError => _driver.WaitForElement(By.XPath("//h1[text() = 'Please sign in again']"));
        #endregion

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public LogInPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        public bool IsPageLoaded()
        {
            return PageHeading.Text.Contains("Sign in using Government Gateway");
        }

        public bool IsSignedIn(string userName, string password)
        {
            UserId.SendKeys(userName);
            Password.SendKeys(password);
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", SignIn);
            //_driver.WaitForElementCondition(ExpectedConditions.ElementToBeClickable(SignIn)).Click();
            return _driver.WaitForElement(SignInConfirmBy).Enabled;
        }

        public void ClickCreateSignInDetailsLink() => CreateSignInDetails.Click();

        public void ClickSignedOut()
        {
            _driver.WaitForElement(SignInConfirmBy).Click();
        }

        public bool IsSignedOut()
        {
            ClickSignedOut();
            return PageHeading.Text.Contains("You have signed out") || PageHeading.Text.Contains("Your Defra account");
        }

        public bool IsSuccessfullySignedOut()
        {
            ClickSignedOut();
            return SignOutGCConfirmMessage.Text.Contains("You need to sign in again");
        }

        public void SignInToDynamics(string username, string password)
        {
            DynamicsUserId.SendKeys(username);
            BtnNext.Click();
            DynamicsPassword.SendKeys(password);
            BtnSignin.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text() = 'Please sign in again']")));
                Signin.Click();
            }
            catch (NoSuchElementException e)
            {

            }

        }

    }
}

using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace nipts_pts_automation_tests.Pages
{
    public class CheckYourAnswersDeclarationPage : ICheckYourAnswersDeclarationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading']"));
        private IWebElement SendApplicationButton => _driver.WaitForElementExists(By.XPath("//button[contains(@class,'govuk-button')] | //button[@type='submit']"));
        private IWebElement chkAgreeToAccuracy => _driver.WaitForElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToAccuracy']"));
        private IWebElement chkAgreeTermsAndPrivacyPolicy => _driver.WaitForElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToPrivacyPolicy']"));
        private IWebElement chkAgreesToDeclaration => _driver.WaitForElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToDeclaration']"));
        private IWebElement lnkApplyForAnother => _driver.WaitForElement(By.XPath("//a[contains(text(),'Apply for another')]"));

        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public CheckYourAnswersDeclarationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods
        public void TickAgreedToAccuracy()
        {
            chkAgreeToAccuracy.Click();
        }

        public void TickAgreedToDeclaration()
        {
            chkAgreesToDeclaration.Click();
        }

        public void TickAgreetToPrivacyPolicy()
        {
            var elementWidth = chkAgreeTermsAndPrivacyPolicy.Size.Width;
            new Actions(_driver).MoveToElement(chkAgreeTermsAndPrivacyPolicy).MoveByOffset(elementWidth / 2 - 2, 0).Click().Build().Perform();
        }

        public void ClickSendApplicationButton()
        {
            SendApplicationButton.Click();
        }

        public void ClickApplyForAnotherPetTravelDocument()
        {
            lnkApplyForAnother.Click();
        }
        #endregion Page Methods

    }
}


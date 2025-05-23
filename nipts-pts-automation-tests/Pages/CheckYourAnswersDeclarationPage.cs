using Reqnroll.BoDi;
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
        private IWebElement SendApplicationButton => _driver.WaitForElementExists(By.XPath("//button[@id='submitButton']"));
        private IWebElement chkAgreeToAccuracy => _driver.WaitForElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToAccuracy']"));
        private IWebElement chkAgreeTermsAndPrivacyPolicy => _driver.WaitForElement(By.XPath("//div[@class='govuk-checkboxes__item']/input[@id='AgreedToDeclaration']"));
        private IWebElement chkAgreesToDeclaration => _driver.WaitForElementExists(By.XPath("//input[@id='AgreedToDeclaration']"));
        private IWebElement chkTextAgreesToDeclaration => _driver.WaitForElementExists(By.XPath("//input[@id='AgreedToDeclaration']/following-sibling::div"));

        private IWebElement lnkApplyForAnother => _driver.WaitForElement(By.XPath("//a[contains(text(),'Gwneud cais am ddogfen deithio gydol oes arall i anifeiliaid anwes')]"));
        private IWebElement lnkViewAllPetTravelDocuments => _driver.WaitForElement(By.XPath("//a[contains(text(),'Gweld eich holl ddogfennau teithio gydol oes i anifeiliaid anwes')]"));

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
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", chkAgreesToDeclaration);
            if (chkTextAgreesToDeclaration.Text.Contains("n cytuno"))
            { 
                chkAgreesToDeclaration.Click(); 
            }
        }

        public void TickAgreetToPrivacyPolicy()
        {
            var elementWidth = chkAgreeTermsAndPrivacyPolicy.Size.Width;
            new Actions(_driver).MoveToElement(chkAgreeTermsAndPrivacyPolicy).MoveByOffset(elementWidth / 2 - 2, 0).Click().Build().Perform();
        }

        public void ClickSendApplicationButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,1000)", "");
            if (SendApplicationButton.Text.Contains("Anfon cais"))
            {
                SendApplicationButton.Click();
            }
        }

        public void ClickApplyForAnotherPetTravelDocument()
        {
            lnkApplyForAnother.Click();
        }

        public void ClickViewAllPetTravelDocument()
        {
            lnkViewAllPetTravelDocuments.Click();
        }

        public bool VerifyWELSHSummaryOnAppSummary(string fieldName, string fieldValue)
        {
            string FieldName = "//dt[contains(text(),'" + fieldName + "')]";
            string FieldValue = "(//dt[contains(text(),'" + fieldName + "')]/..//dd)[1]";
            Console.WriteLine(_driver.WaitForElement(By.XPath(FieldName)).Text);
            Console.WriteLine(_driver.WaitForElement(By.XPath(FieldValue)).Text);
            return (_driver.WaitForElement(By.XPath(FieldName)).Text.Contains(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue));
        }

        public bool VerifyPetOwnerDetailsOnAppSummaryInWELSH(string fieldName, string fieldValue)
        {
            string FieldName = "//dt[contains(text(),'" + fieldName + "')]";
            string FieldValue = "(//dt[contains(text(),'" + fieldName + "')]/..//dd)[2]";
            return (_driver.WaitForElement(By.XPath(FieldName)).Text.Equals(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue));
        }


        public bool VerifyGenderOnWELSHAppSummary(string fieldName, string fieldValue)
        {
            string FieldName = "(//dt[contains(text(),'" + fieldName + "')])[2]";
            string FieldValue = "((//dt[contains(text(),'" + fieldName + "')])[2])/following-sibling::dd[1]";
            Console.WriteLine(_driver.WaitForElement(By.XPath(FieldName)).Text);
            Console.WriteLine(_driver.WaitForElement(By.XPath(FieldValue)).Text);
            return (_driver.WaitForElement(By.XPath(FieldName)).Text.Contains(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue));
        }


        public bool VerifyMichrochipDateOnAppSummaryInWelsh(string michrochipDate, string michrochipDateValue)
        {
            string MichrochipDate = "//dt[contains(text(),'" + michrochipDate + "')]";
            string MichochipDateValue = "(//dt[contains(text(),'" + michrochipDate + "')]/..//dd)[1]";
            return (_driver.FindElement(By.XPath(MichrochipDate)).Text.Contains(michrochipDate) && _driver.FindElement(By.XPath(MichochipDateValue)).Text.Contains(michrochipDateValue));
        }

        public bool VerifyPetDOBOnAppSummaryInWelsh(string petDOB, string petDOBValue)
        {
            string PetDOB = "//dt[contains(text(),'" + petDOB + "')]";
            string PetDOBValue = "(//dt[contains(text(),'" + petDOB + "')]/..//dd)[1]";
            return (_driver.FindElement(By.XPath(PetDOB)).Text.Contains(petDOB) && _driver.FindElement(By.XPath(PetDOBValue)).Text.Contains(petDOBValue));
        }


        #endregion Page Methods

    }
}


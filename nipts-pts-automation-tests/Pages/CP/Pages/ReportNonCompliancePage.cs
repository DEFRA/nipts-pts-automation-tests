using BoDi;
using Microsoft.Azure.Amqp.Framing;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class ReportNonCompliancePage : IReportNonCompliancePage
    {
        private readonly IObjectContainer _objectContainer;

        public ReportNonCompliancePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[normalize-space()='Report non-compliance']"));
        private IWebElement btnReportNonCompliance => _driver.WaitForElement(By.XPath("//button[normalize-space()='Save outcome']"));
        private IWebElement lnkPetTravelDocumentDetails => _driver.WaitForElement(By.XPath("//span[normalize-space()='Pet Travel Document details']"));
        private IWebElement btnFootPassengerRadio => _driver.WaitForElementExists(By.CssSelector("#passengerType"));
        private IWebElement bntVehicleRadio => _driver.WaitForElementExists(By.CssSelector("#vehiclePassenger"));
        private IWebElement bntAirlineRadio => _driver.WaitForElementExists(By.CssSelector("#airlinePassenger"));
        private IWebElement microchipNotFound => _driver.WaitForElementExists(By.XPath("//input[@id ='mcNotFound']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement passangerReferred => _driver.WaitForElementExists(By.XPath("//input[@id ='isGBCheck']"));
        private IWebElement passangerAdvised => _driver.WaitForElementExists(By.XPath("//input[@id ='gbAdviseNoTravel']"));
        private IWebElement passangerNotTravel => _driver.WaitForElementExists(By.XPath("//input[@id ='gbPassengerSaysNoTravel']"));
        private IWebElement chkMicrochipNoDoesNotMatchPTD => _driver.WaitForElementExists(By.XPath("(//div[@class='govuk-checkboxes__item']/input[@class='govuk-checkboxes__input'])[1]"));
        private IWebElement txtMichrochipNo => _driver.WaitForElement(By.Id("mcNotMatchActual"));
        private IWebElement btnSaveOutcome => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save outcome')]"));
        private IWebElement txtOtherReasonHintTxt => _driver.WaitForElement(By.Id("somethingRadio-item-hint"));
        private IWebElement txtGBOutcomeHintTxt => _driver.WaitForElement(By.Id("gb-item-hint"));
        private IWebElement txtNIOutcomeHintTxt => _driver.WaitForElement(By.Id("sps-item-hint"));
        private IWebElement PTDNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'PTD number')]/./following-sibling::dd"));
        private IWebElement ApplicationRefNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Application reference number')]/./following-sibling::dd"));
        private IWebElement RelevantComment => _driver.WaitForElementExists(By.Id("relevantComments"));
        private IWebElement PetNotMatchPTD => _driver.WaitForElementExists(By.XPath("//input[@id ='vcNotMatchPTD']"));
        private IWebElement PotentialCommetcialMov => _driver.WaitForElementExists(By.XPath("//label[contains(text(),'Potential commercial movement')]/..//input"));
        private IWebElement AuthTravNoConfirmation => _driver.WaitForElementExists(By.XPath("//input[contains(@id,'oiFailAuthTravellerNoConfirmation')]"));
        private IWebElement OtherReason => _driver.WaitForElementExists(By.XPath("//input[contains(@id,'oiFailOther')]"));
        private IWebElement DetailsOfOutCome => _driver.WaitForElementExists(By.Id("spsOutcomeDetails"));

        #endregion

        #region Methods
        public bool IsPageLoaded()
        {
            return pageHeading.Text.Contains("Report non-compliance");
        }

        public void SelectReportNonComplianceButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnReportNonCompliance);
            btnReportNonCompliance.Click();
        }

        public void ClickPetTravelDocumentDetailsLnk()
        {
            lnkPetTravelDocumentDetails.Click();
        }

        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"//dd[@class='govuk-summary-list__value']//strong[contains(text(), '{status}')]")).Text.Trim().Equals(status);
        }

        public void SelectTypeOfPassenger(string radioButtonValue)
        {

            if (radioButtonValue.Equals("Ferry foot passenger"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnFootPassengerRadio);
                btnFootPassengerRadio.Click();
            }
            else if (radioButtonValue.Equals("Airline"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", bntAirlineRadio);
                bntAirlineRadio.Click();
            }
            else
            {
                try
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", bntVehicleRadio);
                    bntVehicleRadio.Click();
                }
                catch
                {
                    bntVehicleRadio.FindElement(By.CssSelector("#vehiclePassenger")).Click();
                }
            }
        }

        public void SelectNonComplianceReason(string nonComplianceReason)
        {
            if (nonComplianceReason.Equals("Cannot find microchip"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", microchipNotFound);
                microchipNotFound.Click();
            }
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

        public void ClickOnSPSOutcome(string SPSStatus)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(100,4000)", "");
            _driver.ClickRadioButton(SPSStatus);
        }

        public void ClickOnGBOutcome()
        {
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", passangerReferred);
            passangerReferred.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", passangerAdvised);
            passangerAdvised.Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", passangerNotTravel);
            passangerNotTravel.Click();
        }
        public void TickMicrochipNoDoesNotMatchPTD()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", chkMicrochipNoDoesNotMatchPTD);
            chkMicrochipNoDoesNotMatchPTD.Click();
        }
        public void EnterMichrochipNoDoesNotMatchPTD(string michrochipNo)
        {
            txtMichrochipNo.Clear();
            txtMichrochipNo.SendKeys(michrochipNo);
        }
        public void ClickOnSaveOutcome()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnSaveOutcome);
            btnSaveOutcome.Click();
        }
        public bool VerifyOtherReasonHintTxt(string otherReasonHintTxt)
        {
            return txtOtherReasonHintTxt.Text.Contains(otherReasonHintTxt);
        }
        public bool VerifyGBOutcomeHintTxt(string GBOutcomeMsg)
        {
            return txtGBOutcomeHintTxt.Text.Contains(GBOutcomeMsg);
        }
        public bool VerifyNIOutcomeHintTxt(string NIOutcomeMsg)
        {
            return txtNIOutcomeHintTxt.Text.Contains(NIOutcomeMsg);
        }

        public bool VerifyPTDNumber(string ptdNumberNew)
        {
            return PTDNumber.Text.Contains(ptdNumberNew);
        }

        public bool VerifyApplicationReferenceNumber(string AppRefNumber)
        {
            return ApplicationRefNumber.Text.Contains(AppRefNumber);
        }

        public void SelectMicrochipReason(string microchipReason)
        { 
            if (microchipReason.Contains("MicrochipNumberNoMatch"))
            {
                TickMicrochipNoDoesNotMatchPTD();
                EnterMichrochipNoDoesNotMatchPTD("123456789123456");
            }
            else if (microchipReason.Contains("CannotFindMicrochip"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", microchipNotFound);
                microchipNotFound.Click();
            }
        }

        public void EnterAdditionalComment(string additionalComment)
        {
            if (!additionalComment.Contains("None"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", RelevantComment);
                RelevantComment.SendKeys(additionalComment);
            }
        }

        public void SelectGBOutcome(string gBOutcome)
        {
            if (gBOutcome.Contains("PassengerReferredDAERA"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", passangerReferred);
                passangerReferred.Click();
            }
            else if (gBOutcome.Contains("PassengerAdvisedNoTravel"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", passangerAdvised);
                passangerAdvised.Click();
            }
            else if (gBOutcome.Contains("PassengerWillNotTravel"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", passangerNotTravel);
                passangerNotTravel.Click();
            }
        }

        public void SelectVisualCheck(string visualCheck)
        {
            if (visualCheck.Contains("PetDoesNotMatchThePTD"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", PetNotMatchPTD);
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", PetNotMatchPTD);
            }
        }
        public void SelectOtherIssues(string otherIssues)
        {
            if (otherIssues.Contains("PotentialCommercialMovement"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", PotentialCommetcialMov);
                PotentialCommetcialMov.Click();
            }
            else if (otherIssues.Contains("AuthorisedTravellerButNoConfirmation"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", AuthTravNoConfirmation);
                AuthTravNoConfirmation.Click();
            }
            else if (otherIssues.Contains("OtherReason"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", OtherReason);
                OtherReason.Click();
            }

        }

        public void EnterDetailsOfOutCome(string detailsOfOutCome)
        {
            if (!detailsOfOutCome.Contains("None"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", DetailsOfOutCome);
                DetailsOfOutCome.SendKeys(detailsOfOutCome);
            }
        }



        #endregion

    }
}

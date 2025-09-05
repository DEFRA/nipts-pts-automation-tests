using Reqnroll.BoDi;
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
        private IWebElement microchipNotFound => _driver.WaitForElementExists(By.XPath("//input[@id ='missingReason']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement passangerReferred => _driver.WaitForElementExists(By.XPath("//input[@id ='isGBCheck']"));
        private IWebElement passangerAdvised => _driver.WaitForElementExists(By.XPath("//input[@id ='gbAdviseNoTravel']"));
        private IWebElement passangerNotTravel => _driver.WaitForElementExists(By.XPath("//input[@id ='gbPassengerSaysNoTravel']"));
        //private IWebElement chkMicrochipNoDoesNotMatchPTD => _driver.WaitForElementExists(By.XPath("(//div[@class='govuk-checkboxes__item']/input[@class='govuk-checkboxes__input'])[1]"));
        private IWebElement txtMichrochipNo => _driver.WaitForElement(By.Id("mcNotMatchActual"));
        private IWebElement btnSaveOutcome => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save outcome')]"));
        private IWebElement txtOtherReasonHintTxt => _driver.WaitForElement(By.Id("somethingRadio-item-hint"));
        private IWebElement txtGBOutcomeHintTxt => _driver.WaitForElement(By.Id("gb-item-hint"));
        private IWebElement txtNIOutcomeHintTxt => _driver.WaitForElement(By.Id("sps-item-hint"));
        private IWebElement PTDNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'PTD number')]/./following-sibling::dd"));
        private IWebElement ApplicationRefNumber => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Application reference number')]/./following-sibling::dd"));
        //private IWebElement RelevantComment => _driver.WaitForElementExists(By.Id("relevantComments"));
        //private IWebElement PetNotMatchPTD => _driver.WaitForElementExists(By.XPath("//input[@id ='vcNotMatchPTD']"));
        private IWebElement AuthPersonNoConfirmation => _driver.WaitForElementExists(By.XPath("//input[contains(@id,'oiFailAuthTravellerNoConfirmation')]"));
        private IWebElement RefusedToSignDeclarationEle => _driver.WaitForElementExists(By.XPath("//input[contains(@id,'oiRefusedToSignDeclaration')]"));
        private IWebElement DetailsOfOutCome => _driver.WaitForElementExists(By.XPath("//textarea[contains(@id,'detailsOfOutcome')] | //textarea[contains(@id,'spsOutcomeDetails')]"));
        By ReasonsHeadingEle => By.XPath("//div[contains(@class,'govuk-section-break')]//h2[@class='govuk-heading-l']");
        By MicrochipHeadingEle => By.XPath("//h3[@class='govuk-heading-m'][contains(text(),'Microchip')]");
        By MicrochipDetailsHeadingEle => By.XPath("//span[@class='govuk-details__summary-text'][contains(text(),'Microchip details')]");
        By VisualCheckHeadingEle => By.XPath("//h3[@class='govuk-heading-m'][contains(text(),'Visual check')]");
        By PetDetailsHeadingEle => By.XPath("//span[@class='govuk-details__summary-text'][contains(text(),'Pet details')]");
        By OtherIssuesHeadingEle => By.XPath("//h3[@class='govuk-heading-m'][contains(text(),'Other issues')]");
        By PassengerDetailsHeadingEle => By.XPath("//h2[contains(@class,'govuk-heading-l')][contains(text(),'Passenger details')]");
        By PetOwnerDetailsHeadingEle => By.XPath("//span[@class='govuk-details__summary-text'][contains(text(),'Pet owner details')]");
        By RecordOutcomeHeadingEle => By.XPath("//h2[@class='govuk-heading-l'][contains(text(),'Record outcome')]");
        //By AnyRelevantCommentsHeadingEle => By.XPath("//h2[@class='govuk-heading-l']//label[contains(text(),'Any relevant comments')]");
        By PetTravelDocumentHeadingEle => By.XPath("//h3[@class='govuk-heading-m'][contains(text(),'Pet Travel Document')]");
        private IWebElement SaveOnUpdateReferral => _driver.WaitForElement(By.XPath("//button[contains(text(),'Save')]"));
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
        //public void TickMicrochipNoDoesNotMatchPTD()
        //{
        //    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", chkMicrochipNoDoesNotMatchPTD);
        //    chkMicrochipNoDoesNotMatchPTD.Click();
        //}
        //public void EnterMichrochipNoDoesNotMatchPTD(string michrochipNo)
        //{
        //    txtMichrochipNo.Clear();
        //    txtMichrochipNo.SendKeys(michrochipNo);
        //}
        public void ClickOnSaveOutcome()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnSaveOutcome);
            btnSaveOutcome.Click();
        }

        public void ClickOnSaveOnUpdateReferral()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", SaveOnUpdateReferral);
            SaveOnUpdateReferral.Click();
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
            //if (microchipReason.Contains("MicrochipNumberNoMatch"))
            //{
            //    TickMicrochipNoDoesNotMatchPTD();
            //    EnterMichrochipNoDoesNotMatchPTD("123456789123456");
            //}
            //else
            if (microchipReason.Contains("CannotFindMicrochip"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", microchipNotFound);
                microchipNotFound.Click();
            }
        }

        //public void EnterAdditionalComment(string additionalComment)
        //{
        //    if (!additionalComment.Contains("None"))
        //    {
        //        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", RelevantComment);
        //        RelevantComment.SendKeys(additionalComment);
        //    }
        //}

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

        //public void SelectVisualCheck(string visualCheck)
        //{
        //    if (visualCheck.Contains("PetDoesNotMatchThePTD"))
        //    {
        //        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", PetNotMatchPTD);
        //        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", PetNotMatchPTD);
        //    }
        //}

        public void SelectOtherIssues(string otherIssues)
        {
            if (otherIssues.Contains("AuthPersonButNoConfirmation"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", AuthPersonNoConfirmation);
                AuthPersonNoConfirmation.Click();
            }
            else if (otherIssues.Contains("RefusedToSignDeclaration"))
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", RefusedToSignDeclarationEle);
                RefusedToSignDeclarationEle.Click();
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

        public bool VerifyTheReasonsHeadingStructure()
        {
            if (_driver.FindElements(ReasonsHeadingEle).Count > 0)
                return true;
            else
                return false;
        }

        public bool VerifyTheMicrochipHeadingStructure()
        {
            if (_driver.FindElements(MicrochipHeadingEle).Count > 0)
                return true;
            else
                return false;
        }

        public void ClickOnTheMicrochipDetailsHeadingStructure()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", microchipNotFound);
            _driver.FindElement(MicrochipDetailsHeadingEle).Click();
        }

        //public bool VerifyTheVisualCheckHeadingStructure()
        //{
        //    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", PetNotMatchPTD);
        //    if (_driver.FindElements(VisualCheckHeadingEle).Count > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public void ClickOnPetDetailsHeadingStructure()
        //{
        //    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", PetNotMatchPTD);
        //    _driver.FindElement(PetDetailsHeadingEle).Click();
        //}

        public bool VerifyTheOtherIssuesHeadingStructure()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", AuthPersonNoConfirmation);
            if (_driver.FindElements(OtherIssuesHeadingEle).Count > 0)
                return true;
            else
                return false;
        }

        public bool VerifyThePassengerDetailsHeadingStructure()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", AuthPersonNoConfirmation);
            if (_driver.FindElements(PassengerDetailsHeadingEle).Count > 0)
                return true;
            else
                return false;
        }

        public void ClickOnPetOwnerDetailsHeadingStructure()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnFootPassengerRadio);
            _driver.FindElement(PetOwnerDetailsHeadingEle).Click();
        }

        //public bool VerifyTheAnyRelevantCommentsHeadingStructure()
        //{
        //    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", RelevantComment);
        //    if (_driver.FindElements(AnyRelevantCommentsHeadingEle).Count > 0)
        //        return true;
        //    else
        //        return false;
        //}

        public bool VerifyTheRecordOutcomeHeadingStructure()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", DetailsOfOutCome);
            if (_driver.FindElements(RecordOutcomeHeadingEle).Count > 0)
                return true;
            else
                return false;
        }

        public bool VerifyThePetTravelDocumentHeadingStructure()
        {
            if (_driver.FindElements(PetTravelDocumentHeadingEle).Count > 0)
                return true;
            else
                return false;
        }
        #endregion

    }
}

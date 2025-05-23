﻿using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class GBCheckReportPage : IGBCheckReportPage
    {
        private readonly IObjectContainer _objectContainer;

        public GBCheckReportPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement pageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')]"));
        private IWebElement clickSPSConduct => _driver.WaitForElement(By.XPath("//button[contains(text(),'Conduct an SPS check')]"));
        private IWebElement BulletPassangerRefToDAERA => _driver.WaitForElement(By.XPath("//li[contains(text(),'Passenger referred to DAERA/SPS at NI port')]"));
        private IWebElement BulletPassengerAdvised => _driver.WaitForElement(By.XPath("//li[contains(text(),'Passenger advised not to travel')]"));
        private IWebElement BulletPassengerNoTravel => _driver.WaitForElement(By.XPath("//li[contains(text(),'Passenger says they will not travel')]"));
        private IWebElement BulletMicrochipDoesNotMatch => _driver.WaitForElement(By.XPath("//li[contains(text(),'Microchip number does not match the PTD')]"));
        private IWebElement BulletMicrochipNotFound => _driver.WaitForElement(By.XPath("//li[contains(text(),'Cannot find microchip')]"));
        private IWebElement PassangerRefToDAERA => _driver.WaitForElement(By.XPath("//p[contains(text(),'Passenger referred to DAERA/SPS at NI port')]"));
        private IWebElement PassengerAdvised => _driver.WaitForElement(By.XPath("//p[contains(text(),'Passenger advised not to travel')]"));
        private IWebElement PassengerNoTravel => _driver.WaitForElement(By.XPath("//p[contains(text(),'Passenger says they will not travel')]"));
        private IWebElement MicrochipDoesNotMatch => _driver.WaitForElement(By.XPath("//p[contains(text(),'Microchip number does not match the PTD')]"));
        private IWebElement MicrochipNotFound => _driver.WaitForElement(By.XPath("//p[contains(text(),'Cannot find microchip')]"));
        private IWebElement AdditionalComment => _driver.WaitForElement(By.XPath("//dt[text()='Additional comments']/..//p"));
        private IWebElement PetNotMatchPTD => _driver.WaitForElement(By.XPath("//li[contains(text(),'Pet does not match the PTD')]"));
        private IWebElement PotentialCommetcialMov => _driver.WaitForElement(By.XPath("//li[contains(text(),'Potential commercial movement')]"));
        private IWebElement AuthTravNoConfirmation => _driver.WaitForElement(By.XPath("//li[contains(text(),'Authorised person but no confirmation')]"));
        private IWebElement OtherReason => _driver.WaitForElement(By.XPath("//li[contains(text(),'Other reason')]"));
        private IWebElement DetailsOfOutcome => _driver.WaitForElement(By.XPath("//dt[text()='Details of outcome']/..//p"));
        private IWebElement MicroNoMismatch => _driver.WaitForElement(By.XPath("//dt[text()='Microchip number found in scan']/..//p"));
        #endregion

        #region Methods

        public void VerifyGBCheckReport()
        { 
        
        }

        public void ClickOnConductAnSPSCheck()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,3000)", "");
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", clickSPSConduct);
        }

        public bool VerifyMicrochipReason(string NumberMicrochipReason, string microchipReason,string NumberOtherIssues)
        {
            bool status = true;
            if (Int32.Parse(NumberMicrochipReason) > 1 || Int32.Parse(NumberOtherIssues) > 0)
            {
                if (microchipReason.Contains("MicrochipNumberNoMatch"))
                {
                    if (!BulletMicrochipDoesNotMatch.Text.Contains("Microchip number does not match the PTD"))
                        status = false;
                }
                else if (microchipReason.Contains("CannotFindMicrochip"))
                {
                    if (!BulletMicrochipNotFound.Text.Contains("Cannot find microchip"))
                        status = false;
                }
            }
            else
            {
                if (microchipReason.Contains("MicrochipNumberNoMatch"))
                {
                    if (!MicrochipDoesNotMatch.Text.Contains("Microchip number does not match the PTD") && !MicroNoMismatch.Text.Contains("123456789123456"))
                        status = false;
                }
                else if (microchipReason.Contains("CannotFindMicrochip"))
                {
                    if (!MicrochipNotFound.Text.Contains("Cannot find microchip"))
                        status = false;
                }
            }
            return status;               
        }

        public bool VerifyAdditionalComment(string additionalComment)
        {
            if (AdditionalComment.Text.Contains(additionalComment))
                return true;
            else 
                return false;
        }

        public bool VerifyGBOutcome(string NumberGBOutcome, string gBOutcome)
        {
            bool status = true;

            if (Int32.Parse(NumberGBOutcome) > 1)
            {
                if (gBOutcome.Contains("PassengerReferredDAERA"))
                {
                    if (!BulletPassangerRefToDAERA.Text.Contains("Passenger referred to DAERA/SPS at NI port"))
                        status = false;
                }
                else if (gBOutcome.Contains("PassengerAdvisedNoTravel"))
                {
                    if (!BulletPassengerAdvised.Text.Contains("Passenger advised not to travel"))
                        status = false;
                }
                else if (gBOutcome.Contains("PassengerWillNotTravel"))
                {
                    if (!BulletPassengerNoTravel.Text.Contains("Passenger says they will not travel"))
                        status = false;
                }
            }
            else
            {
                if (gBOutcome.Contains("PassengerReferredDAERA"))
                {
                    if (!PassangerRefToDAERA.Text.Contains("Passenger referred to DAERA/SPS at NI port"))
                        status = false;
                }
                else if (gBOutcome.Contains("PassengerAdvisedNoTravel"))
                {
                    if (!PassengerAdvised.Text.Contains("Passenger advised not to travel"))
                        status = false;
                }
                else if (gBOutcome.Contains("PassengerWillNotTravel"))
                {
                    if (!PassengerNoTravel.Text.Contains("Passenger says they will not travel"))
                        status = false;
                }
            }
            return status;
        }

        public bool? VerifyVisualCheck(string petDoesNotMatchThePTD)
        {
            bool status = true;

            if (petDoesNotMatchThePTD.Contains("PetDoesNotMatchThePTD"))
            {
                if (!PetNotMatchPTD.Text.Contains("Pet does not match the PTD"))
                    status = false;
            }

            return status;
        }

        public bool? VerifyOtherIssues(string numberOtherIssues, string otherIssues)
        {
            bool status = true;

            if (otherIssues.Contains("PotentialCommercialMovement"))
            {
                if (!PotentialCommetcialMov.Text.Contains("Potential commercial movement"))
                    status = false;
            }
            else if (otherIssues.Contains("AuthorisedTravellerButNoConfirmation"))
            {
                if (!AuthTravNoConfirmation.Text.Contains("Authorised person but no confirmation"))
                    status = false;
            }
            else if (otherIssues.Contains("OtherReason"))
            {
                if (!OtherReason.Text.Contains("Other reason"))
                    status = false;
            }

            return status;
        }

        public bool? VerifyDetailsOfOutcome(string detailsOfOutcome)
        {
            if (DetailsOfOutcome.Text.Contains(detailsOfOutcome))
                return true;
            else
                return false;
        }

        #endregion

    }
}

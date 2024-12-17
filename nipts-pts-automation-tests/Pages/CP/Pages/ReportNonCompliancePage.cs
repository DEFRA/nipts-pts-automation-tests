using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using System.Net.NetworkInformation;

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
        #endregion

    }
}

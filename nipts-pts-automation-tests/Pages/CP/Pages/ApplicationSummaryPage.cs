using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using System.Data;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class ApplicationSummaryPage : IApplicationSummaryPage
    {
        private readonly IObjectContainer _objectContainer;

        public ApplicationSummaryPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement rdoPass => _driver.WaitForElement(By.XPath("//label[normalize-space()='Pass']"));
        private IWebElement rdoFail => _driver.WaitForElement(By.XPath("//label[normalize-space()='Fail or referred to SPS']"));
        private IWebElement btnSaveAndContinue => _driver.WaitForElement(By.XPath("//*[@id='saveAndContinue']"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;
        private IWebElement PassangerRefToDAERA => _driver.WaitForElement(By.XPath("//li[contains(text(),'Passenger referred to DAERA/SPS at NI port')] | //p[contains(text(),'Passenger referred to DAERA/SPS at NI port')]"));
        private IWebElement PassengerAdvised => _driver.WaitForElement(By.XPath("//li[contains(text(),'Passenger advised not to travel')] | //p[contains(text(),'Passenger advised not to travel')]"));
        private IWebElement PassengerNoTravel => _driver.WaitForElement(By.XPath("//li[contains(text(),'Passenger says they will not travel')] | //p[contains(text(),'Passenger says they will not travel')]"));
        private IWebElement MicrochipDoesNotMatch => _driver.WaitForElement(By.XPath("//li[contains(text(),'Microchip number does not match the PTD')] | //p[contains(text(),'Microchip number does not match the PTD')]"));
        private IWebElement MicrochipNotFound => _driver.WaitForElement(By.XPath("//li[contains(text(),'Cannot find microchip')] | //p[contains(text(),'Cannot find microchip')]"));
        private IWebElement AdditionalComment => _driver.WaitForElement(By.XPath("//dt[text()='Additional comments']/..//p"));
        private IWebElement Route => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Route')]/following-sibling::dd"));
        private IWebElement ScheduledDepartureDate => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Scheduled departure date')]/..//dd//p"));
        private IWebElement ScheduledDepartureTime => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Scheduled departure time')]/..//dd//p"));

        #endregion

        #region Methods
        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"(//h1[normalize-space()='{status}'])[1]")).Text.Trim().Equals(status);
        }

        public bool VerifyTheExpectedSubtitle(string applicationSubtitle)
        {
            return _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-panel__title')]/../following-sibling::h1")).Text.Trim().Equals(applicationSubtitle);
        }

        public void SelectPassRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoPass);
            rdoPass.Click();
        }
        public void SelectFailRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoFail);
            rdoFail.Click();
        }

        public void SelectSaveAndContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnSaveAndContinue);
            btnSaveAndContinue.Click();
        }

        public void SelectContinue()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", btnContinue);
            btnContinue.Click();
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

        public string getNewID()
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string getNewId = "SELECT NEWID()";
            string NewIdString = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                NewIdString = dataHelperConnections.ExecuteQuery(connectionString, getNewId);
            }
            return NewIdString;
        }

        private string GetApplId(string appReference)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT Id  FROM [dbo].[Application] Where [ReferenceNumber] = '{appReference}'";
            string ApplicationId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                ApplicationId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery);
            }
            return ApplicationId;
        }

        private string GetTravelDocumentId(string applicationId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"select Id from [dbo].[TravelDocument] where ApplicationId = '{applicationId}'";
            string TravelDocumentId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                TravelDocumentId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery);
            }
            return TravelDocumentId;
        }

        private string GetGBCheckerId()
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"select Id from [dbo].[Checker] where FullName = 'pallavi GB Yewale'";
            string CheckerId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                CheckerId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery);
            }
            return CheckerId;
        }

        private string GetSPSCheckerId()
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"select Id from [dbo].[Checker] where FullName = 'pallavi SPS Yewale'";
            string CheckerId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                CheckerId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery);
            }
            return CheckerId;
        }
        private string GetCheckOutcomeId(string applicationId, string travelDocumentId, string gBCheckerId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT CheckOutcomeId FROM [dbo].[CheckSummary]  Where ApplicationId = '{applicationId}' and TravelDocumentId = '{travelDocumentId}' and [CheckerId]  = '{gBCheckerId}'";
            string CheckOutcomeId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                CheckOutcomeId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery);
            }
            return CheckOutcomeId;
        }

        private bool ValidateGBOutcomeWithSQLBackend(string checkOutcomeId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT MCNotFound,MCNotMatch,MCNotMatchActual,RelevantComments,GBRefersToDAERAOrSPS,GBAdviseNoTravel,GBPassengerSaysNoTravel FROM [dbo].[CheckOutcome]  Where Id = '{checkOutcomeId}'";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;
            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0 && row[0].Equals(true))
                    {
                        if (!MicrochipNotFound.Text.Contains("Cannot find microchip"))
                            status = false;
                    }
                    if (i == 1 && row[1].Equals(true))
                    {
                        if (!MicrochipDoesNotMatch.Text.Contains("Microchip number does not match the PTD"))
                            status = false;
                    }
                    if (i == 3)
                    {
                        if (!AdditionalComment.Text.Contains("None"))
                        {
                            if (!AdditionalComment.Text.Equals(row[3]))
                                status = false;
                        }
                    }
                    if (i == 4 && row[4].Equals(true))
                    {
                        if (!PassangerRefToDAERA.Text.Contains("Passenger referred to DAERA/SPS at NI port"))
                            status = false;
                    }
                    if (i == 5 && row[5].Equals(true))
                    {
                        if (!PassengerAdvised.Text.Contains("Passenger advised not to travel"))
                            status = false;
                    }
                    if (i == 6 && row[6].Equals(true))
                    {
                        if (!PassengerNoTravel.Text.Contains("Passenger says they will not travel"))
                            status = false;
                    }
                }
            }
            return status;
        }

        private bool ValidateSPSOutcomeWithSQLBackend(string checkOutcomeId,string TypeOfPassenger, string SPSOutcome)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT MCNotFound,MCNotMatch,MCNotMatchActual,PassengerTypeId,SPSOutcome FROM [dbo].[CheckOutcome]  Where Id = '{checkOutcomeId}'";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;
            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0 && row[0].Equals(true))
                    {
                        if (!MicrochipNotFound.Text.Contains("Cannot find microchip"))
                            status = false;
                    }
                    else if (i == 1 && row[1].Equals(true))
                    {
                        if (!MicrochipDoesNotMatch.Text.Contains("Microchip number does not match the PTD"))
                            status = false;
                    }
                    else if (i == 3)
                    {
                        if (TypeOfPassenger.Contains("Ferry foot passenger"))
                        { 
                            if (row[3].Equals(1))
                                status = true;
                            else
                                status = false;
                        }
                        else if (TypeOfPassenger.Contains("Vehicle on ferry"))
                        {
                            if (row[3].Equals(2))
                                status = true;
                            else
                                status = false;
                        }

                        else if (TypeOfPassenger.Contains("Airline"))
                        {
                            if (row[3].Equals(3))
                                status = true;
                            else
                                status = false;
                        }
                    }
                    else if (i == 4 && row[4].Equals(true))
                    {
                        if (SPSOutcome.Contains("Allowed"))
                            status = true;
                        else
                            status = false;
                    }
                    else if (i == 4 && row[4].Equals(true))
                    {
                        if (SPSOutcome.Contains("Not allowed"))
                            status = true;
                        else
                            status = false;
                    }
                }
            }

            return status;
        }

        private bool ValidateGBSummaryWithSQLBackend(string applicationId, string travelDocumentId, string gBCheckerId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT GBCheck,LinkedCheckId,RouteId,Date,ScheduledSailingTime,CheckOutcome FROM [dbo].[CheckSummary]  Where ApplicationId = '{applicationId}' and TravelDocumentId = '{travelDocumentId}' and [CheckerId]  = '{gBCheckerId}'";
            DataTable sqlData = null;
            bool status = false;
            int i = 0;
            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0 && row[0].Equals(true))
                    {
                        status = true;
                    }
                    else if (i == 1 && !row[1].Equals(null))
                    {
                        status = true;
                    }
                    else if (i == 2)
                    {
                        if(row[1].Equals(1) && Route.Text.Contains("Birkenhead to Belfast (Stena)"))
                            status = true;
                        else if (row[1].Equals(2) && Route.Text.Contains("Cairnryan to Larne (P&O)"))
                            status = true;
                        else if (row[1].Equals(3) && Route.Text.Contains("Loch Ryan to Belfast (Stena)"))
                            status = true;
                    }
                    else if (i == 3)
                    {
                        status = true;
                    }
                    else if (i == 4)
                    {
                        status = true;
                    }
                }
            }

            return status;
        }

        private bool ValidateSPSSummaryWithSQLBackend(string applicationId, string travelDocumentId, string SPSCheckerId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT GBCheck,LinkedCheckId,RouteId,Date,ScheduledSailingTime,CheckOutcome FROM [dbo].[CheckSummary]  Where ApplicationId = '{applicationId}' and TravelDocumentId = '{travelDocumentId}' and [CheckerId]  = '{SPSCheckerId}'";
            DataTable sqlData = null;
            bool status = false;
            int i = 0;
            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0 && row[0].Equals(false))
                    {
                        status = true;
                    }
                }
            }

            return status;
        }

        public bool VerifyGBSummaryOutputWithSQLBackend(string AppReference)
        {
            string ApplicationId = GetApplId(AppReference);
            string TravelDocumentId = GetTravelDocumentId(ApplicationId);
            string GBCheckerId = GetGBCheckerId();
            return ValidateGBSummaryWithSQLBackend(ApplicationId, TravelDocumentId, GBCheckerId);
        }

        public bool VerifySPSSummaryOutputWithSQLBackend(string AppReference)
        {
            string ApplicationId = GetApplId(AppReference);
            string TravelDocumentId = GetTravelDocumentId(ApplicationId);
            string SPSCheckerId = GetSPSCheckerId();
            return ValidateSPSSummaryWithSQLBackend(ApplicationId, TravelDocumentId, SPSCheckerId);
        }

        public bool VerifyGBOutcomeWithSQLBackend(string AppReference)
        {
            string ApplicationId = GetApplId(AppReference);
            string TravelDocumentId = GetTravelDocumentId(ApplicationId);
            string GBCheckerId = GetGBCheckerId();
            string CheckOutcomeId = GetCheckOutcomeId(ApplicationId, TravelDocumentId, GBCheckerId);
            return ValidateGBOutcomeWithSQLBackend(CheckOutcomeId);
        }

        public bool VerifySPSOutcomeWithSQLBackend(string AppReference,string TypeOfPassenger, string SPSOutcome)
        {
            string ApplicationId = GetApplId(AppReference);
            string TravelDocumentId = GetTravelDocumentId(ApplicationId);
            string SPSCheckerId = GetSPSCheckerId();
            string CheckOutcomeId = GetCheckOutcomeId(ApplicationId, TravelDocumentId, SPSCheckerId);
            return ValidateSPSOutcomeWithSQLBackend(CheckOutcomeId, TypeOfPassenger, SPSOutcome);
        }
        #endregion
    }
}

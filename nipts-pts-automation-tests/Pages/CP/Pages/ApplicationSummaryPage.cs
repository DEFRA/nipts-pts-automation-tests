using Reqnroll.BoDi;
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
        private IWebElement rdoPass => _driver.WaitForElementExists(By.XPath("//div[@class='govuk-radios__item']//label[normalize-space()='Pass']/..//input"));
        private IWebElement rdoReferToSPS => _driver.WaitForElementExists(By.XPath("//div[@class='govuk-radios__item']//label[normalize-space()='Refer to SPS']/..//input"));
        private IWebElement rdoIssueSUPTD => _driver.WaitForElementExists(By.XPath("//div[@class='govuk-radios__item']//label[normalize-space()='Issue SUPTD']/..//input"));
        private IWebElement rdoFail => _driver.WaitForElementExists(By.XPath("//div[@class='govuk-radios__item']//label[normalize-space()='Fail']/..//input"));
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
        private IWebElement headerDepartureTime => _driver.WaitForElement(By.XPath("//div[@class='pts-location-bar']//p"));
        private IWebElement clickAccount => _driver.WaitForElement(By.XPath("//span[@id='account-text']"));
        private IWebElement RoleIdentification => _driver.WaitForElement(By.XPath("//span[contains(@class,'idm-table__cell--access-level-content')]"));
        private IWebElement SuspendedWarningText => _driver.WaitForElement(By.XPath("//div[@class='govuk-warning-text']"));
        private IWebElement ChecksOnSearchResults => _driver.WaitForElementExists(By.XPath("//h2[contains(@class,'govuk-heading-l')] [@id='search-results-heading']"));
        private IWebElement WarningOnSearchResults => _driver.WaitForElementExists(By.XPath("//strong[@class='govuk-warning-text__text']"));
        #endregion

        #region Methods
        public bool VerifyTheExpectedStatus(string status)
        {
            return _driver.WaitForElement(By.XPath($"(//h1[normalize-space()='{status}'])[1]")).Text.Trim().Equals(status);
        }

        public bool VerifyTheExpectedSubtitle(string applicationSubtitle)
        {
            return _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-panel__title')]/../following-sibling::h2")).Text.Trim().Equals(applicationSubtitle);
        }

        public bool VerifyTheSearchResultsHeading(string SearchResultsHeading)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", ChecksOnSearchResults);
            return _driver.WaitForElement(By.XPath("//h2[contains(@class,'govuk-heading-l')] [@id='search-results-heading']")).Text.Trim().Equals(SearchResultsHeading);
        }

        public void SelectPassRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoPass);
            rdoPass.Click();
        }
        public void SelectReferToSPSRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoReferToSPS);
            rdoReferToSPS.Click();
        }

        public void SelectIssueSUPTDRadioButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView()", rdoIssueSUPTD);
            rdoIssueSUPTD.Click();
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
            string sqlQuery1 = $"select Id from [dbo].[Organisation] where Location ='GB'";
            string OrganisationId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                OrganisationId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery1);
            }

            string sqlQuery2 = $"select Id from [dbo].[Checker] where FullName = 'pallavi GB Yewale' and OrganisationId = '{OrganisationId}'";
            string CheckerId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                CheckerId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery2);
            }
            return CheckerId;
        }

        private string GetSPSCheckerId()
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery1 = $"select Id from [dbo].[Organisation] where Location ='NI'";
            string OrganisationId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                OrganisationId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery1);
            }

            string sqlQuery2 = $"select Id from [dbo].[Checker] where FullName = 'pallavi SPS Yewale' and OrganisationId = '{OrganisationId}'";
            string CheckerId = "";
            if (ConfigSetup.BaseConfiguration != null)
            {
                CheckerId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery2);
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
            string sqlQuery = $"SELECT MCNotFound,GBRefersToDAERAOrSPS,GBAdviseNoTravel,GBPassengerSaysNoTravel FROM [dbo].[CheckOutcome]  Where Id = '{checkOutcomeId}'";
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
                        if (!PassangerRefToDAERA.Text.Contains("Passenger referred to DAERA/SPS at NI port"))
                            status = false;
                    }
                    else if (i == 2 && row[2].Equals(true))
                    {
                        if (!PassengerAdvised.Text.Contains("Passenger advised not to travel"))
                            status = false;
                    }
                    else if (i == 3 && row[3].Equals(true))
                    {
                        if (!PassengerNoTravel.Text.Contains("Passenger says they will not travel"))
                            status = false;
                    }
                }
            }
            return status;
        }

        private bool ValidateSPSOutcomeWithSQLBackend(string checkOutcomeId, string TypeOfPassenger, string SPSOutcome, string DetailsOfOutCome)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT MCNotFound,PassengerTypeId,SPSOutcome,SPSOutcomeDetails FROM [dbo].[CheckOutcome]  Where Id = '{checkOutcomeId}'";
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
                        if (!TypeOfPassenger.Contains("Airline"))
                        {
                            if (!MicrochipNotFound.Text.Contains("Cannot find microchip"))
                                status = false;
                        }
                    }
                    else if (i == 1)
                    {
                        if (TypeOfPassenger.Contains("Ferry foot passenger"))
                        {
                            if (row[1].Equals(1))
                                status = true;
                            else
                                status = false;
                        }
                        else if (TypeOfPassenger.Contains("Vehicle on ferry"))
                        {
                            if (row[1].Equals(2))
                                status = true;
                            else
                                status = false;
                        }
                        else if (TypeOfPassenger.Contains("Airline"))
                        {
                            if (row[1].Equals(3))
                                status = true;
                            else
                                status = false;
                        }
                    }
                    else if (i == 2 && row[2].Equals(true))
                    {
                        if (SPSOutcome.Contains("Allowed"))
                            status = true;
                        else
                            status = false;
                    }
                    else if (i == 2 && row[2].Equals(false))
                    {
                        if (SPSOutcome.Contains("Not allowed"))
                            status = true;
                        else
                            status = false;
                    }
                    else if (i == 3 && DetailsOfOutCome!= "")
                    {
                        if (row[3].Equals(DetailsOfOutCome))
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

                    if (i == 0 && !row[0].Equals(true))
                    {
                        status = false;
                    }
                    else if (i == 1 && row[1].Equals(null))
                    {
                        status = false;
                    }
                    else if (i == 2)
                    {
                        if (row[2].Equals(1) && !Route.Text.Contains("Birkenhead to Belfast (Stena)"))
                            status = false;
                        else if (row[2].Equals(2) && !Route.Text.Contains("Cairnryan to Larne (P&O)"))
                            status = false;
                        else if (row[2].Equals(3) && !Route.Text.Contains("Loch Ryan to Belfast (Stena)"))
                            status = false;
                    }
                    else if (i == 3)
                    {
                    }
                    else if (i == 4)
                    {
                    }
                }
            }

            return status;
        }

        private bool ValidateSPSSummaryWithSQLBackend(string applicationId, string travelDocumentId, string SPSCheckerId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT GBCheck,LinkedCheckId,FlightNo,RouteId,Date,ScheduledSailingTime,CheckOutcome FROM [dbo].[CheckSummary]  Where ApplicationId = '{applicationId}' and TravelDocumentId = '{travelDocumentId}' and [CheckerId]  = '{SPSCheckerId}'";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;
            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7, 29).Trim();
            Thread.Sleep(1000);
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(53, 10);
                departureTime = headerTime.Substring(64, 5);
            }
            else if (route.Contains("Cairnryan to Larne (P&O)"))
            {
                departureDate = headerTime.Substring(48, 10);
                departureTime = headerTime.Substring(59, 5);
            }
            else if (route.Contains("Loch Ryan to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(52, 10);
                departureTime = headerTime.Substring(63, 5);
            }


            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0 && !row[0].Equals(false))
                    {
                        status = false;
                    }
                    else if (i == 2)
                    {
                        if (row[2].Equals("AI 123"))
                        {
                            route = headerTime.Substring(15, 8).Trim();
                            departureDate = headerTime.Substring(38, 10);
                            departureTime = headerTime.Substring(49, 5);

                            if (!row[2].Equals(route))
                                status = false;
                        }
                    }
                    else if (i == 3 && !row[3].Equals(null))
                    {
                        if (row[3].Equals(1) && !Route.Text.Contains("Birkenhead to Belfast (Stena)"))
                            status = false;
                        else if (row[3].Equals(2) && !Route.Text.Contains("Cairnryan to Larne (P&O)"))
                            status = false;
                        else if (row[3].Equals(3) && !Route.Text.Contains("Loch Ryan to Belfast (Stena)"))
                            status = false;
                    }
                }
            }

            return status;
        }

        private bool ValidateGBSummaryForPassApplWithSQLBackend(string applicationId, string travelDocumentId, string gBCheckerId)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT GBCheck,RouteId,Date,ScheduledSailingTime,CheckOutcome FROM [dbo].[CheckSummary]  Where ApplicationId = '{applicationId}' and TravelDocumentId = '{travelDocumentId}' and [CheckerId]  = '{gBCheckerId}'";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;

            string departureDate = "";
            string departureTime = "";
            string headerTime = headerDepartureTime.Text.Trim();
            string route = headerTime.Substring(7, 29).Trim();
            Thread.Sleep(1000);
            if (route.Contains("Birkenhead to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(53, 10);
                departureTime = headerTime.Substring(64, 5);
            }
            else if (route.Contains("Cairnryan to Larne (P&O)"))
            {
                departureDate = headerTime.Substring(48, 10);
                departureTime = headerTime.Substring(59, 5);
            }
            else if (route.Contains("Loch Ryan to Belfast (Stena)"))
            {
                departureDate = headerTime.Substring(52, 10);
                departureTime = headerTime.Substring(63, 5);
            }

            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0)
                    {
                        if (!row[0].Equals(true))
                            status = false;
                    }
                    else if (i == 1)
                    {
                        if (row[1].Equals(1) && !route.Contains("Birkenhead to Belfast (Stena)"))
                            status = false;
                        else if (row[1].Equals(2) && !route.Contains("Cairnryan to Larne (P&O)"))
                            status = false;
                        else if (row[1].Equals(3) && !route.Contains("Loch Ryan to Belfast (Stena)"))
                            status = false;
                    }
                    else if (i == 2)
                    {
                    }
                    else if (i == 3)
                    {
                    }
                    else if (i == 4)
                    {
                        if (!row[4].Equals(true))
                            status = false;
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

        public bool VerifySPSOutcomeWithSQLBackend(string AppReference, string TypeOfPassenger, string SPSOutcome, string DetailsOfOutCome)
        {
            string ApplicationId = GetApplId(AppReference);
            string TravelDocumentId = GetTravelDocumentId(ApplicationId);
            string SPSCheckerId = GetSPSCheckerId();
            string CheckOutcomeId = GetCheckOutcomeId(ApplicationId, TravelDocumentId, SPSCheckerId);
            return ValidateSPSOutcomeWithSQLBackend(CheckOutcomeId, TypeOfPassenger, SPSOutcome, DetailsOfOutCome);
        }

        public bool VerifyGBSummaryForPassApplWithSQLBackend(string AppReference)
        {
            string ApplicationId = GetApplId(AppReference);
            string TravelDocumentId = GetTravelDocumentId(ApplicationId);
            string GBCheckerId = GetGBCheckerId();
            return ValidateGBSummaryForPassApplWithSQLBackend(ApplicationId, TravelDocumentId, GBCheckerId);
        }

        public void ClickOnAccount()
        {
            clickAccount.Click();
        }

        public void VerifyRole(string role)
        {
            RoleIdentification.Text.Equals(role);
        }

        public bool VerifySuspendedApplicationWithSQLBackend(string AppReference)
        {
            string ApplicationId = GetApplId(AppReference);
            return GetApplSummaryForSuspended(ApplicationId);
        }

        public bool VerifyUnSuspendedApplicationWithSQLBackend(string AppReference)
        {
            string ApplicationId = GetApplId(AppReference);
            return GetApplSummaryForUnSuspended(ApplicationId);
        }

        public bool VerifySuspendedApplicationWithSQLBackendWithPTD(string PTDNumber)
        {
            return GetSuspendedApplicationWithSQLBackendWithPTD(PTDNumber);
        }

        public bool VerifyUnSuspendedApplicationWithSQLBackendWithPTD(string PTDNumber)
        {
            return GetUnSuspendedApplicationWithSQLBackendWithPTD(PTDNumber);
        }

        public bool GetApplSummaryForSuspended(string ApplicationId)
        {
            Thread.Sleep(7000);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT Status,DateSuspended  FROM [dbo].[Application] Where [Id] = '{ApplicationId}'";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;
            string todaysDate = DateTime.Now.Day.ToString().Trim();

            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0)
                    {
                        if (!row[0].Equals("Suspended"))
                            status = false;
                    }
                    else if (i == 1)
                    {
                        if (row[1] == null)
                        {
                            status = false;
                        }
                    }
                }
            }

            return status;
        }

        public bool GetApplSummaryForUnSuspended(string ApplicationId)
        {
            Thread.Sleep(7000);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery = $"SELECT Status,DateUnsuspended  FROM [dbo].[Application] Where [Id] = '{ApplicationId}'";
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

                    if (i == 0)
                    {
                        if (!row[0].Equals("Authorised"))
                            status = false;
                    }
                    else if (i == 1)
                    {
                        if (row[1] == null)
                        {
                            status = false;
                        }
                    }
                }
            }
            return status;
        }

        public bool GetSuspendedApplicationWithSQLBackendWithPTD(string PTDNumber)
        {
            Thread.Sleep(7000);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery1 = $"SELECT ApplicationId  FROM [dbo].[TravelDocument] Where [DocumentReferenceNumber] = '{PTDNumber}'";
            string ApplicationId = "";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;

            if (ConfigSetup.BaseConfiguration != null)
            {
                ApplicationId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery1);
            }

            string sqlQuery2 = $"SELECT Status,Datesuspended  FROM [dbo].[Application] Where [Id] = '{ApplicationId}'";

            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery2);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0)
                    {
                        if (!row[0].Equals("Suspended"))
                            status = false;
                    }
                    else if (i == 1)
                    {
                        if (row[1] == null)
                        {
                            status = false;
                        }
                    }
                }
            }
            return status;
        }

        public bool GetUnSuspendedApplicationWithSQLBackendWithPTD(string PTDNumber)
        {
            Thread.Sleep(7000);
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;
            string sqlQuery1 = $"SELECT ApplicationId  FROM [dbo].[TravelDocument] Where [DocumentReferenceNumber] = '{PTDNumber}'";
            string ApplicationId = "";
            DataTable sqlData = null;
            bool status = true;
            int i = 0;

            if (ConfigSetup.BaseConfiguration != null)
            {
                ApplicationId = dataHelperConnections.ExecuteQuery(connectionString, sqlQuery1);
            }

            string sqlQuery2 = $"SELECT Status,DateUnsuspended  FROM [dbo].[Application] Where [Id] = '{ApplicationId}'";

            if (ConfigSetup.BaseConfiguration != null)
            {
                sqlData = dataHelperConnections.ExecuteQueryData(connectionString, sqlQuery2);
            }

            foreach (DataRow row in sqlData.Rows)
            {
                for (i = 0; i < sqlData.Columns.Count; i++)

                {
                    Console.WriteLine($"Row: {row[i]}");

                    if (i == 0)
                    {
                        if (!row[0].Equals("Authorised"))
                            status = false;
                    }
                    else if (i == 1)
                    {
                        if (row[1] == null)
                        {
                            status = false;
                        }
                    }
                }
            }
            return status;
        }

        public bool VerifyTheSuspendedApplicationWarning(string SuspendedApplicationWarning)
        {
            string text = SuspendedWarningText.Text;
            if (SuspendedWarningText.Text.Contains(SuspendedApplicationWarning))
                return true;
            else
                return false;
        }

        public bool VerifyTheContinueButtonNotDisplayed()
        {
            if (_driver.FindElements(By.XPath("//button[contains(text(),'Continue')]")).Count>0)
                return false;
            else
                return true;
        }

        public bool VerifyThePassButtonNotDisplayed()
        {
            if (_driver.FindElements(By.XPath("//label[normalize-space()='Pass']/..//input")).Count > 0)
                return false;
            else
                return true;
        }

        public bool VerifyTheFailButtonNotDisplayed()
        {
            if (_driver.FindElements(By.XPath("//label[normalize-space()='Fail or referred to SPS']/..//input")).Count > 0)
                return false;
            else
                return true;
        }

        public bool VerifyWarningMessageOnSearchResultPage(string status)
        { 
            string warningText = WarningOnSearchResults.Text;
            string warningMessgae = $"Because the PTD is ‘"  + status + "’, you should check whether you can issue a SUPTD";
            if (warningText.Contains(warningMessgae))
                return true;
            else
                return false;
        }

        #endregion
    }
}

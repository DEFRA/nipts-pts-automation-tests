namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IApplicationSummaryPage
    {
        bool VerifyTheExpectedStatus(string status);
        void SelectPassRadioButton();
        void SelectReferToSPSRadioButton();
        void SelectSaveAndContinue();
        bool IsError(string errorMessage);
        void SelectContinue();
        bool VerifyTheExpectedSubtitle(string applicationSubtitle);
        string getNewID();
        public bool VerifyGBOutcomeWithSQLBackend(string AppReference);
        public bool VerifySPSOutcomeWithSQLBackend(string AppReference,string TypeOfPassenger, string SPSOutcome);
        public bool VerifyGBSummaryOutputWithSQLBackend(string AppReference);
        public bool VerifySPSSummaryOutputWithSQLBackend(string AppReference);
        public bool VerifyGBSummaryForPassApplWithSQLBackend(string AppReference);
        void ClickOnAccount();
        public void VerifyRole(string role);
        public bool VerifySuspendedApplicationWithSQLBackend(string AppReference);
        public bool VerifyUnSuspendedApplicationWithSQLBackend(string AppReference);
        public bool VerifySuspendedApplicationWithSQLBackendWithPTD(string PTDNumber);
        public bool VerifyUnSuspendedApplicationWithSQLBackendWithPTD(string PTDNumber);
        public bool VerifyTheSuspendedApplicationWarning(string SuspendedApplicationWarning);
        bool VerifyTheContinueButtonNotDisplayed();
        bool VerifyThePassButtonNotDisplayed();
        bool VerifyTheFailButtonNotDisplayed();
        public bool VerifyTheSearchResultsHeading(string SearchResultsHeading);
        void SelectIssueSUPTDRadioButton();
        void SelectFailRadioButton();
    }
}

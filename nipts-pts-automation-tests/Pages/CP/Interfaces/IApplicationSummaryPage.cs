﻿namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IApplicationSummaryPage
    {
        bool VerifyTheExpectedStatus(string status);
        void SelectPassRadioButton();
        void SelectFailRadioButton();
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
    }
}

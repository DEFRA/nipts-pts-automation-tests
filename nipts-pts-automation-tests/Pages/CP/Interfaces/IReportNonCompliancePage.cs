namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IReportNonCompliancePage
    {
        bool IsPageLoaded();
        void SelectReportNonComplianceButton();
        void ClickPetTravelDocumentDetailsLnk();
        bool VerifyTheExpectedStatus(string status);
        void SelectTypeOfPassenger(string radioButtonValue);
        bool IsError(string errorMessage);
        void ClickOnSPSOutcome(string SPSStatus);
        void ClickOnGBOutcome();
        public void TickMicrochipNoDoesNotMatchPTD();
        public void EnterMichrochipNoDoesNotMatchPTD(string michrochipNo);
        public void ClickOnSaveOutcome();
        public void SelectNonComplianceReason(string nonComplianceReason);
        public bool VerifyOtherReasonHintTxt(string otherReasonHintTxt);
        public bool VerifyGBOutcomeHintTxt(string GBOutcomeMsg);
        public bool VerifyNIOutcomeHintTxt(string NIOutcomeMsg);
        bool VerifyPTDNumber(string ptdNumberNew);
        bool VerifyApplicationReferenceNumber(string AppRefNumber);
        void SelectMicrochipReason(string microchipReason);
        void EnterAdditionalComment(string additionalComment);
        void SelectGBOutcome(string gBOutcome);
        void SelectVisualCheck(string visualCheck);
        void SelectOtherIssues(string otherIssues);
        void EnterDetailsOfOutCome(string detailsOfOutCome);

    }
}

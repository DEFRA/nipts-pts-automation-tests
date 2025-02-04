namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IRefferedToSPSPage
    {
        void ClickOnPTDNumberOfTheApplication(string ptdNumber);
        void VerifyReferredToSPSDetails();
        void VerifySPSOutcome(string outcome);
        void ClickOnPage(string pageNumber);
        bool VerifyReferredToSPSRecordCount(int count);
        void ClickOnNextPage(string nextPage);
        void GetPTDReferenceAndAddInCollection();
        void ArrangePTDRefNumberInAscendingOrder();
        bool VerifyAscendingOderOfPTDReference();
    }
}

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
    }
}

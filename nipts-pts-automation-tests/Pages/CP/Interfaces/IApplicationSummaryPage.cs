namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IApplicationSummaryPage
    {
        bool VerifyTheExpectedStatus(string status);
        void SelectPassRadioButton();
        void SelectFailRadioButton();
        void SelectSaveAndContinue();
        bool IsError(string errorMessage);
        void SelectContinue();
    }
}

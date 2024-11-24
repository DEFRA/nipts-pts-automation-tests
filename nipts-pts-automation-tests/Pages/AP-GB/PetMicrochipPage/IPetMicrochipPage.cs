namespace nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipPage
{
    public interface IPetMicrochipPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectMicrochippedOption(string option);
        string EnterMicrochipNumber();
        string EnterGivenMicrochipNumber(string microChipNumber);
        void UpdateMicrochipNumber(string microChipNumber);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
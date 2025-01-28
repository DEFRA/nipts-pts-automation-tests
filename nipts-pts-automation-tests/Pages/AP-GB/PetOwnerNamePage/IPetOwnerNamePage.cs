namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerNamePage
{
    public interface IPetOwnerNamePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerName(string onwerName);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
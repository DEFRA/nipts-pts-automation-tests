namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPNumberPage
{
    public interface IPetOwnerPhoneNumberPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPNumber(string phoneNumber);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
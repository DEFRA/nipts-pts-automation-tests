namespace nipts_pts_automation_tests.Pages.AP_GB.PetNamePage
{
    public interface IPetsNamePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void EnterPetsName(string petsName);
        bool IsError(string errorMessage);
    }
}
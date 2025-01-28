namespace nipts_pts_automation_tests.Pages.AP_GB.PetSexPage
{
    public interface IPetsSexPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectPetsSexOption(string sexType);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}

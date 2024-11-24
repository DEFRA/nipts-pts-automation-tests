namespace nipts_pts_automation_tests.Pages.AP_GB.PetColourPage
{
    public interface IPetsColourPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectColorOption(string color);
        void SelectOtherColorOption(string color);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
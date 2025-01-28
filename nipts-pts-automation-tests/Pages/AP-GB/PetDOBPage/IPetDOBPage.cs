namespace nipts_pts_automation_tests.Pages.AP_GB.PetDOBPage
{
    public interface IPetDOBPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string EnterDateMonthYear(DateTime dateTime);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
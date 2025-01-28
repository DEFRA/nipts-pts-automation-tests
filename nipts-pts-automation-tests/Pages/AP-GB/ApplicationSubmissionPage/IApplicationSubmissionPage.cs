namespace nipts_pts_automation_tests.Pages.AP_GB.ApplicationSubmittedPage
{
    public interface IApplicationSubmissionPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string GetApplicationReferenceNumber();
        void ClickApplyForAnotherPetTravelDocument();
        void ClickViewAllSubmittedPetTravelDocument();
    }
}
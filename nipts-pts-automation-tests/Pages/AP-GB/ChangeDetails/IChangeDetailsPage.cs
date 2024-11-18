using Defra.UI.Tests.Contracts;

namespace nipts_pts_automation_tests.Pages.AP_GB.ChangeDetails
{
    public interface IChangeDetailsPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void SelectOption(string option);
        Summary GetRegisteredUserDetails();
    }
}

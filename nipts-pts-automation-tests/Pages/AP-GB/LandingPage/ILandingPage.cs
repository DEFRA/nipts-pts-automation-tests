namespace nipts_pts_automation_tests.Pages.AP_GB.LandingPage
{
    public interface ILandingPage
    {
        bool IsPageLoaded(string pageName);
        void EnterPassword();
        void ClickContinueButton();
        bool VerifyNextPageIsLoaded(string pageName);
    }
}

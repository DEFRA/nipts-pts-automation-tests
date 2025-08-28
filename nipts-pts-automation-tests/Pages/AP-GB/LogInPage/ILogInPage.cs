namespace nipts_pts_automation_tests.Pages.AP_GB.LogInPage
{
    public interface ILogInPage
    {
        public bool IsPageLoaded();
        public bool IsSignedIn(string userName, string password);
        public void ClickCreateSignInDetailsLink();
        public void ClickSignedOut();
        public bool IsSignedOut();
        public void SelectSignInMethod();
    }
}

namespace nipts_pts_automation_tests.Pages
{
    public interface ISignInPage
    {
        public void ClickSignIn();
        public void ClickSignedOut();
        public bool IsSignedIn(string userId, string password);
        public bool IsSignedOut();
        public void EnterPassword();
        public bool VerifySignOutTextInSelectedLanguage(string signOutText);
    }
}

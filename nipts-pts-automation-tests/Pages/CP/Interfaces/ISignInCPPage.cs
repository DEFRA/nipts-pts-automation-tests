namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface ISignInCPPage
    {
        void ClickSignInButton();
        void IsSignedIn(string userName, string password);
        void EnterPassword();
        bool IsSignedOut();
    }
}

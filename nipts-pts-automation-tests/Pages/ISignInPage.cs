namespace pets_com_automation_tests.Pages
{
    public interface ISignInPage
    {
        public void ClickSignIn();
        public void ClickSignedOut();
        public bool IsSignedOut();
        public void EnterPAssword();
    }
}

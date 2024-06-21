namespace nipts_pts_automation_tests.Pages
{
    public interface IApplicationPage
    {
        public bool VerifyNextPageIsLoaded(string pageName);
        public void ClickOnWelshLang();
        public void ClickOnApplyForADocument();
        public void ClickOnEnglishLang();
        public void ClickOnContinueWelsh();
        public void ClickOnBackWelsh();
    }
}

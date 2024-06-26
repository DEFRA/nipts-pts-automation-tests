
namespace nipts_pts_automation_tests.Pages
{
    public interface IFooterPage
    {
        public void ClickOnAccessibilityFooterLink();
        public void ClickOnCookiesFooterLink();
        public void ClickOnPrivacyFooterLink();
        public void ClickOnTCsFooterLink();
        public bool VerifyFooterText(string footerHintText);
        public bool VerifyLinkText(string link);
        public bool VerifyPageTitle(string pageTitle);
    }
}

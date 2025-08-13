
namespace nipts_pts_automation_tests.Pages
{
    public interface IFooterPage
    {
        public bool ClickOnAccessibilityFooterLink();
        public bool ClickOnCookiesFooterLink();
        public bool ClickOnPrivacyFooterLink();
        public bool ClickOnTCsFooterLink();
        public void OpenAccessibilityLinkPage();
        public void OpenCookiesLinkPage();
        public void OpenTCsLinkPage();
        public bool VerifyFooterText(string footerHintText);
        public bool VerifyLinkText(string link);
        public bool VerifyPageTitle(string pageTitle);
    }
}

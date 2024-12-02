
namespace nipts_pts_automation_tests.Pages
{
    public interface IFooterPage
    {
        public bool ClickOnAccessibilityFooterLink();
        public bool ClickOnCookiesFooterLink();
        public bool ClickOnPrivacyFooterLink();
        public bool ClickOnTCsFooterLink();
        public bool VerifyFooterText(string footerHintText);
        public bool VerifyLinkText(string link);
        public bool VerifyPageTitle(string pageTitle);
        public void SelectGoogleAnalyticsOption(string googleAnalytics);
        public void ClickOnSaveGoogleAnalyticsBtn();
        public bool VerifyGoogleAnalyticsBanner(string BannerText);
        public void SelectGoogleAnalyticsOptionOnHeader(string googleAnalyticsOption);
        public void ClickOnHideCookiesBtn();
        public bool VerifyHideCookieMessageButtonOnGoogleAnalyticsBanner();
        public void ClickChangeCookieSettingslnk();
       
    }
}

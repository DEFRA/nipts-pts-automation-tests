
namespace nipts_pts_automation_tests.Pages
{
    public interface IHeaderPage
    {
        public void ClickGOVHeaderLink();
        public void ClickOnFeedBackLink();
        public bool VerifyFeedbackPageLoaded();
        public bool VerifyGenericGOVPageLoaded();
        public bool VerifyHeaderTitle(string pageTitle);
        public bool VerifyHeaderBanner(string bannerText);
        public void DeleteBrowserCookies();
        public bool VerifyCookiesBannerWelsh(string cookiesWELSHText);
        public bool VerifyCookiesPrefTextWelsh(string cookiesText);
        public void ClickCookiesPrefButton(string prefBtn);
        bool? VerifyFeedbackPageText(string text);
        bool? VerifyLinkOnFeedbackPage(string link);
    }
}

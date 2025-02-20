namespace nipts_pts_automation_tests.Pages.AP_GB.HomePage
{
    public interface IHomePage
    {
        bool IsPageLoaded();
        void ClickApplyForPetTravelDocument();
        void ClickFeedbackLink();
        bool IsNextPageLoaded(string pageTitle);
        void ClickGethelpLink();
        void ClickAccessibilityStatementLink();
        void ClickCookiesLink();
        void ClickPrivacyNoticeLink();
        void ClickTermsAndConditionsLink();
        void ClickCrownCopyrightLink();
        bool VerifyTheExpectedStatus(string petName, string status);
        bool VerifyTheApplicationIsNotAvailable(string PetName);
        void ClickViewLink(string petName);
        void ClickOnManageAccountLink();
        void ClickOnLifelongPetTravelDocumentsFromHeader();
    }
}
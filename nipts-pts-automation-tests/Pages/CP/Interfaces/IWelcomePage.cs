namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IWelcomePage
    {
        bool IsPageLoaded();
        void FooterSearchButton();
        void HeadersChangeLink();
        void FooterHomeIcon();
        void clickOnView();
        bool DepartureDateTimeCheck();
        bool DepartureDateTimeCheckForFlight();
        void clickOnViewWithSPSUser(string departureRoute);
        bool VerifySubmiitedMessage();
        bool VerifyEntriesOnCheckerPage();
        bool getPassCount(string passCount);
        bool VerifyNoViewLinkIfNoReferredToSPS();
        bool VerifyNoViewLinkIfNoReferredToSPSWithSPSUser();
    }
}

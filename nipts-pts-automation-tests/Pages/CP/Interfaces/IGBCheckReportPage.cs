namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IGBCheckReportPage
    {
        void VerifyGBCheckReport();
        void ClickOnUpdateReferralOutcome();
        bool VerifyMicrochipReason(string NumberMicrochipReason, string microchipReason,string NumberOtherIssues);
        bool VerifyAdditionalComment(string additionalComment);
        bool VerifyGBOutcome(string NumberGBOutcome,string gBOutcome);
        bool? VerifyOtherIssues(string numberOtherIssues, string otherIssues, string NumberMicrochipReason);
        bool? VerifyDetailsOfOutcome(string detailsOfOutcome);
    }
}

﻿namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IGBCheckReportPage
    {
        void VerifyGBCheckReport();
        void ClickOnConductAnSPSCheck();
        bool VerifyMicrochipReason(string NumberMicrochipReason, string microchipReason);
        bool VerifyAdditionalComment(string additionalComment);
        bool VerifyGBOutcome(string NumberGBOutcome,string gBOutcome);
    }
}

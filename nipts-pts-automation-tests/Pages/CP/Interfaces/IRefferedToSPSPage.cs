namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IRefferedToSPSPage
    {
        void ClickOnPTDNumberOfTheApplication(string ptdNumber);
        public bool VerifyReferredToSPSDetails(string ptdNumberNew, string petType, string michrochipNo);
        public bool VerifySPSOutcome(string outcome);
        public bool VerifyDepartureDetailsSPSPage();

    }
}

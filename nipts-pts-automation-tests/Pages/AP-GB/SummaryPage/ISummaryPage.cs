using Defra.UI.Tests.Contracts;

namespace nipts_pts_automation_tests.Pages.AP_GB.SummaryPage
{
    public interface ISummaryPage
    {
        bool IsNextPageLoaded(string pageTitle);
        Summary GetSummaryDetails();
        public void ClickPDFDownloadLink();
        public bool ClickPrintdLink();
        public bool VerifyStatusOnAppSummary(string fieldName, string fieldValue);
        public bool VerifyPrintDownloadPDFLinksSuspendedUser();
    }
}

namespace nipts_pts_automation_tests.Pages
{
    public interface IInvalidDocumentsPage
    {
        public void ClickOnViewInvalidDocumentLinkWELSH();
        public void ClickViewLnkInvalidDocPage(string petName);
        public bool VerifyStatusOnInvalidDocsPTDWELSH(string fieldName, string fieldValue);
        public bool VerifyNewApplInvalidPage(string petName);
    }
}

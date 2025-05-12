namespace nipts_pts_automation_tests.Pages
{
    public interface ICheckYourAnswersDeclarationPage
    {
        public void TickAgreedToAccuracy();
        public void TickAgreedToDeclaration();
        public void TickAgreetToPrivacyPolicy();
        public void ClickSendApplicationButton();
        public void ClickApplyForAnotherPetTravelDocument();
        public bool VerifyWELSHSummaryOnAppSummary(string fieldName, string fieldValue);
        public bool VerifyMichrochipDateOnAppSummaryInWelsh(string michrochipDate, string michrochipDateValue);
        public bool VerifyPetDOBOnAppSummaryInWelsh(string petDOB, string petDOBValue);
        public void ClickViewAllPetTravelDocument();
        public bool VerifyGenderOnWELSHAppSummary(string fieldName, string fieldValue);
    }
}

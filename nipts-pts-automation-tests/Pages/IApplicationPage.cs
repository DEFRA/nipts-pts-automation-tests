namespace nipts_pts_automation_tests.Pages
{
    public interface IApplicationPage
    {
        public bool VerifyTheExpectedStatus(string petName, string status);
        public bool VerifyNextPageIsLoaded(string pageName);
        public void ClickOnWelshLang();
        public void ClickOnApplyForADocument();
        public void ClickOnEnglishLang();
        public void ClickOnContinueWelsh();
        public void ClickOnBackWelsh();
        public void SwitchToPreviousOpenTab();
        public void SwitchToNextTab();
        public void ClickBrowserBack();
        public void CloseCurrentTab();
        public bool VerifyErrorMessage(string errorMessage);
        public void ClickOnManageAccountLink();
        public void ClickOnManageYourAccountLink();
        public void ClickOnViewYourPetTravelDoc();
        public bool VerifyLanguageAtPageFooter(string displayedLang);
        public void ClickOnContinueEng();
        public void ClickOnHelpWelshLink();
        void ClickWelshPetDetailsChangeLink(string fieldName);
        void ClickWelshPetDetailsChangeForFerretLink(string fieldName);
        void ClickWelshMicrochipChangeLink(string fieldName);
        void ClickWelshPetOwnerChangeLink(string fieldName);
        public bool VerifyWELSHApprovedPTD(string fieldName, string fieldValue);
        public bool VerifyPTDNumberOnApprovedPTD(string ptdNumber, string ptdNumberValue);
        public bool VerifyMichrochipDateOnApprovedPTD(string michrochipDate, string michrochipDateValue);
        public bool VerifyPetDOBOnApprovedPTD(string petDOB, string petDOBValue);
        bool? VerifyWELSHFieldsAndValuesForPendingAppl(string fieldName, string fieldValue);
        bool? VerifyReferenceNumberOnPendingAppl(string referenceNumberText, string referenceNumberValue);
        bool? VerifyMichrochipDateOnPendingAppl(string michrochipDateText, string michrochipDateValue);
        bool? VerifyPetDOBOnPendingAppl(string petDOBText, string petDOBValue);
    }
}

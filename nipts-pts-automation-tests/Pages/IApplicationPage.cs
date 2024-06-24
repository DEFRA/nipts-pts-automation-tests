
namespace nipts_pts_automation_tests.Pages
{
    public interface IApplicationPage
    {
        public bool VerifyNextPageIsLoaded(string pageName);
        public void ClickOnWelshLang();
        public void ClickOnEnglishLang();
        public bool VerifyLanguageAtPageFooter(string displayedLang);
        public void ClickOnApplyForADocument();
        public void ClickOnManageAccountLink();
        public void ClickOnManageYourAccountLink();
        public void ClickOnViewYourPetTravelDoc();

    }
}

namespace nipts_pts_automation_tests.Pages
{
    public interface IPetSexPage
    {
        public void SelectPetsSexOption(string sex);
        public bool VerifyErrorMessageOnSelectSexOfPetPage(string errorMessage);
    }
}

namespace nipts_pts_automation_tests.Pages
{
    public interface IPetNamePage
    {
        public void EnterNameOfPet(string petName);
        public bool VerifyErrorMessageOnEnterPetNamePage(string errorMessage);

    }
}

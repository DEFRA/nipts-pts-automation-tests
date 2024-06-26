namespace nipts_pts_automation_tests.Pages
{
    public interface IFullNamePage
    {
        public void EnterFullName(string fullName);
        public bool ThenVerifyErrorMessageOnPetsFullNamePage(string errorMessage);
    }
}

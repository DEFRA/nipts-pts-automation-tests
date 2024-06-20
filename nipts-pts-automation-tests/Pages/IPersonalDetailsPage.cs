namespace nipts_pts_automation_tests.Pages
{
    public interface IPersonalDetailsPage
    {
        public bool VerifyPersonalDetails(string userType);
        public void SelectOptionOnPersonalDetailsPage(string option);
        public bool VerifyErrorMessageOnPersonalDetailsPage(string errorMessage);
    }
}

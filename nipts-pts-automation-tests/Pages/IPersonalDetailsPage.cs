namespace nipts_pts_automation_tests.Pages
{
    public interface IPersonalDetailsPage
    {
        public bool VerifyPersonalDetails(string user);
        public void ClickOnContinue();
        public void ClickOnBack();
        public void SelectOptionOnPersonalDetailsPage(string option);

    }
}

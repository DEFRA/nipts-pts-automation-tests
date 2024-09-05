namespace nipts_pts_automation_tests.Pages
{
    public interface IMicrochipDatePage
    {
        public string EnterDateMonthYear(DateTime dateTime);
        public bool VerifyErrorMessageOnMicrochipDatePage(string errorMessage);
    }
}
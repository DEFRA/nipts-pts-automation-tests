namespace nipts_pts_automation_tests.Pages
{
    public interface IMicrochipDatePage
    {
        public string EnterDateMonthYear(DateTime dateTime);
        public void EnterPetsMicrochipDate(string microchipDay, string microchipMonth, string microchipYear);
    }
}
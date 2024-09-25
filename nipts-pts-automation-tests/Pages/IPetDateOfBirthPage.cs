namespace nipts_pts_automation_tests.Pages
{
    public interface IPetDateOfBirthPage
    {
        public string EnterDateMonthYear(DateTime dateTime);
        public void EnterPetsDateOfBirth(string PetDOBDay, string PetDOBMonth, string PetDOBYear);
    }
}

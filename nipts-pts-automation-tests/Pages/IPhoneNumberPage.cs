namespace nipts_pts_automation_tests.Pages
{
    public interface IPhoneNumberPage
    {
        public void EnterPhoneNumber(string phoneNumber);
        public bool VerifyErrorMessageOnPetsTelephoneNumberPage(string errorMessage);
    }
}

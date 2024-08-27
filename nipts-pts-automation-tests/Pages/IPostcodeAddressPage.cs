namespace nipts_pts_automation_tests.Pages
{
    public interface IPostcodeAddressPage
    {
        public void ClickChangePostcode();
        public void EnterPostcode(string postcode);
        public void SelectAddress();
        public bool ThenVerifyErrorMessageOnPetsPostcodePage(string errorMessage);
    }
}

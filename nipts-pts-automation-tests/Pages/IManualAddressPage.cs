namespace nipts_pts_automation_tests.Pages
{
    public interface IManualAddressPage
    {
        public void ClickEnterAddressManually();
        public void ClickOnCannotFindTheAddressInTheList();
        public void EnterAddress(string addline1, string addline2, string city, string country, string postcode);
        
        public bool VerifyErrorMessageOnManualAddressPage(string errorMessage);
    }
}

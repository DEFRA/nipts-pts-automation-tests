namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressManuallyPage
{
    public interface IPetOwnerAddressManuallyPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterAddressManually(string firstLine, string secondLine, string city, string county, string postCode);
        void ClickContinueButton();
    }
}
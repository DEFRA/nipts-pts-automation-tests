namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPostCodePage
{
    public interface IPetOwnerPostCodePage
    {
        bool IsNextPageLoaded(string pageTitle);
        void EnterPetOwnerPostCode(string PostCode);
        void ClickFindAddressButton();
        void ClickManuallyAddressLink();
    }
}
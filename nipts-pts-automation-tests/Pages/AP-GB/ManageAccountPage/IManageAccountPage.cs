namespace nipts_pts_automation_tests.Pages.AP_GB.ManageAccountPage
{
    public interface IManageAccountPage
    {
        void ClickOnManageYourAccountLink();
        void ClickOnUpdatedetailsLink();
        void ClickOnChangePersonalInformationLink();
        void ClickOnChangePersonalAddressLink();
        void EnterPhoneNumber(String phoneNumber);
        void ClickContinue();
        void ClickBackButton();
        void ClickPetsLink();
        string EnterFirstName(string firstName);
        string EnterLastName(string surname);
        string ClickOnSearchUKPostcodeLink();
        void EnterTheValidPostcode(string postcode);
        void ClickFindAddressButton();
        string SelectTheAddress();
    }
}

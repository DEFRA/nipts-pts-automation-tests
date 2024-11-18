namespace nipts_pts_automation_tests.Pages.AP_GB.PetOwnerDetailsPage
{
    public interface IPetOwnerDetailsPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void ClickContinueButton();
        void SelectIsOwnerDetailsCorrect(string petsOwnerDetails);
        bool VerifyUpdatedPhoneNumber(String phoneNumber);
        bool VerifyUpdatedName(string petOwnerName);
        bool VerifyUpdatedPetOwnerAddress(string petOwnerAddress);
        public bool IsError(string errorMessage);
    }
}
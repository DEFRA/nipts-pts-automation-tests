namespace nipts_pts_automation_tests.Pages.AP_GB.PetBreedPage
{
    public interface IPetsBreedPage
    {
        public bool IsNextPageLoaded(string pageTitle);
        string SelectPetsBreed(int breedIndex);
        void ClickContinueButton();
        void EnterFreeTextBreed(string breed);
        bool IsError(string errorMessage);
    }
}
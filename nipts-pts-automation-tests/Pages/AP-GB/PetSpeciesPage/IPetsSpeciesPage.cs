namespace nipts_pts_automation_tests.Pages.AP_GB.PetSpeciesPage
{
    public interface IPetsSpeciesPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectSpecies(string petCategory);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}
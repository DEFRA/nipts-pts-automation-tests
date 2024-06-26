
namespace nipts_pts_automation_tests.Pages
{
    public interface IEnterSpeciesPage
    {
        public bool VerifyErrorMessageOnEnterSpeciesPage(string errorMessage);
        public void SelectSpecies(string species);
    }
}

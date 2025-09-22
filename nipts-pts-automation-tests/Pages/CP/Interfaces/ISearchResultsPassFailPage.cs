
namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    internal interface ISearchResultsPassFail
    {
        public bool VerifyPTDNoOnSearchResultsPassFailPage(string ptdNumber);
        public bool VerifySignificantFeaturesOption(string sigFeatures);
        public bool VerifyOtherClrOption(string otherClr);
        public bool VerifyPetBreedOption(string petBreed);
        bool VerifyPetpetMicrochipNumber(string petMicrochipNumber);
        bool VerifyPetSexOption(string petSex);
        bool VerifyPetSpeciesOption(string petSpecies);
        bool VerifyPetNameOption(string petName);
        bool VerifypetsDateOfBirth(string petsDateOfBirth);
        bool VerifyPetpetMicrochipDate(string petMicrochipDate);
        bool VerifyBulletedPointOnSearchResultsPage();
    }
}

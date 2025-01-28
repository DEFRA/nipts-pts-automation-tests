
namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    internal interface ISearchResultsPassFail
    {
        public bool VerifyPTDNoOnSearchResultsPassFailPage(string ptdNumber);
        public bool VerifySignificantFeaturesOption(string sigFeatures);
        public bool VerifyOtherClrOption(string otherClr);
        public bool VerifyPetBreedOption(string petBreed);
    }
}

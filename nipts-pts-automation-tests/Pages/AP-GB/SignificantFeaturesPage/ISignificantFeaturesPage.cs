namespace nipts_pts_automation_tests.Pages.AP_GB.SignificantFeaturesPage
{
    public interface ISignificantFeaturesPage
    {
        bool IsNextPageLoaded(string pageTitle);
        string SelectSignificantFeaturesOption(string featuresOption);
        void ClickContinueButton();
        bool IsError(string errorMessage);
        void EnterSignificantFeatures(string significantFeatures);
    }
}
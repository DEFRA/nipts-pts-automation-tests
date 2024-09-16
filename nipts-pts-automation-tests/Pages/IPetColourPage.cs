namespace nipts_pts_automation_tests.Pages
{
    public interface IPetColourPage
    {
        public void SelectColorOption(string color);
        public bool VerifyErrorMessageOnPetColorPage(string errorMessage);
        public void EnterOtherColorText(string petColour);
    }
}

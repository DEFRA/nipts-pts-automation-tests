using Defra.UI.Tests.Contracts;

namespace nipts_pts_automation_tests.Pages.AP_GB.ApplicationDeclarationPage
{
    public interface IApplicationDeclarationPage
    {
        bool IsNextPageLoaded(string pageTitle);
        bool IsCustomPageLoaded(string pageTitle);
        void TickAgreedToDeclaration();
        void ClickSendApplicationButton();
        Summary GetSummaryDetails();
        void ClickMicrochipChangeLink(string fieldName);
        void ClickPetDetailsChangeLink(string fieldName);
        void ClickPetOwnerChangeLink(string fieldName);
        void ClickPetDetailsChangeForFerretLink(string fieldName);
    }
}

namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IOutagePage
    {
        void LoadThe404ErrorPage();
        bool VerifyTextOnPage(string text);
        bool VerifyTheOutageLink(string outageLink);
        bool VerifyHeadingOnPage(string Heading);
        bool VerifyAccountAndSignOutLinksOnPage();
        bool VerifyHeaderTextOnPage(string HeaderText);
    }
}

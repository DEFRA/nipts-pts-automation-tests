using Reqnroll.BoDi;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.GetYourPetMicrochippedPage
{
    public class GetYourPetMicrochippedPage : IGetYourPetMicrochippedPage
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"), true);

        public GetYourPetMicrochippedPage(IObjectContainer container)
        {
            _objectContainer = container;
        }
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }
    }
}

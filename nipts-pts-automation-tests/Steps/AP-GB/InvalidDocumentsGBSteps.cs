using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Pages.AP_GB.InvalidDocumentsGBPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class InvalidDocumentsGBPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IInvalidDocumentsGBPage? InvalidDocumentsGBPage => _objectContainer.IsRegistered<IInvalidDocumentsGBPage>() ? _objectContainer.Resolve<IInvalidDocumentsGBPage>() : null;
        public InvalidDocumentsGBPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        
        [Then(@"verify status on the application summary as '([^']*)' '([^']*)' on GB Invalid documents page")]
        public void ThenVerifyStatusOnInvalidDoc(string fieldName, string fieldValue)
        {
            Assert.True(InvalidDocumentsGBPage?.VerifyStatusOnInvalidDocsPTD(fieldName, fieldValue), "Status mistmatch on Pending application");
        }

    }
}

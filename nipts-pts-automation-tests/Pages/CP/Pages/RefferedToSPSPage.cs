using BoDi;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class RefferedToSPSPage : IRefferedToSPSPage
    {
        private readonly IObjectContainer _objectContainer;

        public RefferedToSPSPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();


        #endregion

        #region Methods

        public void VerifyReferredToSPSDetails()
        { 
        
        }

        public void VerifySPSOutcome(string outcome)
        { 
        
        }

        public void ClickOnPTDNumberOfTheApplication(string ptdNumber)
        {
            var clickPTD = _driver.WaitForElement(By.XPath($"//button[contains(text(),'{ ptdNumber }')]"));
            clickPTD.Click();
        }

        #endregion

    }
}

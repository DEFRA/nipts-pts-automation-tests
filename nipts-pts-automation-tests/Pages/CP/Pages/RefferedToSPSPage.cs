using BoDi;
using nipts_pts_automation_tests.Pages.CP.Interfaces;

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

        #endregion

        #region Methods

        public void VerifyReferredToSPSDetails()
        { 
        
        }

        public void VerifySPSOutcome(string outcome)
        { 
        
        }

        #endregion

    }
}

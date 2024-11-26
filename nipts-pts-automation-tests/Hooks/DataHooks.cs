using BoDi;
using nipts_pts_API_tests.Application;
using nipts_pts_automation_tests.Configuration;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Hooks
{
    [Binding]
    public class DataHooks
    {

        private readonly IObjectContainer _objectContainer;

        public DataHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario(Order = (int)HookRunOrder.Data)]
        public void BeforeScenario()
        {
            BindAllPages();
        }

        private void BindAllPages()
        {
            // Data
            _objectContainer.RegisterInstanceAs(GetBase<ApplicationData, IApplicationData>());
        }

        private TU GetBase<T, TU>() where T : TU =>
            (TU)Activator.CreateInstance(typeof(T));

    }


}

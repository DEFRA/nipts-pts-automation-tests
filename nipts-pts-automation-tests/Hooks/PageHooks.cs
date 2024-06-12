using BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Tools;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Hooks
{
    [Binding]
    public class PageHooks
    {
        private readonly IObjectContainer _objectContainer;

        public PageHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario(Order = (int)HookRunOrder.Pages)]
        public void BeforeScenario()
        {
            BindAllPages();
        }

        private void BindAllPages()
        {            
            // Objects
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<DataHelperConnections, IDataHelperConnections>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UserObject, IUserObject>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UrlBuilder, IUrlBuilder>());

            // Pages
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInPage, ISignInPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationPage, IApplicationPage>());

        }

        private TU GetBaseWithContainer<T, TU>() where T : TU =>
        (TU)Activator.CreateInstance(typeof(T), _objectContainer);
    }
}


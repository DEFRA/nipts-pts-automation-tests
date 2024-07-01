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
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PersonalDetailsPage, IPersonalDetailsPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<FooterPage, IFooterPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<HeaderPage, IHeaderPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<FullNamePage, IFullNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PhoneNumberPage, IPhoneNumberPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PostcodeAddressPage, IPostcodeAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<MicrochipNumberPage, IMicrochipNumberPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<MicrochipDatePage, IMicrochipDatePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<EnterSpeciesPage, IEnterSpeciesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetBreedPage, IPetBreedPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetColourPage, IPetColourPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetDateOfBirthPage, IPetDateOfBirthPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetNamePage, IPetNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSexPage, IPetSexPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetFeaturesPage, IPetFeaturesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSpeciesPage, IPetSpeciesPage>());
        }

        private TU GetBaseWithContainer<T, TU>() where T : TU =>
        (TU)Activator.CreateInstance(typeof(T), _objectContainer);
    }
}


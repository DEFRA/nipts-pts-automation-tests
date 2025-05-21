using Reqnroll.BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.ApplicationDeclarationPage;
using nipts_pts_automation_tests.Pages.AP_GB.ApplicationSubmittedPage;
using nipts_pts_automation_tests.Pages.AP_GB.ChangeDetails;
using nipts_pts_automation_tests.Pages.AP_GB.GetYourPetMicrochippedPage;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.AP_GB.LandingPage;
using nipts_pts_automation_tests.Pages.AP_GB.ManageAccountPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetDOBPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipDatePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetMicrochipPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressManuallyPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerAddressPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerDetailsPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerNamePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPNumberPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetOwnerPostCodePage;
using nipts_pts_automation_tests.Pages.AP_GB.SignificantFeaturesPage;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Tools;
using Reqnroll;
using nipts_pts_automation_tests.Pages.CP.Pages;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Pages.AP_GB.PetSexPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetSpeciesPage;
using nipts_pts_automation_tests.Pages.AP_GB.LogInPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetBreedPage;
using nipts_pts_automation_tests.Pages.AP_GB.PetNamePage;
using nipts_pts_automation_tests.Pages.AP_GB.PetColourPage;

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

            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetBreedPage, IPetBreedPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetColourPage, IPetColourPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetDateOfBirthPage, IPetDateOfBirthPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetNamePage, IPetNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSexPage, IPetSexPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetFeaturesPage, IPetFeaturesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSpeciesPage, IPetSpeciesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CheckYourAnswersDeclarationPage, ICheckYourAnswersDeclarationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ManualAddressPage, IManualAddressPage>());

            //AP GB
            //_objectContainer.RegisterInstanceAs(GetBaseWithContainer<UserObject, IUserObject>());
            //_objectContainer.RegisterInstanceAs(GetBaseWithContainer<UrlBuilder, IUrlBuilder>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<LogInPage, ILogInPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<LandingPage, ILandingPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<HomePage, IHomePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GetYourPetMicrochippedPage, IGetYourPetMicrochippedPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerDetailsPage, IPetOwnerDetailsPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetMicrochipPage, IPetMicrochipPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetMicrochipDatePage, IPetMicrochipDatePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetsSpeciesPage, IPetsSpeciesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetsBreedPage, IPetsBreedPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetsNamePage, IPetsNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetsSexPage, IPetsSexPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetDOBPage, IPetDOBPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetsColourPage, IPetsColourPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignificantFeaturesPage, ISignificantFeaturesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationDeclarationPage, IApplicationDeclarationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationSubmissionPage, IApplicationSubmissionPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerNamePage, IPetOwnerNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerPostCodePage, IPetOwnerPostCodePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerAddressPage, IPetOwnerAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerPhoneNumberPage, IPetOwnerPhoneNumberPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerAddressManuallyPage, IPetOwnerAddressManuallyPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ChangeDetailsPage, IChangeDetailsPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SummaryPage, ISummaryPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ManageAccountPage, IManageAccountPage>());

            // CP Testing
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInCPPage, ISignInCPPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<RouteCheckingPage, IRouteCheckingPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<WelcomePage, IWelcomePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SearchDocumentPage, ISearchDocumentPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationSummaryPage, IApplicationSummaryPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ReportNonCompliancePage, IReportNonCompliancePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<DocumentNotFoundPage, IDocumentNotFoundPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ReferredToSPSPage, IReferredToSPSPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GBCheckReportPage, IGBCheckReportPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SearchResultsPassFailPage, ISearchResultsPassFail>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<OutagePage, IOutagePage>());

        }

        private TU GetBaseWithContainer<T, TU>() where T : TU =>
        (TU)Activator.CreateInstance(typeof(T), _objectContainer);
    }
}


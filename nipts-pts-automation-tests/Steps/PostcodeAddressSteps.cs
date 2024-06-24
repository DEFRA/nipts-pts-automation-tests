using BoDi;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class PostcodeAddressSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IPostcodeAddressPage? postcodeAddressPage => _objectContainer.IsRegistered<IPostcodeAddressPage>() ? _objectContainer.Resolve<IPostcodeAddressPage>() : null;

        public PostcodeAddressSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"enter your postcode '([^']*)'")]
        public void WhenEnterPostcode(string postcode)
        {
            postcodeAddressPage.EnterPostcode(postcode);
        }

        [When(@"select address")]
        public void WhenSelectAddress()
        {
            postcodeAddressPage.SelectAddress();
        }

        [Then(@"verify error message '([^']*)' on Pets postcode page")]
        public void ThenVerifyErrorMessageOnPetsPostcodePage(string errorMessage)
        {
            Assert.True(postcodeAddressPage.ThenVerifyErrorMessageOnPetsPostcodePage(errorMessage), "Full Name error message not matching");
        }

    }
}

using BoDi;
using nipts_pts_automation_tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps
{
    [Binding]

    public class ManualAddressSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationPage? applicationPage => _objectContainer.IsRegistered<IApplicationPage>() ? _objectContainer.Resolve<IApplicationPage>() : null;
        private IManualAddressPage? manualAddressPage => _objectContainer.IsRegistered<IManualAddressPage>() ? _objectContainer.Resolve<IManualAddressPage>() : null;

        public ManualAddressSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"click on enter address manually")]
        public void WhenClickEnterAddressManually()
        {
            manualAddressPage.ClickEnterAddressManually();
        }

        [When(@"enter address '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenEnterAddress(string Addline1, string Addline2, string city, string country, string postcode)
        {
            manualAddressPage.EnterAddress(Addline1, Addline2, city, country, postcode);
        }

        [Then(@"verify error message '([^']*)' on manual address page")]
        public void ThenVerifyErrorMessageOnManualAddressPage(string errorMessage)
        {
            Assert.True(manualAddressPage.VerifyErrorMessageOnManualAddressPage(errorMessage), "Invalid error on manual address page");
        }

    }
}

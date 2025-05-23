using BoDi;
using nipts_pts_automation_tests.Pages.AP_GB.ApplicationDeclarationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class ApplicationDeclarationPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IApplicationDeclarationPage? ApplicationDeclarationPage => _objectContainer.IsRegistered<IApplicationDeclarationPage>() ? _objectContainer.Resolve<IApplicationDeclarationPage>() : null;
        public ApplicationDeclarationPageSteps(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [Then(@"I should navigate to the '([^']*)' is loaded")]
        public void ThenIShouldNavigateToThePage(string pageTitle)
        {
            Assert.IsTrue(ApplicationDeclarationPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I should navigate to the custom '([^']*)' is loaded")]
        public void ThenIShouldNavigateToTheCustomPage(string pageTitle)
        {
            Assert.IsTrue(ApplicationDeclarationPage?.IsCustomPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I navigate to the Check your answers and sign the declaration page")]
        public void ThenINavigateToTheCheckYourAnswersAndSignTheDeclarationPage()
        {
            var pageTitle = "Check your answers and sign the declaration";
            Assert.IsTrue(ApplicationDeclarationPage?.IsNextPageLoaded(pageTitle), $"The page {pageTitle} not loaded!");
        }

        [Then(@"I have ticked the checkbox I agree to the declaration")]
        public void ThenIHaveTickedTheCheckboxIAgreeToTheDeclaration()
        {
            ApplicationDeclarationPage?.TickAgreedToDeclaration();
        }

        [When(@"I click Send Application button in Declaration page")]
        public void WhenIClickSendApplicationButtonInDeclarationPage()
        {
            ApplicationDeclarationPage?.ClickSendApplicationButton();
        }

    }
}

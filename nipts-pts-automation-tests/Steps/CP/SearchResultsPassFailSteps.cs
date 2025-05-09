using BoDi;
using nipts_pts_automation_tests.Pages;
using nipts_pts_automation_tests.Pages.AP_GB.HomePage;
using nipts_pts_automation_tests.Pages.AP_GB.SummaryPage;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using nipts_pts_automation_tests.Pages.CP.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace nipts_pts_automation_tests.Steps.CP
{
    [Binding]
    public class SearchResultsPassFailPageSteps
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private ISummaryPage? summaryPage => _objectContainer.IsRegistered<ISummaryPage>() ? _objectContainer.Resolve<ISummaryPage>() : null;
        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private ISearchResultsPassFail? _searchResultsPassFailPage => _objectContainer.IsRegistered<ISearchResultsPassFail>() ? _objectContainer.Resolve<ISearchResultsPassFail>() : null;

        public SearchResultsPassFailPageSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [Then(@"verify format of PTD number on search results page")]
        public void ThenIVerifyFormatofPTDNumber()
        {
            var ptdNumber = _scenarioContext.Get<string>("PTDNumber");
            var ptdNumber1 = ptdNumber.Substring(5);
            var ptdNumber2 = ptdNumber.Substring(0, 5);
            string ptdNumber3 = ptdNumber2.ToString();
            string ptdNumber4 = Regex.Replace(ptdNumber1, @"\w{3}", @" $0", RegexOptions.RightToLeft);
            StringBuilder sb = new StringBuilder();
            sb.Append(ptdNumber3);
            sb.Append(ptdNumber4);
            String finalPTD = sb.ToString();
            _searchResultsPassFailPage?.VerifyPTDNoOnSearchResultsPassFailPage(finalPTD);
        }

        [Then(@"verify significant features option '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifySignificantFeaturesOption(string sigFeatures)
        {
            Assert.IsTrue(_searchResultsPassFailPage?.VerifySignificantFeaturesOption(sigFeatures), $"Significant features mismatch on view results page");

        }

        [Then(@"verify Pet color option '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetColorOption(string petClr)
        {
            Assert.IsTrue(_searchResultsPassFailPage?.VerifyOtherClrOption(petClr), $"Pet Color mismatch on view results page");

        }
        [Then(@"verify Pet Breed option '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetBreedOption(string petBreed)
        {
            
            Assert.IsTrue(_searchResultsPassFailPage?.VerifyPetBreedOption(petBreed), $"Pet Breed mismatch on view results page");

        }
        [Then(@"verify Pet Name '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetNameOption(string petName)
        {

            Assert.IsTrue(_searchResultsPassFailPage?.VerifyPetNameOption(petName), $"Pet Name mismatch on view results page");

        }

        [Then(@"verify Pet Species '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetSpeciesOption(string petSpecies)
        {

            Assert.IsTrue(_searchResultsPassFailPage?.VerifyPetSpeciesOption(petSpecies), $"Pet Species mismatch on view results page");

        }

        [Then(@"verify Pet Sex '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetSexOption(string petSex)
        {

            Assert.IsTrue(_searchResultsPassFailPage?.VerifyPetSexOption(petSex), $"Pet Sex mismatch on view results page");

        }

        [Then(@"verify Pet Microchip Number '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetMicrochipNumber(string petMicrochipNumber)
        {

            Assert.IsTrue(_searchResultsPassFailPage?.VerifyPetpetMicrochipNumber(petMicrochipNumber), $"Pet Microchip Number mismatch on view results page");

        }

        [Then(@"verify Pet Microchip date '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetMicrochipDate(string petMicrochipDate)
        {

            Assert.IsTrue(_searchResultsPassFailPage?.VerifyPetpetMicrochipDate(petMicrochipDate), $"Pet Microchip date mismatch on view results page");

        }

        [Then(@"verify Pets Date Of Birth '([^']*)' on Search Pass Fail Results Page")]
        public void ThenVerifyPetsDateOfBirth(string petsDateOfBirth)
        {

            Assert.IsTrue(_searchResultsPassFailPage?.VerifypetsDateOfBirth(petsDateOfBirth), $"Pets Date Of Birth mismatch on view results page");

        }

    }
}


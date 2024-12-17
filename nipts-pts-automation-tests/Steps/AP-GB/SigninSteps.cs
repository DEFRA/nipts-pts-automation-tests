using BoDi;
using Microsoft.Azure.Amqp.Transaction;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.Data;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.AP_GB.LogInPage;
using nipts_pts_automation_tests.Tools;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class SigninSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;

        private ILogInPage? Signin => _objectContainer.IsRegistered<ILogInPage>() ? _objectContainer.Resolve<ILogInPage>() : null;
        private IUserObject? UserObject => _objectContainer.IsRegistered<IUserObject>() ? _objectContainer.Resolve<IUserObject>() : null;
        private IUrlBuilder? UrlBuilder => _objectContainer.IsRegistered<IUrlBuilder>() ? _objectContainer.Resolve<IUrlBuilder>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;

        public SigninSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Clear Database for user '([^']*)'")]
        [Given(@"Clear Database for user '([^']*)'")]
        public void ThenClearDatabase(string userType)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            //string deleteQuery = "DECLARE    @return_value int " +
            //                     "EXEC    @return_value = [dbo].[ClearPetApplicationDataByUserEmail] " +

            //                      " @userEmail = N'ptsdefra@gmail.com',@IsDelete = 1 " +
            //                      " SELECT  'Return Value' = @return_value" +
            //                      "GO" +


            //                      "SELECT* FROM User Where[Email] IN('ptsdefra@gmail.com,')" +
            //                      "SELECT* FROM Application WHere[UserId] IN(SELECT Id FROM[dbo].[User]  Where[Email] IN('ptsdefra@gmail.com')) " +
            //                      "Select COUNT(*) FROM Application ";

            //string deleteQuery = "Select COUNT(*) FROM Application ";
            //if (ConfigSetup.BaseConfiguration != null)
            //{
            //    dataHelperConnections.ExecuteQuery(connectionString, deleteQuery);
            //}
        }

        [When(@"that I navigate to the DEFRA application")]
        [Given(@"that I navigate to the DEFRA application")]
        public void GivenThatINavigateToTheDEFRAApplication()
        {
            string url = UrlBuilder.Default("App").Build();
            _driver?.Navigate().GoToUrl(url);
        }

        [Then(@"sign in with valid credentials with logininfo")]
        public void ThenSignInWithValidCredentialsWithLogininfo()
        {
            var user = UserObject?.GetUser("AP-GB");
            _objectContainer.RegisterInstanceAs(user);
            Assert.True(Signin?.IsSignedIn(user?.UserId, user?.password), "Not able to sign in");
        }

        [When(@"click on signout button and verify the signout message on pets")]
        [Then(@"click on signout button and verify the signout message on pets")]
        public void ThenClickOnSignoutButtonAndVerifyTheSignoutMessage()
        {
            Assert.True(Signin?.IsSignedOut(), "Not able to sign out");
        }

    }
}

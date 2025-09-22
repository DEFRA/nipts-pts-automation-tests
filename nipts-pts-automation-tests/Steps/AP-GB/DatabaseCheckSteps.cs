using Reqnroll.BoDi;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;
using Reqnroll;

namespace nipts_pts_automation_tests.Steps.AP_GB
{
    [Binding]
    public class DatabaseCheckSteps
    {
        private readonly object _lock = new object();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver? _driver => _objectContainer.IsRegistered<IWebDriver>() ? _objectContainer.Resolve<IWebDriver>() : null;
        private IDataHelperConnections? dataHelperConnections => _objectContainer.IsRegistered<IDataHelperConnections>() ? _objectContainer.Resolve<IDataHelperConnections>() : null;

        public DatabaseCheckSteps(ScenarioContext context, IObjectContainer container)
        {
            _scenarioContext = context;
            _objectContainer = container;
        }

        [When(@"Clear Database for user '([^']*)'")]
        [Given(@"Clear Database for user '([^']*)'")]
        public void ThenClearDatabase(string userType)
        {
            string connectionString = ConfigSetup.BaseConfiguration.AppConnectionString.DBConnectionstring;

            string deleteQuery = "DECLARE @return_value int " +
                                 "EXEC @return_value = [dbo].[ClearPetApplicationDataByUserEmail] " +
                                 "@userEmail = N'ptsdefra@gmail.com',@IsDelete = 1 " +
                                 "SELECT  'Return Value' = @return_value";

            if (ConfigSetup.BaseConfiguration != null)
            {
                string SQLOutput =  dataHelperConnections.ExecuteQuery(connectionString, deleteQuery);
            }
        }

        //[Then(@"sign in with valid credentials with logininfo")]
        //public void ThenSignInWithValidCredentialsWithLogininfo()
        //{
        //    var user = UserObject?.GetUser("AP-GB");
        //    _objectContainer.RegisterInstanceAs(user);
        //    Assert.True(Signin?.IsSignedIn(user?.UserId, user?.password), "Not able to sign in");
        //}
    }
}

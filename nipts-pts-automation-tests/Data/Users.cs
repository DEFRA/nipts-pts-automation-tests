using BoDi;
using Microsoft.Extensions.Configuration;
using nipts_pts_automation_tests.Configuration;
using System.Reflection;


namespace nipts_pts_automation_tests.Data
{
    public class User
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public string OrgID { get; set; }
        public string LoginInfo { get; set; }
        public string Environment { get; set; }
        public bool HomePage { get; set; }

    }
    public interface IUserObject
    {
        public User GetUser(string info);
    }

    public class UserObject : IUserObject
    {
        private IObjectContainer _objectContainer;

        public UserObject(IObjectContainer objectContainer) => _objectContainer = objectContainer;
        private readonly object _lock = new object();
        private User User = null;

        public User GetUser(string info)
        {
            lock (_lock)
            {
                string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(jsonPath, "Data", "Users", "Users.json");

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var usersList = settings.GetSection("Users").Get<List<User>>();
                string environment = ConfigSetup.BaseConfiguration.TestConfiguration.ComPortalUrl;

                var filterList = environment.ToLower().Contains("sign-up", StringComparison.CurrentCultureIgnoreCase)
                    ? usersList.FindAll(d => d.LoginInfo.Equals(info) && d.Environment.ToLower().Contains("test"))
                    : usersList.FindAll(d => d.LoginInfo.Equals(info) && d.Environment.ToLower().Contains(environment));

                Random rng = new Random();
                User = filterList[rng.Next(filterList.Count)];

            }
            return User;
        }
    }


}

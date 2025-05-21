using Reqnroll.BoDi;
using Microsoft.Extensions.Configuration;
using nipts_pts_automation_tests.Configuration;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;


namespace nipts_pts_automation_tests.Data
{
    public class User
    {
        public string UserId { get; set; }
        public string password { get; set; }
        public string LoginInfo { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Useraddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string Environment { get; set; }
        public bool HomePage { get; set; }
    }
    public interface IUserObject
    {
        public User GetUser(string application);
        public User GetUserById(string info);
        public User GetUser(string application,string userType);
    }

    public class UserObject : IUserObject
    {
        private IObjectContainer _objectContainer;

        public UserObject(IObjectContainer objectContainer) => _objectContainer = objectContainer;
        private readonly object _lock = new object();
        private User User = null;

        public User GetUser(string application)
        {
            lock (_lock)
            {
                string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(jsonPath, "Data", application.ToUpper(), "Users.json");

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var usersList = settings.GetSection("Users").Get<List<User>>();

                Random rng = new Random();
                User = usersList[rng.Next(usersList.Count)];

            }
            return User;
        }

        public User GetUserById(string info)
        {
            lock (_lock)
            {
                string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(jsonPath, "Data", "Users.json");

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var usersList = settings.GetSection("Users").Get<List<User>>();
                var filterList = usersList.FindAll(d => d.LoginInfo.Equals(info));
                Random rng = new Random();
                User = filterList[rng.Next(filterList.Count)];

            }
            return User;
        }

        public User GetUser(string application,string userType)
        {
            lock (_lock)
            {
                string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(jsonPath, "Data", application.ToUpper(), "Users.json");

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var usersList = settings.GetSection("Users").Get<List<User>>();
                var filterList = usersList.FindAll(d => d.LoginInfo.Equals(userType));
                Random rng = new Random();
                User = filterList[rng.Next(filterList.Count)];
            }
            return User;
        }



    }


}

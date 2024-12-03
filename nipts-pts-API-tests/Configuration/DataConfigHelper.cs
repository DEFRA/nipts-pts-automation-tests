using System.Collections.Specialized;
using System.Reflection;

namespace nipts_pts_API_tests.Configuration
{
    public static class DataConfigHelper
    {
        public static T LoadTestConfiguration<T>(NameValueCollection applicationSettings, Dictionary<string, string> testParameters, T configuration)
        {
            if (applicationSettings.Count == 0)
                throw new Exception("Application Settings are not defined");

            var properties = typeof(T).GetPublicProperties();

            foreach (var property in properties)
            {
                try
                {
                    string propValue = string.Empty;
                    string logMessage = string.Empty;
                    if (testParameters.ContainsKey(property.Name))
                    {
                        propValue = testParameters[property.Name];
                        logMessage =
                            $@"Parameter '{property.Name}' was passed from Nunit console runner. Value: '{propValue}'";
                    }

                    else if (applicationSettings.AllKeys.Any(k => k == property.Name))
                    {
                        propValue = applicationSettings[property.Name];
                        logMessage =
                            $@"Parameter '{property.Name}' obtained from app.config file. Value: '{propValue}'";
                    }


                    if (!string.IsNullOrEmpty(propValue))
                    {
                        Console.WriteLine(logMessage);
                        var value = property.PropertyType.IsEnum
                            ? Enum.Parse(property.PropertyType, propValue)
                            : Convert.ChangeType(propValue, property.PropertyType);

                        property.SetValue(configuration, value);
                    }
                    else
                    {
                        Console.WriteLine($@"No value provided for configuration parameter {property.Name}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        $@"An error occured when setting up Configuration, property name {property.Name} -> {e.Message}");
                    throw;
                }


            }
            return configuration;
        }

        private static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            if (!type.IsInterface)
                return type.GetProperties();

            return (new Type[] { type })
                .Concat(type.GetInterfaces())
                .SelectMany(i => i.GetProperties());
        }
    }

}

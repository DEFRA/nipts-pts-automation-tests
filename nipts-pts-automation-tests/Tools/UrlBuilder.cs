
using BoDi;
using pets_com_automation_tests.Configuration;

namespace pets_com_automation_tests.Tools
{
    public interface IUrlBuilder
    {
        public UrlBuilder Default();
        public string Build();
        public UrlBuilder Add(string segment);


    }
    public class UrlBuilder : IUrlBuilder
    {
        private IObjectContainer _objectContainer;
        public UrlBuilder(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            segments = new List<string>();
        }
        private IList<string> segments;
        private bool hasTrailingSlash;
        private string BaseUrl = null;
        public UrlBuilder Add(string segment)
        {
            if (segment == null)
                throw new ArgumentNullException("segment");

            var cleanSegment = CleanSegment(segment);
            if (!string.IsNullOrEmpty(cleanSegment))
            {
                segments.Add(cleanSegment);
            }

            hasTrailingSlash = segment.EndsWith("/");

            return this;
        }

        public string Build()
        {
            string path = null;
            if (segments.Count > 0)
            {
                path = string.Join("/", segments);

                if (segments.Count > 0 && hasTrailingSlash)
                {
                    path += "/";
                }
                path = BaseUrl + "/" + path;
            }
            else
            {
                path = BaseUrl;
            }
            return path;
        }

        public UrlBuilder Default()
        {
            BaseUrl = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;
            return this;
        }

        private static string CleanSegment(string segment)
        {
            var unescaped = Uri.UnescapeDataString(segment);
            return Uri.EscapeUriString(unescaped).Replace("?", "%3F").Trim().TrimStart('/').TrimEnd('/');
        }
    }
}

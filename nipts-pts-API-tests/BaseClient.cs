using BoDi;
using nipts_pts_API_tests.Configuration;
using System.Reflection;
using RestSharp;

namespace nipts_pts_API_tests
{
    public class BaseClient
    {
        private RestClient client;
        private RestRequest request;
        private IObjectContainer _objectContainer;

        protected string RequestFolder { get; set; }

        private string ApiEndpoint { get; set; }

        public BaseClient()
        {
            string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            RequestFolder = Path.Combine(jsonPath, "RequestJson");
        }

        public RestClient SetUrl(string endpoint)
        {
            ApiEndpoint = DataSetupConfig.Configuration.ApiEndPoint;
            var url = Path.Combine(ApiEndpoint, endpoint);
            client = new RestClient(url);
            return client;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-api-version", "1");

            return request;
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-api-version", "1");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePutRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Put
            };
            request.AddHeader("accept", "application/json");
            request.AddHeader("x-api-version", "1");

            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreateDeleteRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Delete
            };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-api-version", "1");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }
    }

}

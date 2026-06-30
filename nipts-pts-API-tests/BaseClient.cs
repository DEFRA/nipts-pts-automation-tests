using Reqnroll.BoDi;
using System.Reflection;
using Newtonsoft.Json;
using nipts_pts_API_tests.Configuration;
using RestSharp;

namespace nipts_pts_API_tests
{
    public class BaseClient
    {
        private RestClient client;
        private RestRequest request;
        private IObjectContainer _objectContainer;
        private string _subscriptionKey;
        private bool _isCheckerEndpoint;

        protected string RequestFolder { get; set; }

        //private string ApiEndpoint { get; set; }

        public BaseClient()
        {
            string jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            RequestFolder = Path.Combine(jsonPath, "RequestJson");
        }

        public (RestClient Client, string Url) SetUrlWithInfo(string endpoint, string ApiEndpoint)
        {
            var baseUrl = ApiEndpoint?.TrimEnd('/') ?? string.Empty;
            var url = $"{baseUrl}/{endpoint}";
            client = new RestClient(url);
            _isCheckerEndpoint = IsCheckerEndpoint(ApiEndpoint);
            _subscriptionKey = ResolveSubscriptionKey(ApiEndpoint);
            return (client, url);
        }

        public RestClient SetUrl(string endpoint, string ApiEndpoint)
        {
            var (restClient, _) = SetUrlWithInfo(endpoint, ApiEndpoint);
            return restClient;
        }

        private static string ResolveSubscriptionKey(string ApiEndpoint)
        {
            return IsCheckerEndpoint(ApiEndpoint)
                ? DataSetupConfig.Configuration.CheckerSubscriptionKey
                : DataSetupConfig.Configuration.CommonSubscriptionKey;
        }

        private static bool IsCheckerEndpoint(string ApiEndpoint)
        {
            var checkerEndpoint = DataSetupConfig.Configuration.ApiEndPoint5;
            return string.Equals(ApiEndpoint?.TrimEnd('/'), checkerEndpoint?.TrimEnd('/'), StringComparison.OrdinalIgnoreCase);
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
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-version", "1");
            request.AddStringBody(payload as string ?? JsonConvert.SerializeObject(payload), ContentType.Json);
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
            if (!string.IsNullOrEmpty(_subscriptionKey))
                restRequest.AddOrUpdateHeader("Ocp-Apim-Subscription-Key", _subscriptionKey);

            // The pts-pet-checker (CP) API only trusts a CP-audience token; everything else uses
            // the applicant/backend token. Fall back to the backend token if no CP token is set.
            var bearerToken = _isCheckerEndpoint && !string.IsNullOrEmpty(DataSetupConfig.Configuration.CheckerBearerToken)
                ? DataSetupConfig.Configuration.CheckerBearerToken
                : DataSetupConfig.Configuration.BearerToken;
            if (!string.IsNullOrEmpty(bearerToken))
                restRequest.AddOrUpdateHeader("Authorization", $"Bearer {bearerToken}");

            var response = await restClient.ExecuteAsync(restRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("=== 401 UNAUTHORIZED DIAGNOSTICS ===");
                Console.WriteLine($"Request URL:          {response.ResponseUri}");
                Console.WriteLine($"Subscription key set: {!string.IsNullOrEmpty(_subscriptionKey)}");
                Console.WriteLine($"Bearer token present: {!string.IsNullOrEmpty(bearerToken)} (length: {bearerToken?.Length ?? 0})");
                var wwwAuth = response.Headers?.FirstOrDefault(h => string.Equals(h.Name, "WWW-Authenticate", StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"WWW-Authenticate:     {wwwAuth?.Value}");
                Console.WriteLine($"Response body:        {response.Content}");
                Console.WriteLine("====================================");
            }

            return response;
        }

        /// <summary>
        /// Dumps the full request/response detail for diagnosing failures (especially opaque 5xx
        /// responses that come back with an empty body through APIM). Captures the numeric status,
        /// RestSharp transport status (to tell an HTTP error from the server apart from a transport
        /// failure), every request and response header (auth/subscription values redacted), the
        /// payload, and any APIM trace location returned for <c>Ocp-Apim-Trace</c> requests.
        /// </summary>
        protected static void LogResponseDiagnostics(string label, string requestUrl, RestRequest request, RestResponse response, string requestPayload)
        {
            Console.WriteLine($"=== {label} DIAGNOSTICS ===");
            Console.WriteLine($"Request URL:          {requestUrl}");
            Console.WriteLine($"Request method:       {request.Method}");
            Console.WriteLine($"Request payload:      {requestPayload}");
            Console.WriteLine("-- Request headers --");
            foreach (var p in request.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
                Console.WriteLine($"   {p.Name}: {Redact(p.Name, p.Value?.ToString())}");

            Console.WriteLine("-- Response --");
            Console.WriteLine($"Status code:          {(int)response.StatusCode} ({response.StatusCode})");
            Console.WriteLine($"Status description:    {response.StatusDescription}");
            Console.WriteLine($"Transport status:      {response.ResponseStatus}");
            Console.WriteLine($"Is successful:         {response.IsSuccessful}");
            Console.WriteLine($"Response URI:          {response.ResponseUri}");
            Console.WriteLine($"Content type:          {response.ContentType}");
            Console.WriteLine($"Content length:        {response.ContentLength?.ToString() ?? "(null)"}");
            Console.WriteLine($"Content (raw):         {(string.IsNullOrEmpty(response.Content) ? "(empty)" : response.Content)}");
            Console.WriteLine($"Error message:         {response.ErrorMessage ?? "(none)"}");
            Console.WriteLine($"Error exception:       {FormatException(response.ErrorException)}");

            Console.WriteLine("-- Response headers --");
            if (response.Headers is { Count: > 0 })
                foreach (var h in response.Headers)
                    Console.WriteLine($"   {h.Name}: {h.Value}");
            else
                Console.WriteLine("   (none)");

            if (response.ContentHeaders is { Count: > 0 })
            {
                Console.WriteLine("-- Content headers --");
                foreach (var h in response.ContentHeaders)
                    Console.WriteLine($"   {h.Name}: {h.Value}");
            }

            var traceLocation = response.Headers?
                .FirstOrDefault(h => string.Equals(h.Name, "Ocp-Apim-Trace-Location", StringComparison.OrdinalIgnoreCase));
            if (traceLocation != null)
                Console.WriteLine($"APIM trace location:  {traceLocation.Value}  <-- open this URL for the full gateway+backend trace of this 500");

            Console.WriteLine(new string('=', label.Length + 18));
        }

        private static string Redact(string name, string value)
        {
            if (string.IsNullOrEmpty(value))
                return "(empty)";
            var sensitive = name != null && (
                name.Contains("Authorization", StringComparison.OrdinalIgnoreCase) ||
                name.Contains("Subscription-Key", StringComparison.OrdinalIgnoreCase));
            return sensitive ? $"***REDACTED*** (length {value.Length})" : value;
        }

        private static string FormatException(Exception ex)
        {
            if (ex == null)
                return "(none)";
            var messages = new List<string>();
            for (var current = ex; current != null; current = current.InnerException)
                messages.Add($"{current.GetType().Name}: {current.Message}");
            return string.Join(" -> ", messages);
        }

        /// <summary>
        /// Attaches a client-generated W3C <c>traceparent</c> (plus the legacy <c>Request-Id</c> and
        /// <c>x-correlation-id</c>) to the request and returns the trace id. The backend services are
        /// Application Insights instrumented, so when they record the (failed) request they use this
        /// id as the operation's trace id. Logging the same id here lets the platform team find the
        /// exact server-side exception for a bare 500 with an empty body, instead of guessing by
        /// timestamp. The sampled flag (-01) ensures the trace is retained.
        /// </summary>
        protected static string AttachCorrelationId(RestRequest request)
        {
            var traceId = (Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N")).Substring(0, 32);
            var spanId = Guid.NewGuid().ToString("N").Substring(0, 16);

            request.AddOrUpdateHeader("traceparent", $"00-{traceId}-{spanId}-01");
            request.AddOrUpdateHeader("Request-Id", $"|{traceId}.{spanId}.");
            request.AddOrUpdateHeader("x-correlation-id", traceId);
            return traceId;
        }
    }

}

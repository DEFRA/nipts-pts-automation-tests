using Newtonsoft.Json;
using RestSharp;

namespace nipts_pts_API_tests.Application
{
    public class ApplicationData : BaseClient, IApplicationData
    {

        private readonly object _lock = new object();
        public string ApplicationId { get; set; }
        public string PTDNumber { get; set; }


        public void GetApplicationToApprove()
        {
            Task<RestResponse> response = GetApplication();
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            ApproveApplication(ApplicationId);
            Task<RestResponse> response2 = GetApplication();
            var responseString2 = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2.ToString())!;
            PTDNumber = dynamicObject2.travelDocument.travelDocumentReferenceNumber;
        }

        public void ApproveApplication(string ApplicationId)
        {
            ServiceBusConnection.SendMessageToQueue(ApplicationId);
        }

        public Task<RestResponse> GetApplication()
        {
            Task<RestResponse> response = null;
            lock (_lock)
            {
                var client = SetUrl("api/Checker/checkApplicationNumber");
                var file = Path.Combine(RequestFolder, "ApplRequest.json");
                var requestJson = File.ReadAllText(file);
                var request = CreatePostRequest(requestJson);
                response = GetResponseAsync(client, request);
            }
            return response;
        }
    }

}

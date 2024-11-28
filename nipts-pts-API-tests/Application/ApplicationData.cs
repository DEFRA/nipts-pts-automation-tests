using Newtonsoft.Json;
using RestSharp;

namespace nipts_pts_API_tests.Application
{
    public class ApplicationData : BaseClient, IApplicationData
    {

        private readonly object _lock = new object();
        public string ApplicationId { get; set; }
        public string PTDNumber { get; set; }


        public void GetApplicationToApprove(string AppReference)
        {
            Task<RestResponse> response = GetApplication(AppReference);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            ApproveApplication(ApplicationId);
            Task<RestResponse> response2 = GetApplication(AppReference);
            var responseString2 = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2.ToString())!;
            PTDNumber = dynamicObject2.travelDocument.travelDocumentReferenceNumber;
        }

        public void ApproveApplication(string ApplicationId)
        {
            ServiceBusConnection.SendMessageToQueue(ApplicationId, "Authorised");
        }


        public void GetApplicationToReject(string AppReference)
        {
            Task<RestResponse> response = GetApplication(AppReference);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            RejectApplication(ApplicationId);
            Task<RestResponse> response2 = GetApplication(AppReference);
            var responseString2 = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2.ToString())!;
            PTDNumber = dynamicObject2.travelDocument.travelDocumentReferenceNumber;
        }


        public void RejectApplication(string ApplicationId)
        {
            ServiceBusConnection.SendMessageToQueue(ApplicationId, "Rejected");
        }

        public void GetApplicationToRevoke(string AppReference)
        {
            Task<RestResponse> response = GetApplication(AppReference);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            RevokeApplication(ApplicationId);
            Task<RestResponse> response2 = GetApplication(AppReference);
            var responseString2 = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2.ToString())!;
            PTDNumber = dynamicObject2.travelDocument.travelDocumentReferenceNumber;
        }

        public void RevokeApplication(string ApplicationId)
        {
            ServiceBusConnection.SendMessageToQueue(ApplicationId, "Revoked");
        }

        public Task<RestResponse> GetApplication(string AppReference)
        {
            Task<RestResponse> response = null;
            lock (_lock)
            {
                var client = SetUrl("api/Checker/checkApplicationNumber");
                var file = Path.Combine(RequestFolder, "ApplRequest.json");
                var requestJson = File.ReadAllText(file);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
                dynamicObject.applicationNumber = AppReference;
                var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
                response = GetResponseAsync(client, request);
            }
            return response;
        }
    }

}

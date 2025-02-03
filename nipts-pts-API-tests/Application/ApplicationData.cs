using Newtonsoft.Json;
using nipts_pts_API_tests.Configuration;
using RestSharp;

namespace nipts_pts_API_tests.Application
{
    public class ApplicationData : BaseClient, IApplicationData
    {

        private readonly object _lock = new object();
        public string ApplicationId { get; set; }
        public string PTDNumber { get; set; }
        public string UserId { get; set; }
        public string OwnerId { get; set; }
        public string AddressId { get; set; }
        public string PetId { get; set; }
        public string QueueId { get; set; }
        public string AppReferenceNumber { get; set; }
        public string PetSpecies { get; set; }
        public string MicrochipNo { get; set; }




        public string GetApplicationToApprove(string AppReference)
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
            return PTDNumber;
        }

        public void ApproveApplication(string ApplicationId)
        {
            ServiceBusConnection.SendMessageToQueue(ApplicationId, "Authorised");
        }
        public string CreateApplicationSigFNoAPI(string AppId)
        {
            updateUser();
            createOwner();
            createAddress();
            createPetSigFNo();
            return createApplication(AppId);
        }


        public void createPetSigFNo()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint2;
            var client = SetUrl("createpet", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreatePetSigFNo.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            PetId = dynamicObject;
        }



        public string GetApplicationToReject(string AppReference)
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
            return PTDNumber;
        }


        public void RejectApplication(string ApplicationId)
        {
            ServiceBusConnection.SendMessageToQueue(ApplicationId, "Rejected");
        }

        public string GetApplicationToRevoke(string AppReference)
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
            return PTDNumber;
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
                string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint5;
                var client = SetUrl("api/Checker/checkApplicationNumber", APIEndPoint);
                var file = Path.Combine(RequestFolder, "ApplRequest.json");
                var requestJson = File.ReadAllText(file);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
                dynamicObject.applicationNumber = AppReference;
                var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
                response = GetResponseAsync(client, request);
            }
            return response;
        }

        public string CreateApplicationAPI(string AppId)
        {
            updateUser();
            createOwner();
            createAddress();
            createPet();
            return createApplication(AppId);
        }

        public void updateUser()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint3;
            var client = SetUrl("updateuser", APIEndPoint);
            var file = Path.Combine(RequestFolder, "UpdateUser.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            UserId = dynamicObject2;
        }

        public void createOwner()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint3;
            var client = SetUrl("createowner", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateOwner.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            OwnerId = dynamicObject;
        }

        public void createAddress()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint3;
            var client = SetUrl("createaddress", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateAddress.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            AddressId = dynamicObject;
        }

        public void createPet()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint2;
            var client = SetUrl("createpet", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreatePet.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            PetId = dynamicObject;
        }

        public string createApplication(string AppId)
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint1;
            var client = SetUrl("application", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateApplication.json");
            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            dynamicObject.id = AppId;
            dynamicObject.petId = PetId;
            dynamicObject.userId = UserId;
            dynamicObject.ownerId = OwnerId;
            dynamicObject.ownerAddressId = AddressId;
            var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            QueueId = dynamicObject2.id;
            AppReferenceNumber = dynamicObject2.referenceNumber;
            return AppReferenceNumber;
        }

        public bool writeApplicationToQueue()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint4;
            var client = SetUrl("writetoqueue", APIEndPoint);
            var file = Path.Combine(RequestFolder, "ApplicationToQueue.json");
            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            dynamicObject.applicationId = QueueId;
            var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            if (responseString.Contains("Added Message to Queue Successfully"))
                return true;
            else
                return false;
        }
        public string GetPetDetails(string AppReference)
        {

            Task<RestResponse> response = GetApplication(AppReference);
            var responseString2 = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2.ToString())!;
            PetSpecies = dynamicObject2.pet.species;
            return PetSpecies;

        }
        public string GetMicrochipDetails(string AppReference)
        {
            Task<RestResponse> response = GetApplication(AppReference);
            var responseString2 = response.Result.Content.ToString();
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2.ToString())!;
            MicrochipNo = dynamicObject2.pet.microchipNumber;
            return MicrochipNo;
        }

    }
}

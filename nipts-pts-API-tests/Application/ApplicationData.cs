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

        public void GetSuspendedApplicationToApprove(string PTDNumber)
        {
            Task<RestResponse> response = GetApprovedApplication(PTDNumber);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            ApproveApplication(ApplicationId);
        }

        public void ApproveApplication(string ApplicationId)
        {
            string queueName = ServiceBusConnectionData.Configuration.ServiceBusQueueName;
            DateTime dateTime = DateTime.Now;
            string TodaysDate = dateTime.ToString("yyyy-MM-dd");

            // Create a unique DynamicId for each message
            string dynamicId = Guid.NewGuid().ToString();

            string messageBody = $"{{ \"Application.Id \": \"{ApplicationId}\", \"Application.DynamicId\": \"{dynamicId}\", \"Application.StatusId\": \"Authorised\", \"Application.DateAuthorised\": \"{TodaysDate}\" }}";

            ServiceBusConnection.SendMessageToQueue(messageBody, queueName);
        }

        public void GetAwaitingApplicationToSuspend(string AppReference)
        {
            Task<RestResponse> response = GetApplication(AppReference);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            SuspendApplication(ApplicationId);
        }

        public void GetAuthorisedApplicationToSuspend(string PTDNumber)
        {
            Task<RestResponse> response = GetApprovedApplication(PTDNumber);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            SuspendApplication(ApplicationId);
        }

        public void SuspendApplication(string ApplicationId)
        {
            string queueName = ServiceBusConnectionData.Configuration.ServiceBusQueueName;
            DateTime dateTime = DateTime.Now;
            string TodaysDate = dateTime.ToString("yyyy-MM-dd");

            // Create a unique DynamicId for each message
            string dynamicId = Guid.NewGuid().ToString();

            string messageBody = $"{{ \"Application.Id \": \"{ApplicationId}\", \"Application.DynamicId\": \"{dynamicId}\", \"Application.StatusId\": \"Suspended\", \"Application.DateAuthorised\": \"{TodaysDate}\" }}";

            ServiceBusConnection.SendMessageToQueue(messageBody, queueName);
        }


        public string CreateApplicationWithPetCustomValues(string AppId, string PetSpecies)
        {
            updateUser();
            createOwner();
            createAddress();
            createPetWithCustomValues(PetSpecies);
            return createApplication(AppId);
        }

        public void createPetWithCustomValues(string PetSpecies)
        {
            var file = "";
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint2;
            var client = SetUrl("createpet", APIEndPoint);

            if (PetSpecies.Equals("Cat"))
                file = Path.Combine(RequestFolder, "CreatePetwithCustomValuesCat.json");
            else if (PetSpecies.Equals("Dog"))
                file = Path.Combine(RequestFolder, "CreatePetwithCustomValuesDog.json");
            else if (PetSpecies.Equals("Ferret"))
                file = Path.Combine(RequestFolder, "CreatePetwithCustomValuesFerret.json");

            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            PetId = dynamicObject;
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
            string queueName = ServiceBusConnectionData.Configuration.ServiceBusQueueName;
            DateTime dateTime = DateTime.Now;
            string TodaysDate = dateTime.ToString("yyyy-MM-dd");

            // Create a unique DynamicId for each message
            string dynamicId = Guid.NewGuid().ToString();

            string messageBody = $"{{ \"Application.Id \": \"{ApplicationId}\", \"Application.DynamicId\": \"{dynamicId}\", \"Application.StatusId\": \"Rejected\", \"Application.DateAuthorised\": \"{TodaysDate}\" }}";
            ServiceBusConnection.SendMessageToQueue(messageBody, queueName);
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
            string queueName = ServiceBusConnectionData.Configuration.ServiceBusQueueName;
            DateTime dateTime = DateTime.Now;
            string TodaysDate = dateTime.ToString("yyyy-MM-dd");

            // Create a unique DynamicId for each message
            string dynamicId = Guid.NewGuid().ToString();

            string messageBody = $"{{ \"Application.Id \": \"{ApplicationId}\", \"Application.DynamicId\": \"{dynamicId}\", \"Application.StatusId\": \"Revoked\", \"Application.DateAuthorised\": \"{TodaysDate}\" }}";

            ServiceBusConnection.SendMessageToQueue(messageBody, queueName);
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

        public void RevokeApprovedApplication(string PTDNumber)
        {
            Task<RestResponse> response = GetApprovedApplication(PTDNumber);
            var responseString = response.Result.Content.ToString();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString.ToString())!;
            ApplicationId = dynamicObject.application.applicationId;
            RevokeApplication(ApplicationId);
        }

        public Task<RestResponse> GetApprovedApplication(string PTDNumber)
        {
            Task<RestResponse> response = null;
            lock (_lock)
            {
                string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint5;
                var client = SetUrl("api/Checker/checkPTDNumber", APIEndPoint);
                var file = Path.Combine(RequestFolder, "CheckPTDNumber.json");
                var requestJson = File.ReadAllText(file);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
                dynamicObject.ptdNumber = PTDNumber;
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
        public string CreateApplicationAPIWithOtherColour(string AppId)
        {
            updateUser();
            createOwner();
            createAddress();
            createPetWithOtherColour();
            return createApplication(AppId);
        }

        public string CreateApplicationWithMandatoryAddressFieldsAPI(string AppId)
        {
            updateUser();
            createOwner();
            createAddressWithMandatoryFieldsOnly();
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

        public void createAddressWithMandatoryFieldsOnly()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint3;
            var client = SetUrl("createaddress", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateAddressMandatoryOnly.json");
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

        public void createPetWithOtherColour()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint2;
            var client = SetUrl("createpet", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreatePerOtherColour.json");
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


        public string writeOfflineApplicationToQueue(string randonNumber,string Species)
        {
            string queueName = ServiceBusConnectionData.Configuration.ServiceBusOfflineApplQueueName;
            var file = "";
            
            if(Species.Equals("Cat"))
                file = Path.Combine(RequestFolder, "CreateOfflineApplicationCat.json");
            else if (Species.Equals("Dog"))
                file = Path.Combine(RequestFolder, "CreateOfflineApplicationDog.json");
            else if (Species.Equals("Ferret"))
                file = Path.Combine(RequestFolder, "CreateOfflineApplicationFerret.json");

            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            dynamicObject.Application.ReferenceNumber = getUniqueRerefenceNumber(randonNumber);
            dynamicObject.PTD.DocumentReferenceNumber = getUniquePTDNumber(randonNumber);
            dynamicObject.Owner.Email = getUniqueEmailId(randonNumber);
            ServiceBusConnection.SendMessageToQueue(JsonConvert.SerializeObject(dynamicObject), queueName);
            return getUniquePTDNumber(randonNumber);
        }

        public string getUniqueRerefenceNumber(string randonNumber)
        {
            string newRerefenceNumber = "GB826AD" + randonNumber;
            return newRerefenceNumber;
        }

        public string getUniquePTDNumber(string randonNumber)
        {
            string newPTDNumber = "GB826AD" + randonNumber;
            return newPTDNumber;
        }

        public string getUniqueEmailId(string randonNumber)
        {
            string newEmail = "themask" + "+" + randonNumber + "@smokin.green";
            return newEmail;
        }
    }
}

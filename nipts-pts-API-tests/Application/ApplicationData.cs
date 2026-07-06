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
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            Console.WriteLine("=== GET APPLICATION TO APPROVE ===");
            Console.WriteLine($"AppReference: {AppReference}");
            Console.WriteLine($"Status: {restResponse.StatusCode}");
            Console.WriteLine($"Response: {responseString}");
            Console.WriteLine("==================================");

            if (!restResponse.IsSuccessful || string.IsNullOrWhiteSpace(responseString))
                throw new Exception($"GetApplicationToApprove: Failed to get application. AppReference: {AppReference}, Status: {restResponse.StatusCode}, Response: {responseString}");

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject == null)
                throw new Exception($"GetApplicationToApprove: Failed to deserialize response. AppReference: {AppReference}, Response: {responseString}");

            if (dynamicObject.application == null)
                throw new Exception($"GetApplicationToApprove: 'application' is null in response. AppReference: {AppReference}, Response: {responseString}");

            ApplicationId = dynamicObject.application.applicationId?.ToString()
                ?? throw new Exception($"GetApplicationToApprove: 'applicationId' is null. AppReference: {AppReference}, Response: {responseString}");

            ApproveApplication(ApplicationId);
            Task<RestResponse> response2 = GetApplication(AppReference);
            var responseString2 = response2.Result.Content ?? string.Empty;
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2);
            if (dynamicObject2?.travelDocument?.travelDocumentReferenceNumber == null)
                throw new Exception($"GetApplicationToApprove: 'travelDocumentReferenceNumber' is null after approval. AppReference: {AppReference}, Response: {responseString2}");

            PTDNumber = dynamicObject2.travelDocument.travelDocumentReferenceNumber?.ToString();
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
            var (client, requestUrl) = SetUrlWithInfo("createpet", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreatePetSigFNo.json");
            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            string uniqueMicrochip = DateTime.Now.ToString("ddMMyyHHmmssfff");
            dynamicObject.petIdentification.microchipNumber = uniqueMicrochip;
            dynamicObject.petMicrochip.microchipNumber = uniqueMicrochip;
            var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            if (!restResponse.IsSuccessful)
                throw new Exception($"createPetSigFNo: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}");

            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject2 == null)
                throw new Exception($"createPetSigFNo: Failed to deserialize response. URL: {requestUrl}, Response: {responseString}");
            PetId = dynamicObject2;
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
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            Console.WriteLine("=== GET APPLICATION TO REVOKE ===");
            Console.WriteLine($"AppReference: {AppReference}");
            Console.WriteLine($"Status: {restResponse.StatusCode}");
            Console.WriteLine($"Response: {responseString}");
            Console.WriteLine("=================================");

            if (!restResponse.IsSuccessful || string.IsNullOrWhiteSpace(responseString))
                throw new Exception($"GetApplicationToRevoke: Failed to get application. AppReference: {AppReference}, Status: {restResponse.StatusCode}, Response: {responseString}");

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject == null)
                throw new Exception($"GetApplicationToRevoke: Failed to deserialize response. AppReference: {AppReference}, Response: {responseString}");

            if (dynamicObject.application == null)
                throw new Exception($"GetApplicationToRevoke: 'application' is null in response. AppReference: {AppReference}, Response: {responseString}");

            ApplicationId = dynamicObject.application.applicationId?.ToString()
                ?? throw new Exception($"GetApplicationToRevoke: 'applicationId' is null. AppReference: {AppReference}, Response: {responseString}");

            RevokeApplication(ApplicationId);
            Task<RestResponse> response2 = GetApplication(AppReference);
            var responseString2 = response2.Result.Content ?? string.Empty;
            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString2);
            if (dynamicObject2?.travelDocument?.travelDocumentReferenceNumber == null)
                throw new Exception($"GetApplicationToRevoke: 'travelDocumentReferenceNumber' is null after revoke. AppReference: {AppReference}, Response: {responseString2}");

            PTDNumber = dynamicObject2.travelDocument.travelDocumentReferenceNumber?.ToString();
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
            var (client, requestUrl) = SetUrlWithInfo("updateuser", APIEndPoint);
            var file = Path.Combine(RequestFolder, "UpdateUser.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            if (!restResponse.IsSuccessful)
                throw new Exception($"updateUser: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}");

            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject2 == null)
                throw new Exception($"updateUser: Failed to deserialize response. URL: {requestUrl}, Response: {responseString}");
            UserId = dynamicObject2;
        }

        public void createOwner()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint3;
            var (client, requestUrl) = SetUrlWithInfo("createowner", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateOwner.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            if (!restResponse.IsSuccessful)
                throw new Exception($"createOwner: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}");

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject == null)
                throw new Exception($"createOwner: Failed to deserialize response. URL: {requestUrl}, Response: {responseString}");
            OwnerId = dynamicObject;
        }

        public void createAddress()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint3;
            var (client, requestUrl) = SetUrlWithInfo("createaddress", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateAddress.json");
            var requestJson = File.ReadAllText(file);
            var request = CreatePostRequest(requestJson);
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            if (!restResponse.IsSuccessful)
                throw new Exception($"createAddress: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}");

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject == null)
                throw new Exception($"createAddress: Failed to deserialize response. URL: {requestUrl}, Response: {responseString}");
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
            var (client, requestUrl) = SetUrlWithInfo("createpet", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreatePet.json");
            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            string uniqueMicrochip = DateTime.Now.ToString("ddMMyyHHmmssfff");
            dynamicObject.petIdentification.microchipNumber = uniqueMicrochip;
            dynamicObject.petMicrochip.microchipNumber = uniqueMicrochip;
            var request = CreatePostRequest(JsonConvert.SerializeObject(dynamicObject));
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            if (!restResponse.IsSuccessful)
                throw new Exception($"createPet: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}");

            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject2 == null)
                throw new Exception($"createPet: Failed to deserialize response. URL: {requestUrl}, Response: {responseString}");
            PetId = dynamicObject2;
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
            var (client, requestUrl) = SetUrlWithInfo("application", APIEndPoint);
            var file = Path.Combine(RequestFolder, "CreateApplication.json");
            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            dynamicObject.id = AppId;
            dynamicObject.petId = PetId;
            dynamicObject.userId = UserId;
            dynamicObject.ownerId = OwnerId;
            dynamicObject.ownerAddressId = AddressId;

            // Generate unique reference number and update timestamps
            var uniqueRef = "A" + DateTime.Now.ToString("ddHHmmss");
            dynamicObject.referenceNumber = uniqueRef;
            // Use current UTC time for dates
            var currentDateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            dynamicObject.dateOfApplication = currentDateTime;
            dynamicObject.createdOn = currentDateTime;
            dynamicObject.updatedOn = currentDateTime;

            // Use the actual userId for createdBy/updatedBy
            dynamicObject.createdBy = UserId;
            dynamicObject.updatedBy = UserId;

            var requestPayload = JsonConvert.SerializeObject(dynamicObject);

            // Log the values being sent
            Console.WriteLine("=== CREATE APPLICATION REQUEST ===");
            Console.WriteLine($"URL: {requestUrl}");
            Console.WriteLine($"AppId: {AppId}");
            Console.WriteLine($"PetId: {PetId}");
            Console.WriteLine($"UserId: {UserId}");
            Console.WriteLine($"OwnerId: {OwnerId}");
            Console.WriteLine($"AddressId: {AddressId}");
            Console.WriteLine($"Request Payload: {requestPayload}");
            Console.WriteLine("=================================");

            var request = CreatePostRequest(requestPayload);
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            if (!restResponse.IsSuccessful)
                throw new Exception($"createApplication: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}, Request: {requestPayload}");

            if (string.IsNullOrWhiteSpace(responseString))
                throw new Exception($"createApplication: Empty response received. URL: {requestUrl}, Status: {restResponse.StatusCode}");

            var dynamicObject2 = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dynamicObject2 == null)
                throw new Exception($"createApplication: Failed to deserialize response. Response: {responseString}");
            if (dynamicObject2 is string)
                throw new Exception($"createApplication returned unexpected response: {responseString}");
            QueueId = dynamicObject2.id?.ToString() 
                ?? throw new Exception($"createApplication: 'id' is null. Response: {responseString}");
            AppReferenceNumber = dynamicObject2.referenceNumber?.ToString() 
                ?? throw new Exception($"createApplication: 'referenceNumber' is null. Response: {responseString}");
            return AppReferenceNumber;
        }

        public bool writeApplicationToQueue()
        {
            Task<RestResponse> response = null;
            string APIEndPoint = DataSetupConfig.Configuration.ApiEndPoint4;
            var (client, requestUrl) = SetUrlWithInfo("writetoqueue", APIEndPoint);
            var file = Path.Combine(RequestFolder, "ApplicationToQueue.json");
            var requestJson = File.ReadAllText(file);
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(requestJson.ToString())!;
            dynamicObject.applicationId = QueueId;
            var requestPayload = JsonConvert.SerializeObject(dynamicObject);
            var request = CreatePostRequest(requestPayload);
            var correlationId = AttachCorrelationId(request);
            response = GetResponseAsync(client, request);
            var restResponse = response.Result;
            var responseString = restResponse.Content ?? string.Empty;

            Console.WriteLine($"writeApplicationToQueue correlation/trace id: {correlationId} (search this in the dynamic-integration App Insights to find the server-side exception)");
            LogResponseDiagnostics("WRITE TO QUEUE", requestUrl, request, restResponse, requestPayload);

            if (!restResponse.IsSuccessful)
            {
                // A 5xx through APIM normally returns an empty body. Re-issue the same request with
                // Ocp-Apim-Trace so APIM emits a trace location URL pinpointing whether the 500 is
                // a gateway policy failure or the backend service throwing.
                if ((int)restResponse.StatusCode >= 500)
                    TraceFailedQueueWrite(client, requestPayload, requestUrl);

                Console.WriteLine($"writeApplicationToQueue: API call failed. URL: {requestUrl}, Status: {restResponse.StatusCode}, Error: {restResponse.ErrorMessage}, Response: {responseString}");
                return false;
            }

            if (responseString.Contains("Added Message to Queue Successfully"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Re-sends the writetoqueue request with the <c>Ocp-Apim-Trace</c> header so APIM returns a
        /// gateway trace location (<c>Ocp-Apim-Trace-Location</c>). Opening that URL shows the full
        /// inbound/backend/outbound pipeline for the failing call, which is the supported way to see
        /// exactly where a 500 originates behind the gateway. Requires tracing to be allowed for the
        /// subscription; if it is not, the header is simply ignored.
        /// </summary>
        private void TraceFailedQueueWrite(RestClient client, string requestPayload, string requestUrl)
        {
            try
            {
                var traceRequest = CreatePostRequest(requestPayload);
                traceRequest.AddOrUpdateHeader("Ocp-Apim-Trace", "true");
                var traceResponse = GetResponseAsync(client, traceRequest).Result;
                LogResponseDiagnostics("WRITE TO QUEUE (APIM TRACE)", requestUrl, traceRequest, traceResponse, requestPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"writeApplicationToQueue: APIM trace request failed: {ex.Message}");
            }
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

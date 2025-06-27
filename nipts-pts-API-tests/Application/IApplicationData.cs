using RestSharp;

namespace nipts_pts_API_tests.Application
{
    public interface IApplicationData
    {
        public string GetApplicationToApprove(string AppReference);
        public string GetApplicationToReject(string AppReference);
        public string GetApplicationToRevoke(string AppReference);
        public void ApproveApplication(string ApplicationId);
        public void SuspendApplication(string ApplicationId);
        public void RejectApplication(string ApplicationId);
        public void RevokeApplication(string ApplicationId);
        public Task<RestResponse> GetApplication(string AppReference);
        public string CreateApplicationAPI(string AppId);
        string CreateApplicationWithMandatoryAddressFieldsAPI(string appId);
        public bool writeApplicationToQueue();
        public string CreateApplicationSigFNoAPI(string AppId);
        public string GetPetDetails(string AppReference);
        public string GetMicrochipDetails(string AppReference);
        public string writeOfflineApplicationToQueue(string randonNumber,string Species);
        public void RevokeApprovedApplication(string PTDNumber);
        public string CreateApplicationWithPetCustomValues(string AppId,string PetSpecies);
        public string CreateApplicationAPIWithOtherColour(string appId);
        public void GetAwaitingApplicationToSuspend(string AppReference);
        public void GetAuthorisedApplicationToSuspend(string PTDNumber);
        public void GetSuspendedApplicationToApprove(string PTDNumber);
    }
}

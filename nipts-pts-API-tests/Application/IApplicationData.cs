using RestSharp;

namespace nipts_pts_API_tests.Application
{
    public interface IApplicationData
    {
        public string GetApplicationToApprove(string AppReference);
        public string GetApplicationToReject(string AppReference);
        public string GetApplicationToRevoke(string AppReference);
        public void ApproveApplication(string ApplicationId);
        public void RejectApplication(string ApplicationId);
        public void RevokeApplication(string ApplicationId);
        public Task<RestResponse> GetApplication(string AppReference);
        public string CreateApplicationAPI(string AppId);
        public bool writeApplicationToQueue();
        public string CreateApplicationSigFNoAPI(string AppId);

    }
}

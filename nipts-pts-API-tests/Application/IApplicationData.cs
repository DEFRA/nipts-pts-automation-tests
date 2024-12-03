using RestSharp;

namespace nipts_pts_API_tests.Application
{
    public interface IApplicationData
    {
        public void GetApplicationToApprove(string AppReference);
        public void GetApplicationToReject(string AppReference);
        public void GetApplicationToRevoke(string AppReference);
        public void ApproveApplication(string ApplicationId);
        public void RejectApplication(string ApplicationId);
        public void RevokeApplication(string ApplicationId);
        public Task<RestResponse> GetApplication(string AppReference);
    }
}

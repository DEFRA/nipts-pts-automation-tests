namespace nipts_pts_API_tests.Application
{
    public interface IApplicationData
    {
        public void GetApplicationToApprove();
        public void ApproveApplication(string ApplicationId);

    }
}

namespace nipts_pts_automation_tests.Configuration
{
    public class B2CConfig
    {
        public string TenantName { get; set; } = string.Empty;
        public string Policy { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string ServiceId { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;

        /// <summary>
        /// CP / port-checker B2C client id. The pts-pet-checker API only trusts a token whose
        /// audience is this CP client, so checker calls need a CP token rather than the applicant
        /// (ClientId) token used for the backend create/approve APIs.
        /// </summary>
        public string CPClientId { get; set; } = string.Empty;

        /// <summary>
        /// Secret for <see cref="CPClientId"/>, used for the CP interactive auth-code login.
        /// </summary>
        public string CPClientSecret { get; set; } = string.Empty;

        /// <summary>
        /// CP DEFRA serviceId for the B2C authorize request. The applicant ServiceId mints an
        /// applicant token, so CP needs its own; the wrong one gives AADB2C90085/invalid_grant.
        /// Falls back to ServiceId when empty.
        /// </summary>
        public string CPServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Redirect URI registered for <see cref="CPClientId"/>. Must match the CP app registration
        /// exactly or the auth-code exchange fails with invalid_grant. Falls back to RedirectUri.
        /// </summary>
        public string CPRedirectUri { get; set; } = string.Empty;

        /// <summary>
        /// Optional CP scope override. When empty defaults to "openid offline_access {CPClientId}".
        /// </summary>
        public string CPScope { get; set; } = string.Empty;

        /// <summary>
        /// The DEFRA IdP hub authority that fronts B2C, e.g.
        /// https://{host}/idphub/b2c/{policy}. When set, tokens are acquired through the
        /// IdP hub so the issuer/signing keys match what the backend APIs validate against
        /// (their AzureAdB2C MetadataAddress). Falls back to b2clogin.com when empty.
        /// </summary>
        public string Instance { get; set; } = string.Empty;

        /// <summary>
        /// The OpenID Connect metadata document for the IdP hub, e.g.
        /// {Instance}/.well-known/openid-configuration. Optional; informational/diagnostic.
        /// </summary>
        public string MetadataAddress { get; set; } = string.Empty;

        /// <summary>
        /// Explicit OAuth2 token endpoint for the client-credentials grant. When empty it is
        /// derived from TenantName (b2clogin.com). Allows pointing at a different issuer
        /// without code changes.
        /// </summary>
        public string TokenEndpoint { get; set; } = string.Empty;

        /// <summary>
        /// The client-credentials scope. When empty it defaults to "{ClientId}/.default",
        /// which yields an access token whose audience is the backend (PTS tenant) client id.
        /// </summary>
        public string Scope { get; set; } = string.Empty;

        /// <summary>
        /// Government Gateway user id of a backend (PTS/AP tenant) enrolled test user. The
        /// backend APIs only trust a B2C USER token for the PTS tenant app, which cannot be
        /// minted without an interactive login (no client-credentials/ROPC policy exists on the
        /// tenant). This user is signed in via a forced (prompt=login) authorize request so the
        /// resulting token has aud = backend ClientId and iss = b2clogin.com.
        /// </summary>
        public string BackendUsername { get; set; } = string.Empty;

        /// <summary>
        /// Password for <see cref="BackendUsername"/>.
        /// </summary>
        public string BackendPassword { get; set; } = string.Empty;

        /// <summary>
        /// Optional Base32 authenticator (TOTP) secret for <see cref="BackendUsername"/>. Only
        /// needed when the backend user has Government Gateway 2-Step Verification enabled: it lets
        /// the login flow generate the access code automatically. Leave empty when the user has no
        /// 2SV (the preferred setup, matching the CP test user, which signs straight through).
        /// </summary>
        public string BackendTotpSecret { get; set; } = string.Empty;
    }
}

namespace nipts_pts_automation_tests.Configuration
{
    public class KeyVaultConfiguration
    {
        /// <summary>
        /// Name of the Azure Key Vault (e.g. TSTTRDINFKV1001). The vault URI is built as
        /// https://{VaultName}.vault.azure.net/. When empty, Key Vault resolution is skipped
        /// and the values already present in appsettings.json are used as-is.
        /// </summary>
        public string VaultName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the shared sign-in password, mapped at startup onto
        /// <see cref="TestConfiguration.EnvPassword"/>.
        /// </summary>
        public string EnvPasswordSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the BrowserStack username, mapped at startup onto
        /// <see cref="BrowserStackConfiguration.CloudDeviceUserName"/>.
        /// </summary>
        public string BrowserStackUserNameSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the BrowserStack access key, mapped at startup onto
        /// <see cref="BrowserStackConfiguration.CloudDeviceUserKey"/>.
        /// </summary>
        public string BrowserStackAccessKeySecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the APIM subscription key, mapped at startup onto
        /// <see cref="BackendSetupConfig.CommonSubscriptionKey"/>.
        /// </summary>
        public string CommonSubscriptionKeySecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the CP B2C client id, mapped at startup onto
        /// <see cref="B2CConfig.CPClientId"/>.
        /// </summary>
        public string CpClientIdSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the B2C tenant client id, mapped at startup onto
        /// <see cref="B2CConfig.ClientId"/>.
        /// </summary>
        public string ClientIdSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the B2C tenant client secret, mapped at startup onto
        /// <see cref="B2CConfig.ClientSecret"/>.
        /// </summary>
        public string ClientSecretSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the CP B2C client secret, mapped at startup onto
        /// <see cref="B2CConfig.CPClientSecret"/>.
        /// </summary>
        public string CpClientSecretSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the B2C tenant service id, mapped at startup onto
        /// <see cref="B2CConfig.ServiceId"/>.
        /// </summary>
        public string ServiceIdSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the B2C sign-in policy, mapped at startup onto
        /// <see cref="B2CConfig.Policy"/>.
        /// </summary>
        public string PolicySecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the automation backend username, mapped at startup onto
        /// <see cref="B2CConfig.BackendUsername"/>.
        /// </summary>
        public string AutomationsUserNameSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the automation backend password, mapped at startup onto
        /// <see cref="B2CConfig.BackendPassword"/>.
        /// </summary>
        public string AutomationsPasswordSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the Service Bus connection string, mapped at startup onto
        /// <see cref="ServiceBusConnectionConfig.ServiceBusConnString"/>.
        /// </summary>
        public string ServiceBusConnectionStringSecretName { get; set; } = string.Empty;

        /// <summary>
        /// Key Vault secret that holds the CP APIM subscription key, mapped at startup onto
        /// <see cref="BackendSetupConfig.CheckerSubscriptionKey"/>.
        /// </summary>
        public string CpApimSubscriptionKeySecretName { get; set; } = string.Empty;
    }
}

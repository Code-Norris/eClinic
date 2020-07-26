using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;
using Flurl;
using Flurl.Http;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eClinic.PatientRegistration.Infra
{
    public class SecretStore : ISecretStore
    {
        public SecretStore(IAppLogger logger)
        {
            _logger = logger;
        }

        // public async Task<string> GetAsync(string secretName)
        // {
        //     _logger.Info($"SecretStore.GetStarted");

        //     //https://cmatskas.com/setting-up-managed-identities-for-asp-net-core-web-app-running-on-azure-app-service/
        //     var azureServiceTokenProvider =
        //         new AzureServiceTokenProvider($"RunAs=App;AppId={UAMIClientId}");

        //     var akv = new KeyVaultClient(
        //                new KeyVaultClient.AuthenticationCallback(
        //                    azureServiceTokenProvider.KeyVaultTokenCallback));
                           
        //     var secret =
        //         await akv.GetSecretAsync("https://akv-eClinic.vault.azure.net/", secretName);
            
        //     string secretValue = secret.Value;

        //     return secretValue;
        // }

        public async Task<string> GetAsync(string secretName)
        {
           string url = GetSecretUrl(secretName);

           _logger.Info($"SecretStore.Get: {url}");

           string secretJson = await url.GetStringAsync();

           var jObj = JObject.Parse(secretJson);
           
           string secretValue = jObj[secretName].Value<string>();

           _logger.Info($"SecretStore.GetComplete");

           return secretValue;
        }

        private IAppLogger _logger;
        private const string UAMIClientId = "7c20ef39-5b01-431c-90ad-1e16a338908b";

        public string GetSecretUrl(string secretName)
        {
            string daprApiPort =
                Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500";
            string secretUrl =
                $"http://localhost:{daprApiPort}/v1.0/secrets/secretstore/{secretName}";

            return secretUrl;

        }
    }
}

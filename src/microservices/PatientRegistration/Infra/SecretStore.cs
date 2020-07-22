using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace eClinic.PatientRegistration.Infra
{
    public class SecretStore : ISecretStore
    {
        public async Task<string> GetAsync(string secretName)
        {
           string url = GetSecretUrl(secretName);

           dynamic secretJson = await url.GetJsonAsync();

           string secret = secretJson.CosmosConnString;

           return secret;
        }

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

using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;
using Flurl;
using Flurl.Http;

namespace eClinic.PatientRegistration.Infra
{
    public class SecretStore
    {
        public async Task<Secrets> LoadAsync()
        {
           var secrets = await Utils.BaseDaprUrl.GetJsonAsync<Secrets>();

           return secrets;
        }
    }
}

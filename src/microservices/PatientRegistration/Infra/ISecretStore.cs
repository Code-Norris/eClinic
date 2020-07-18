using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;

namespace eClinic.PatientRegistration.Infra
{
    public interface ISecretStore
    {
        public Task<Secrets> LoadAsync();
    }
}

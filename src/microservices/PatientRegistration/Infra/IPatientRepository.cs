using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;

namespace eClinic.PatientRegistration.Infra
{
    public interface IPatientRepository
    {
        Task<Patient> FindPatientByIdentificaionNumberAsync(string identificationNumber);

        Task<Patient> SearchPatientByNameAsync(string namePattern);

        Task<Patient> CreateNewPatient(Patient patient);

        Task<Patient> UpdateExistPatient(Patient patient);
    }
}

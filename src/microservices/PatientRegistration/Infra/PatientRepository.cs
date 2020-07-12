using System;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Domain;

namespace eClinic.PatientRegistration.Infra
{
    public class PatientRepository : IPatientRepository
    {
        public Task<Patient> CreateNewPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> FindPatientByIdentificaionNumberAsync(string identificationNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> SearchPatientByNameAsync(string namePattern)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> UpdateExistPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
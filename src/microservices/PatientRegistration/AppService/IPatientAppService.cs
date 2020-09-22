using System.Collections.Generic;
using System.Threading.Tasks;

namespace eClinic.PatientRegistration.AppService
{
    public interface IPatientAppService
    {
        Task<IEnumerable<PatientSearchResult>> SearchPatientByName(string nameContains);

        Task<PatientSearchResult> FindPatientByIDCardNumber(string idNumber);

        Task<PatientRegistrationResult> RegisterPatient(string patientId, string accessToken);

        Task<bool> CreateNewPatient(NewPatientView patient);

        Task<bool> UpdateExistPatient(NewPatientView patient);
        
    }   
}
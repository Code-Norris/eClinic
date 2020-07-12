using System.Collections.Generic;
using System.Threading.Tasks;

namespace eClinic.PatientRegistration.AppService
{
    public interface IPatientAppService
    {
        Task<IEnumerable<PatientView>> SearchPatientByName(string nameContains);

        Task<PatientView> FindPatientByIdentificationNumber(string idNumber);

        Task<bool> CreateNewPatient(PatientView patient);

        Task<bool> UpdateExistPatient(PatientView patient);
        
    }   
}
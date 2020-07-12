using System.Collections.Generic;
using System.Threading.Tasks;

namespace eClinic.PatientRegistration.AppService
{
    public interface IPatientAppService
    {
        Task<IEnumerable<PatientView>> SearchPatientByName(string nameContains);

        Task<PatientView> FindPatientByIdentificationNumber(string idNumber);

        Task<PatientView> CreateNewPatient(PatientView patient);

        Task<PatientView> UpdateExistPatient(PatientView patient);
        
    }   
}
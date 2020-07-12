using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;

namespace eClinic.PatientRegistration.AppService
{
    public class PatientAppService : IPatientAppService
    {
        public PatientAppService(IContainer diContainer)
        {
            _container = diContainer;
        }

        public Task<PatientView> CreateNewPatient(PatientView patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<PatientView> FindPatientByIdentificationNumber(string idNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PatientView>> SearchPatientByName(string nameContains)
        {
            throw new System.NotImplementedException();
        }

        public Task<PatientView> UpdateExistPatient(PatientView patient)
        {
            throw new System.NotImplementedException();
        }

        private IContainer _container;
    }
}
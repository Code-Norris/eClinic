using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using eClinic.PatientRegistration.Domain;
using eClinic.PatientRegistration.Infra;
using shortid;

namespace eClinic.PatientRegistration.AppService
{
    public class PatientAppService : IPatientAppService
    {
        public PatientAppService(IPatientRepository patientRepo, IMapper objectMapper)
        {
            _patientRepo = patientRepo;
            _objMapper = objectMapper;
        }

        public async Task<bool> CreateNewPatient(PatientView patientView)
        {
           var patient= _objMapper.Map<PatientView, Patient>(patientView);
           patient.Id = UniqueId.New();

           await _patientRepo.CreateNewPatient(patient);

           return true;

        //    patient.Id = UniqueId.New();
        //    patient.Name = patientView.Name;
        //    patient.IdentificationNumber = patientView.IdentificationNumber;
        //    patient.HomeAddress = new Address()
        //    {
        //       City =  patientView.City,
        //       Street = patientView.Street,
        //       State = patientView.State,
        //       PostalCode = patientView.PostalCode
        //    };
        //    patient.PatientAllergy.AddAllergies(patientView.PatientAllergies);

        //    patient.Height = patientView.Height;
        //    patient.Weight = patientView.Weight;
        //    patient.Age = patientView.Age;
        }

        public async Task<bool> UpdateExistPatient(PatientView patientView)
        {
            var patient =
                await _patientRepo.FindPatientByIdentificaionNumberAsync(patientView.IdentificationNumber);
            patient.Name = patientView.Name;
            patient.IdentificationNumber = patientView.IdentificationNumber;
            patient.HomeAddress = new Address()
            {
                City =  patientView.City,
                Street = patientView.Street,
                State = patientView.State,
                PostalCode = patientView.PostalCode
            };
            patient.Allergies = patientView.Allergies;

            patient.Height = patientView.Height;
            patient.Weight = patientView.Weight;
            patient.Age = patientView.Age;

            await _patientRepo.UpdateExistPatient(patient);

            return true;
        }

        public Task<PatientView> FindPatientByIdentificationNumber(string idNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PatientView>> SearchPatientByName(string nameContains)
        {
            throw new System.NotImplementedException();
        }

        private IMapper _objMapper;
        private IPatientRepository _patientRepo;
    }
}
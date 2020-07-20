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
        public PatientAppService
            (IPatientRepository patientRepo, IMapper objectMapper,
            IPatientValidatorDomainService patientValidatorService)
        {
            _patientRepo = patientRepo;
            _mapper = objectMapper;
            _patientValidatorService = patientValidatorService;
        }

        public async Task<PatientCreationResult> CreateNewPatient(PatientView patientView)
        {
           var homeAddress = _mapper.Map<PatientView, Address>(patientView);
           var patient= _mapper.Map<PatientView, Patient>(patientView);
           patient.HomeAddress = homeAddress;
           patient.Id = UniqueId.New();

           var result = _patientValidatorService.ValidatePatientInformation(patient);

           var creationResult =
            _mapper.Map<PatientInfoValidationResult, PatientCreationResult>(result);

           await _patientRepo.CreateNewPatient(patient);

           return creationResult;
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

        private IMapper _mapper;
        private IPatientRepository _patientRepo;
        private IPatientValidatorDomainService _patientValidatorService;
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using eClinic.PatientRegistration.Domain;
using eClinic.PatientRegistration.Infra;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eClinic.PatientRegistration.AppService
{
    public class PatientAppService : IPatientAppService
    {
        public PatientAppService
            (IPatientRepository patientRepo, IMapper propMapper,
            IPatientValidatorDomainService patientValidatorService)
        {
            _patientRepo = patientRepo;
            _propmap = propMapper;
            _patientValidatorService = patientValidatorService;
        }

        public Task<IEnumerable<PatientSearchResult>> SearchPatientByName(string nameContains)
        {
            throw new NotImplementedException();
        }

        public Task<PatientSearchResult> FindPatientByIDCardNumber(string idNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientRegistrationResult> RegisterPatient(string patientId, string accessToken)
        {
            //TODO
                //saves record to cosmos

           var qi = await QueuePatientAsync(patientId, accessToken);

           return _propmap.Map<QueueInfo, PatientRegistrationResult>(qi);
        }

        public Task<bool> CreateNewPatient(NewPatientView patient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExistPatient(NewPatientView patient)
        {
            throw new NotImplementedException();
        }

        private async Task<QueueInfo> QueuePatientAsync(string patientId, string accessToken)
        {
           var resp =
            await "http://localhost:9090/api/q/pc"
                .WithOAuthBearerToken(accessToken)
                .PostJsonAsync(new {PatientID = patientId});
            
            string respBody = await resp.Content.ReadAsStringAsync();
            var queueinfo = JsonConvert.DeserializeObject<QueueInfo>(respBody);

            var validator = new QueueInfoValidator();
            var result = validator.Validate(queueinfo);

            if(!result.IsValid)
                throw new Exception(result.ToString());
            
            return queueinfo;
        }

        // public async Task<PatientCreationResult> CreateNewPatient
        //     (PatientView patientView, string accessToken)
        // {
        //    var homeAddress = _mapper.Map<PatientView, Address>(patientView);

        //    var patient= _mapper.Map<PatientView, Patient>(patientView);
        //    patient.HomeAddress = homeAddress;
        //    patient.ID = UID.New();

        //    var result = _patientValidatorService.ValidatePatientInformation(patient);

        //    var creationResult =
        //     _mapper.Map<PatientInfoValidationResult, PatientCreationResult>(result);

        //    await _patientRepo.CreateNewPatient(patient);

        //    return creationResult;
        // }

        // public async Task<bool> UpdateExistPatient(PatientView patientView)
        // {
        //     var patient =
        //         await _patientRepo.FindPatientByIdentificaionNumberAsync(patientView.IDCardNumber);
        //     patient.Name = patientView.Name;
        //     patient.IDCardNumber = patientView.IDCardNumber;
        //     patient.HomeAddress = new Address()
        //     {
        //         City =  patientView.City,
        //         Street = patientView.Street,
        //         State = patientView.State,
        //         PostalCode = patientView.PostalCode
        //     };
        //     patient.Allergies = patientView.Allergies;

        //     patient.Height = patientView.Height;
        //     patient.Weight = patientView.Weight;
        //     patient.Age = patientView.Age;

        //     await _patientRepo.UpdateExistPatient(patient);

        //     return true;
        // }

        // public Task<PatientView> FindPatientByIdentificationNumber(string idNumber)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public Task<IEnumerable<PatientView>> SearchPatientByName(string nameContains)
        // {
        //     throw new System.NotImplementedException();
        // }

        private IMapper _propmap;
        private IPatientRepository _patientRepo;
        private IPatientValidatorDomainService _patientValidatorService;
    }
}
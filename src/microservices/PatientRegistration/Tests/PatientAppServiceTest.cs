using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClinic.PatientRegistration.AppService;
using eClinic.PatientRegistration.Domain;
using eClinic.PatientRegistration.Infra;
using FluentAssertions;
using GenFu;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace eClinic.PatientRegistration.Test
{
    public class PatientAppServiceTest
    {
        [Fact]
        public async Task CreateNewPatient_ShouldCreateNewPatient()
        {
            var patientView = A.New<NewPatientView>();
            patientView.Height = 178;
            patientView.Weight = 78;
            patientView.Allergies = new string[] {"penicillin", "ibuprofen", "apirin"};

            var mapper = new PropMapper();
            var patient = mapper.Mapper.Map<NewPatientView, Patient>(patientView);

            //setup
            var patientRepo = new Mock<IPatientRepository>();
            patientRepo
                .Setup(x => x.CreateNewPatient(patient))
                .ReturnsAsync(true);

            var patientInfoValidator = new Mock<IPatientValidatorDomainService>();
            patientInfoValidator
                .Setup(x => x.ValidatePatientInformation(patient))
                .Returns(new PatientInfoValidationResult()
                {
                   IsValid = true 
                });

            var patientSvc =
                new PatientAppService(patientRepo.Object, mapper.Mapper, patientInfoValidator.Object);

            //act
            var success = await patientSvc.CreateNewPatient(patientView, "");

            success.IsValid.Should().BeTrue();
        }
    }
}

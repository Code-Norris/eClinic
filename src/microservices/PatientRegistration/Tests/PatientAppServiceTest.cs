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
            //setup
            var patientRepo = new Mock<IPatientRepository>();

            IPatientValidatorDomainService patientInfoValidator = new PatientValidatorDomainService();

            var objMapper = new ObjectMapper();
            
            var patientSvc =
                new PatientAppService(patientRepo.Object, objMapper.Mapper, patientInfoValidator);

            var pw = A.New<PatientView>();
            pw.Height = 178;
            pw.Weight = 78;
            pw.Allergies = new string[] {"penicillin", "ibuprofen", "apirin"};

            //act
            var success = await patientSvc.CreateNewPatient(pw);

            success.IsValid.Should().BeTrue();
        }
    }
}

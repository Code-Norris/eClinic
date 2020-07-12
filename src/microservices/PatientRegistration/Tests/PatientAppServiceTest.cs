using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eClinic.PatientRegistration.Infra;
using FluentAssertions;
using GenFu;
using Moq;
using Xunit;
using Xunit.Extensions;

namespace eClinic.PatientRegistration.AppService.Test
{
    public class PatientAppServiceTest
    {
        [Fact]
        public async Task ShouldCreateNewPatient()
        {
            //setup
            var patientRepo = new Mock<IPatientRepository>();

            var objMapper = new ObjectMapper();
            
            var patientSvc = new PatientAppService(patientRepo.Object, objMapper.Mapper);

            var pw = A.New<PatientView>();
            pw.Height = 178;
            pw.Weight = 78;
            pw.Allergies = new string[] {"penicillin", "ibuprofen", "apirin"};

            //act
            var success = await patientSvc.CreateNewPatient(pw);

            success.Should().BeTrue();
        }

        // public static IEnumerable<PatientView> PatientViews
        // {
        //     get 
        //     {
        //         return new List<PatientView>()
        //         {
        //             {
        //                 A.New<PatientView>()
        //             }
        //         };
        //     }
        // }
    }
}

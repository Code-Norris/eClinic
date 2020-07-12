using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eClinic.PatientRegistration.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eClinic.PatientRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        public PatientController(IPatientAppService patientService)
        {
            patientAppSvc = patientService;
        }

        [HttpPost("new")]
        public async Task<PatientView> CreateNewPatient(PatientView patient)
        {
            return await patientAppSvc.CreateNewPatient(patient);
        }

        private IPatientAppService patientAppSvc;
    }
}

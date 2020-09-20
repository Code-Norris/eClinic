using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eClinic.PatientRegistration.AppService;
using eClinic.PatientRegistration.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eClinic.PatientRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/pr")]
    public class PatientController : ControllerBase
    {
        public PatientController
            (IPatientAppService patientService, IAppLogger appLogger)
        {
            patientAppSvc = patientService;
            _logger = appLogger;
        }

        [Authorize()]
        [HttpGet("test")]
        public IEnumerable<string> Test(){
            return User.Claims.Select(x => x.Value).ToList();
        }

        [HttpPost("new")]
        public async Task<PatientCreationResult> CreateNewPatient(PatientView patient)
        {
            return await patientAppSvc.CreateNewPatient(patient);
        }

        [HttpPost("register")]
        public async Task<bool> RegisterNewPatient(PatientView patient)
        {
            return true;
        }

        private IPatientAppService patientAppSvc;
        private IAppLogger _logger;
    }
}

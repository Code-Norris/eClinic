using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eClinic.PatientRegistration.AppService;
using eClinic.PatientRegistration.Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eClinic.PatientRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/p")]
    public class PatientController : ControllerBase
    {
        public PatientController
            (IPatientAppService patientService, IAppLogger appLogger)
        {
            _appsvc = patientService;
            _logger = appLogger;
        }

        [Authorize()]
        [HttpGet("test")]
        public async Task<IEnumerable<string>> Test(){

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            return User.Claims.Select(x => x.Value).ToList();
        }

        [HttpPost("new")]
        public async Task<bool> CreateNewPatient([FromBody] NewPatientView patient)
        {
            throw new NotImplementedException();
        }

        [Authorize()]
        [HttpPost("reg")]
        public async Task<PatientRegistrationResult> RegisterNewPatient([FromBody]RegisterPatientView patient)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            return await _appsvc.RegisterPatient(patient.PatientID, accessToken);
        }

        private IPatientAppService _appsvc;
        private IAppLogger _logger;
    }
}

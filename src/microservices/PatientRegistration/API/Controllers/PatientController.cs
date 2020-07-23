using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eClinic.PatientRegistration.AppService;
using eClinic.PatientRegistration.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eClinic.PatientRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        public PatientController
            (IPatientAppService patientService, IAppLogger appLogger)
        {
            patientAppSvc = patientService;
            _logger = appLogger;
        }

        [HttpPost("new")]
        public async Task CreateNewPatient(PatientView patient)
        {
            _logger.Info("patientregistration.CreateNewPatient.started");

            await patientAppSvc.CreateNewPatient(patient);

            _logger.Info("patientregistration.CreateNewPatient.ended");
        }

        private IPatientAppService patientAppSvc;
        private IAppLogger _logger;
    }
}

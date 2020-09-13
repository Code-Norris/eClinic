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
    [Route("api")]
    public class HealthController : ControllerBase
    {
        public HealthController()
        {
        }

        [HttpGet("healthz")]
        public string GetHealth()
        {
           
            return "alive";
        } 
    }
}
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
    [Route("healthz")]
    public class HealthController : ControllerBase
    {
        [HttpGet()]
        public string GetHealth()
        {
            return "alive";
        } 
    }
}
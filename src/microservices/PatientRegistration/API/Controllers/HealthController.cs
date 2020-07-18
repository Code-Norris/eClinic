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
    public class HealthController : ControllerBase
    {
        [HttpGet("alive")]
        public string GetHealth()
        {
            return "alive";
        } 
    }
}
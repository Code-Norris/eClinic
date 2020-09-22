using System;

namespace eClinic.PatientRegistration.AppService
{
    public class PatientRegistrationResult
    {
         public int QueueNumber { get; set; } //denorm from queueinfo
        public string PatientID { get; set; } //denorm from queueinfo
        public DateTime QueuedAt { get; set; } = DateTime.Now; //denorm from queueinfo
    }
}
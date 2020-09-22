using System;

namespace eClinic.PatientRegistration.Domain
{
    public class QueueInfo 
    {
        public int QueueNumber { get; set; }
        public string PatientID { get; set; }
        public DateTime QueuedAt { get; set; } = DateTime.Now;
    }
}

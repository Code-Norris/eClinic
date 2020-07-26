using System;

namespace eClinic.PatientRegistration.AppService
{
    public class PatientView
    {

        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public int Age { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        //cm
        public double Height { get; set; }
        //kg
        public double Weight { get; set; }
        public string[] Allergies { get; set; }
    }
}
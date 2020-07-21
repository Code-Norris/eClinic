using System;

namespace eClinic.PatientRegistration.Domain
{
    public class PatientRegistration : AggregateRoot
    {
        public DateTime RegisteredAt { get; set; }
        public Patient Patient { get; set; }
        public Pharmacist DutyPharmacist { get; set; }

        public void CreatePatientRegistration
            (string identificationNumber, Patient patient)
        {

        }
    }
}
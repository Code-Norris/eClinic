using System;
using System.Collections.Generic;

namespace eClinic.PatientRegistration.Domain
{
    public class Address : ValueObject
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
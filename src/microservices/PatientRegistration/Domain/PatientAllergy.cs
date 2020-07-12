using System;
using System.Collections.Generic;

namespace eClinic.PatientRegistration.Domain
{
    public class PatientAllergy : ValueObject
    {
        public IEnumerable<string> Allergies { get; set; }
        
        public void AddAllergy(string allergy)
        {
            _allergies.Add(allergy);
        }

        public string[] ToArray(string allergy)
        {

            return _allergies.ToArray();
        }

        private List<string> _allergies = new List<string>();

    }
}
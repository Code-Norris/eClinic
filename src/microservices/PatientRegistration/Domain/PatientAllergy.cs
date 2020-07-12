using System;
using System.Collections.Generic;

namespace eClinic.PatientRegistration.Domain
{
    public class PatientAllergy : ValueObject
    {        
        public void AddAllergies(string[] allergies)
        {
            _allergies.AddRange(allergies);
        }

        public string[] ToArray(string allergy)
        {

            return _allergies.ToArray();
        }

        private List<string> _allergies = new List<string>();

        public string[] Allergies 
        {
            get
            {
                return _allergies.ToArray();
            }
            set
            {
                _allergies.AddRange(value);
            }
        }

    }
}
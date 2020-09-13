using System;

namespace eClinic.PatientRegistration.Domain
{
    public class Patient : AggregateRoot
    {
        public Patient() {}

        public Patient(string name, string identificationNumber, int age, Address homeAddress,
            double height, double weight, string[] allergies)
        {
            Name = name;
            IdentificationNumber = identificationNumber;
            Age = age;
            HomeAddress = homeAddress;
            Height = height;
            Weight = weight;
            Allergies = allergies;
        }

        public string IDCardNumber { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public int Age { get; set; }
        public Address HomeAddress { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string[]  Allergies { get; set; }
        public DateTime RegistrationTime { get; set; } = DateTime.Now;
    }
}
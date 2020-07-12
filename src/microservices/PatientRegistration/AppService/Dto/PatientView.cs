namespace eClinic.PatientRegistration.AppService
{
    public class PatientView
    {

        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public int Age { get; set; }
        public string HomeAddress { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string[] PatientAllergies { get; set; }
    }
}
namespace eClinic.PatientRegistration.Domain
{
    public class Doctor : Entity
    {
        public string Name { get; set; }
        public bool IsLocum { get; set; }
    }
}
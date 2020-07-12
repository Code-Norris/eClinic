namespace eClinic.PatientRegistration.Domain
{
    public class PatientValidatorDomainService : IPatientValidatorDomainService
    {
        public bool ValidatePatientInformation(Patient patient)
        {
            var validator = new PatientInfoValidator();
            var result = validator.Validate(patient);
            return result.IsValid;
        }
    }
}
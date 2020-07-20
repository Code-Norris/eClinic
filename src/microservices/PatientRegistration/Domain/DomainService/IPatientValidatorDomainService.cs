namespace eClinic.PatientRegistration.Domain
{
    public interface IPatientValidatorDomainService
    {
        PatientInfoValidationResult ValidatePatientInformation(Patient patient);
    }
}
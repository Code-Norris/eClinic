namespace eClinic.PatientRegistration.Domain
{
    public interface IPatientValidatorDomainService
    {
        bool ValidatePatientInformation(Patient patient);
    }
}
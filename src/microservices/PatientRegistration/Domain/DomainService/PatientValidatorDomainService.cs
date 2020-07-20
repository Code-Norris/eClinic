namespace eClinic.PatientRegistration.Domain
{
    public class PatientValidatorDomainService : IPatientValidatorDomainService
    {
        public PatientInfoValidationResult ValidatePatientInformation(Patient patient)
        {
            var validator = new PatientInfoValidator();
            var result = validator.Validate(patient);
            return new PatientInfoValidationResult()
            {
                IsValid = result.IsValid,
                Result = string.Join(",", result.RuleSetsExecuted)
            };
        }
    }
}
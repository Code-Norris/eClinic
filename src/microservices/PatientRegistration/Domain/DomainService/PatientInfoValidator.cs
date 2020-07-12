using FluentValidation;

namespace eClinic.PatientRegistration.Domain
{
    public class PatientInfoValidator : AbstractValidator<Patient>
    {
        public PatientInfoValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.IdentificationNumber).NotEmpty();
            RuleFor(p => p.Age).LessThanOrEqualTo(130);
            RuleFor(p => p.Height).GreaterThan(0);
            RuleFor(p => p.Weight).GreaterThan(0);
            RuleFor(p => p.HomeAddress.City).NotEmpty();
            RuleFor(p => p.HomeAddress.State).NotEmpty();
            RuleFor(p => p.HomeAddress.Street).NotEmpty();
            RuleFor(p => p.HomeAddress.PostalCode).NotEmpty();
        }
    }
}
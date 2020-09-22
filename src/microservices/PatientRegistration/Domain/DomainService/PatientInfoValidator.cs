using FluentValidation;

namespace eClinic.PatientRegistration.Domain
{
    public class PatientInfoValidator : AbstractValidator<Patient>
    {
        public PatientInfoValidator()
        {
            RuleFor(p => p.ID).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.IDCardNumber).NotEmpty();
            RuleFor(p => p.Age).LessThanOrEqualTo(115);
            RuleFor(p => p.Height).GreaterThan(0);
            RuleFor(p => p.Weight).GreaterThan(0);
            RuleFor(p => p.HomeAddress.City).NotEmpty();
            RuleFor(p => p.HomeAddress.State).NotEmpty();
            RuleFor(p => p.HomeAddress.Street).NotEmpty();
            RuleFor(p => p.HomeAddress.PostalCode).NotEmpty();
        }
    }
}
using FluentValidation;

namespace eClinic.PatientRegistration.Domain
{
    public class QueueInfoValidator : AbstractValidator<QueueInfo>
    {
        public QueueInfoValidator()
        {
            RuleFor(p => p.PatientID).NotEmpty();
            RuleFor(p => p.QueueNumber).GreaterThan(0);
        }
    }
}
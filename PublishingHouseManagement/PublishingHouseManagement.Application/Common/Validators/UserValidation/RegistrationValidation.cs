using FluentValidation;
using PublishingHouseManagement.Application.Users.Command.UserRegistration;

namespace PublishingHouseManagement.Application.Common.Validators.UserValidation
{
    class RegistrationValidation : AbstractValidator<UserRegistrationCommand>
    {
        public RegistrationValidation()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("FirstName cannot be empty.");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName cannot be empty.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty.");

            RuleFor(x => x.Password)
              .NotEmpty()
              .WithMessage("Password cannot be empty.");

            RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role cannot be empty.");
        }
    }
}
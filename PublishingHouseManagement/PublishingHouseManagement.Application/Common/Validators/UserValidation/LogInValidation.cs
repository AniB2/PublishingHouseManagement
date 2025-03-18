using FluentValidation;
using PublishingHouseManagement.Application.Users.Command.LogIn;

namespace PublishingHouseManagement.Application.Common.Validators.UserValidation
{
    class LogInValidation : AbstractValidator<LogInCommand>
    {
        public LogInValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty.");

            RuleFor(x => x.Password)
              .NotEmpty()
              .WithMessage("Password cannot be empty.");
        }
    }
}
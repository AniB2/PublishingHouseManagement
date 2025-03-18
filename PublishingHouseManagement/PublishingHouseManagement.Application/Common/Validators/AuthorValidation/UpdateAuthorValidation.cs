using FluentValidation;
using PublishingHouseManagement.Application.Authors.Command.UpdateAuthor;
using PublishingHouseManagement.Application.Common.Validators.Extensions;

namespace PublishingHouseManagement.Application.Common.Validators.AuthorValidation
{
    public class UpdateAuthorValidation : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName cannot be empty.")
                .MinimumLength(2)
                .WithMessage("FirstName must be at least 2 characters long.")
                .MaximumLength(50)
                .WithMessage("FirstName cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("LastName cannot be empty.")
               .Length(2, 50)
               .WithMessage("LastName must be between 2 and 50 characters.");

            RuleFor(x => x.PrivateNumber)
               .NotEmpty()
               .WithMessage("PrivateNumber cannot be empty.")
               .Length(11)
               .WithMessage("PrivateNumber must be exactly 11 characters long.");

            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .WithMessage("BirthDate cannot be empty.")
               .Must(x => x.Year >= 18)
               .WithMessage("You must be at least 18 years old to register.");

            RuleFor(x => x.PhoneNumber)
              .MinimumLength(4)
              .WithMessage("PhoneNumber must be at least 4 characters long.")
              .MaximumLength(50)
              .WithMessage("PhoneNumber cannot exceed 50 characters.");

            RuleFor(x => x.Email).Email();
        }
    }
}
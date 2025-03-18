using FluentValidation;
using PublishingHouseManagement.Application.Products.Command.CreateProduct;

namespace PublishingHouseManagement.Application.Common.Validators.ProductValidator
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage("Name cannot be empty.")
             .MinimumLength(2)
             .WithMessage("Name must be at least 2 characters long.")
             .MaximumLength(250)
             .WithMessage("Name cannot exceed 250 characters.");

            RuleFor(x => x.Annotation)
                .NotEmpty()
                .WithMessage("Annotation cannot be empty.")
                .MinimumLength(100)
                .WithMessage("Annotation must be at least 100 characters long.")
                .MaximumLength(500)
                .WithMessage("Annotation cannot exceed 500 characters.");

            RuleFor(x => x.ISBN)
                .NotEmpty()
                .WithMessage("ISBN cannot be empty.")
                .Length(13)
                .WithMessage("ISBN must be exactly 13 characters long.");

            RuleFor(x => x.ReleaseDate)
               .NotEmpty()
               .WithMessage("ReleaseDate cannot be empty.");
        }
    }
}
using FluentValidation;
using ProductsOrganizer.Web.Products.Commands;

namespace ProductsOrganizer.Web.Products.Validation;

public class UpdateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .Length(5)
            .WithMessage("Code must be exactly 5 letters log");

        RuleFor(x => x.Description)
            .MaximumLength(150)
            .WithMessage("Description maximum length is 150 characters");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(40)
            .WithMessage("Product name length must be between 8 and 40 characters");

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("Price cannot be lesser than 1");
    }
}
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateProductRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        RuleFor(x => x.SegmentId).NotEmpty();
    }
}
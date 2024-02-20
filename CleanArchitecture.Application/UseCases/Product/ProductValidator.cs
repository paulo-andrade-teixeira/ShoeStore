using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.Product
{
    public sealed class ProductValidator : AbstractValidator<ProductEntity>
    {
        public ProductValidator() {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.SegmentId).NotEmpty();
        }
    }
}

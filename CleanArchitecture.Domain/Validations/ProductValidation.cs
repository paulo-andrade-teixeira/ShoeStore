using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Domain.Validations
{
    public class ProductValidation : AbstractValidator<ProductEntity>
    {
        public ProductValidation() {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.SegmentId).NotEmpty();
        }
    }
}

using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Domain.Validations
{
    public class BaseEntityValidation<T> : AbstractValidator<T> where T : IBaseEntity
    {
        public BaseEntityValidation() {
            RuleFor(x => x.Id).Must(id => !(id == Guid.Empty));
        }
    }
}

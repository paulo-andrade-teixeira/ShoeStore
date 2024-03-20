using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Validations;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class BaseEntity<TEntity> : IBaseEntity where TEntity : BaseEntity<TEntity>, IBaseEntity
    {
        private readonly List<AbstractValidator<TEntity>> _validationRules = new();

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            init
            {
                _id = value.Equals(Guid.Empty) ? Guid.NewGuid() : value;
            } 
        }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public bool IsDeleted { get; set; }
        protected void AddValidationRules(AbstractValidator<TEntity> validationRules) => _validationRules.Add(validationRules);
        public virtual void SetValidationRules()
        {
            AddValidationRules(new BaseEntityValidation<TEntity>());
        }
        public IEnumerable<AbstractValidator<TEntity>> GetValidationRules()
        {
            if (!_validationRules.Any())
                SetValidationRules();
            return _validationRules.ToList();
        }
        public async Task ValidateAndThrow()
        {
            List<ValidationFailure> errors = [];
            foreach (var validationRules in GetValidationRules())
            {
                var result = await validationRules.ValidateAsync((TEntity)this);
                errors.AddRange(result.Errors);
            }
            if (errors.Count != 0)
            {
                throw new DomainValidationException(typeof(TEntity).Name, errors.Select(e => e.ErrorMessage));
            }
        }
    }
}

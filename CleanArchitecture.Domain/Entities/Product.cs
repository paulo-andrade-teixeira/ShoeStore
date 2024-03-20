using CleanArchitecture.Domain.Validations;

namespace CleanArchitecture.Domain.Entities
{
    public class ProductEntity : BaseEntity<ProductEntity>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Code { get; init; }
        public double Price { get; init; }
        public Guid SegmentId { get; init; }
        public SegmentEntity Segment { get; init; }
        public override void SetValidationRules()
        {
            base.SetValidationRules();
            AddValidationRules(new ProductValidation());
        }

    }
}

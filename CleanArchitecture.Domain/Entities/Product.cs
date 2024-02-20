namespace CleanArchitecture.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Code { get; init; }
        public double Price { get; init; }
        public Guid SegmentId { get; init; }
        public SegmentEntity Segment { get; init; }
    }
}

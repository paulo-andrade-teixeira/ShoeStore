namespace CleanArchitecture.Domain.Entities
{
    public sealed class SegmentEntity : BaseEntity<SegmentEntity>
    {
        public string Name { get; set; }
    }
}
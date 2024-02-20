using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Code { get; init; }
        public double Price { get; init; }
        public Guid SegmentId { get; init; }
    }
}

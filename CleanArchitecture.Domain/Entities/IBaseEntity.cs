namespace CleanArchitecture.Domain.Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; init; }
        DateTimeOffset DateCreated { get; set; }
        DateTimeOffset? DateUpdated { get; set; }
        DateTimeOffset? DateDeleted { get; set; }
        bool IsDeleted { get; set; }
        Task ValidateAndThrow();
    }
}

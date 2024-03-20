using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity<T>, IBaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> Get(Guid id, CancellationToken cancellationToken);
        Task<List<T>?> GetAll(CancellationToken cancellationToken);
    }
}

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<List<ProductEntity>> GetByName(string name);
    }
}

using AutoMapper;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Product.GetAllProducts
{
    public sealed class GetAllProductsMapper : Profile
    {
        public GetAllProductsMapper() {
            CreateMap<ProductEntity, GetAllProductsResponse>();
            CreateMap<IEnumerable<ProductEntity>, IEnumerable<GetAllProductsResponse>>();
        }
    }
}

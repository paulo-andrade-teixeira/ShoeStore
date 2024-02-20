using AutoMapper;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public sealed class CreateProductMapper : Profile
    {
        public CreateProductMapper() 
        {
            CreateMap<CreateProductRequest, ProductEntity>();
            CreateMap<ProductEntity, CreateProductResponse>();
        }
    }
}

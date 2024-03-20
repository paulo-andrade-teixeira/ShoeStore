using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.DTOs.Mapper
{
    public sealed class ProductMapper : Profile
    {
        public ProductMapper() {
            CreateMap<ProductDTO, ProductEntity>();
            CreateMap<ProductEntity, ProductDTO>();
        }
    }
}

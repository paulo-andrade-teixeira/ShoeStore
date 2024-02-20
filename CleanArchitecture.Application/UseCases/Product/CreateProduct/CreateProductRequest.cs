using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Product.CreateProduct
{
    public sealed class CreateProductRequest : ProductDTO, IRequest<CreateProductResponse>
    {

    }
}

using CleanArchitecture.Application.DTOs;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Product.CreateProduct
{
    public sealed record GetProductByNameRequest(string Name) : IRequest<GetProductByNameResponse>;
}

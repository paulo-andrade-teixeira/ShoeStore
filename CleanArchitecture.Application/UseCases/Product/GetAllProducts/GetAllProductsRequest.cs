using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Product.GetAllProducts
{
    public sealed record class GetAllProductsRequest : IRequest<IEnumerable<GetAllProductsResponse>>;
}

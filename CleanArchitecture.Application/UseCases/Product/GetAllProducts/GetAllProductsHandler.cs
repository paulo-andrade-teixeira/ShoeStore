using AutoMapper;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Application.UseCases.Product.GetAllProducts;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetAllProductsResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            return products?.Select(p => _mapper.Map<GetAllProductsResponse>(p));
        }
    }
}

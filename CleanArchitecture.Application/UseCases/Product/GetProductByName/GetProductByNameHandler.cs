using AutoMapper;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameRequest, GetProductByNameResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByNameHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByNameResponse> Handle(GetProductByNameRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByNameAsync(request.Name);
            return _mapper.Map<GetProductByNameResponse>(product);
        }
    }
}

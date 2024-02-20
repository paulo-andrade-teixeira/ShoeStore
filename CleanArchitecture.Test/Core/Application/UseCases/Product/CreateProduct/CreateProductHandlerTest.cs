using AutoFixture;
using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CleanArchitecture.Tests.Core.Application.UseCases.Product.CreateProduct
{
    public class CreateProductHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        private Fixture _fixture = new Fixture();

        public CreateProductHandlerTest()
        {
            _serviceProvider = new TestServiceProvider().ServiceProvider;
            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _productRepository = _serviceProvider.GetRequiredService<IProductRepository>();
        }

        [Fact]
        public async Task Handle_Should_Return_Success_Result_When_Create_Product()
        {
           // Arrange
           var request = _fixture.Build<CreateProductRequest>()
                .Without(p => p.Id)
                .With(p => p.Name, "Chinelo Rider")
                .With(p => p.Description, "Chinelo Rider confortável")
                .With(p => p.Price, 22.0)
                .With(p => p.Code, "CHR4586")
                .With(p => p.SegmentId, Guid.NewGuid())
                .Create();

            // Act
            var handler = await new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);

            // Assert
            Assert.NotNull(handler);
            Assert.NotEqual(Guid.Empty, handler.Id);
        }
    }
}

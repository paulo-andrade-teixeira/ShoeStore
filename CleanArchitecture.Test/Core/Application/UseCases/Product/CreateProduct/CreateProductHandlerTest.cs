using AutoFixture;
using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Interfaces;
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
        private readonly Fixture _fixture = new();

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
                .With(p => p.Name)
                .With(p => p.Description, "Chinelo Rider confortável")
                .With(p => p.Price, 22.0)
                .With(p => p.Code, "CHR4586")
                .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                .Create();

            // Act
            var handler = await new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);

            // Assert
            Assert.NotNull(handler);
            Assert.NotEqual(Guid.Empty, handler.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Name_Is_Null_Or_Empty(string name)
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name, name)
                 .With(p => p.Description, "Chinelo Rider confortável")
                 .With(p => p.Price, 22.0)
                 .With(p => p.Code, "CHR4586")
                 .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Single(exception.ErrorMessages);
            Assert.Equal("ProductEntity", exception.Entity);
        }

        [Fact]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Description_Is_Null()
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name)
                 .Without(p => p.Description)
                 .With(p => p.Price, 22.0)
                 .With(p => p.Code, "CHR4586")
                 .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Single(exception.ErrorMessages);
            Assert.Equal("ProductEntity", exception.Entity);
        }

        [Fact]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Price_Is_Null()
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name)
                 .With(p => p.Description, "Chinelo Rider confortável")
                 .Without(p => p.Price)
                 .With(p => p.Code, "CHR4586")
                 .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(2, exception.ErrorMessages.Count());
            Assert.Equal("ProductEntity", exception.Entity);
        }

        [Fact]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Price_Is_Zero()
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name)
                 .With(p => p.Description, "Chinelo Rider confortável")
                 .With(p => p.Price, 0)
                 .With(p => p.Code, "CHR4586")
                 .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(2, exception.ErrorMessages.Count());
            Assert.Equal("ProductEntity", exception.Entity);
        }

        [Fact]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Price_Is_Less_Than_Zero()
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name)
                 .With(p => p.Description, "Chinelo Rider confortável")
                 .With(p => p.Price, -1)
                 .With(p => p.Code, "CHR4586")
                 .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Single(exception.ErrorMessages);
            Assert.Equal("ProductEntity", exception.Entity);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Code_Is_Null_Or_Empty(string code)
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name)
                 .With(p => p.Description, "Chinelo Rider confortável")
                 .With(p => p.Price, 22.0)
                 .With(p => p.Code, code)
                 .With(p => p.SegmentId, Guid.Parse("15e23d2e-febe-403b-87d8-dd745456f23d"))
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Single(exception.ErrorMessages);
            Assert.Equal("ProductEntity", exception.Entity);
        }

        [Fact]
        public async Task Handle_Should_Return_Business_Validation_Exception_When_Segment_Is_Null()
        {
            // Arrange
            var request = _fixture.Build<CreateProductRequest>()
                 .Without(p => p.Id)
                 .With(p => p.Name)
                 .With(p => p.Description, "Chinelo Rider confortável")
                 .With(p => p.Price, 22.2)
                 .With(p => p.Code, "CHR4586")
                 .With(p => p.SegmentId, Guid.Empty)
                 .Create();

            // Act
            Task<CreateProductResponse> handlerAction() => new CreateProductHandler(_unitOfWork, _productRepository, _mapper).Handle(request, default);
            var exception = await Assert.ThrowsAsync<DomainValidationException>((Func<Task<CreateProductResponse>>)handlerAction);

            // Assert
            Assert.NotNull(exception);
            Assert.Single(exception.ErrorMessages);
            Assert.Equal("ProductEntity", exception.Entity);
        }
    }
}

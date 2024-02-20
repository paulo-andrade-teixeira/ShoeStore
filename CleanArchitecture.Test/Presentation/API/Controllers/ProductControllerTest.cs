using AutoFixture;
using CleanArchitecture.API.Controllers;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace CleanArchitecture.Tests.Presentation.API.Controllers
{
    public class ProductControllerTest
    {
        Mock<IMediator> _mediator = new Mock<IMediator>();
        Fixture fixture = new Fixture();


        [Fact]
        public void Create_Product_Return_OK()
        {   
            //Arrange
            var request = fixture.Create<CreateProductRequest>();
            var response = fixture.Build<CreateProductResponse>()
                .With(r => r.Name, request.Name)
                .With(r => r.Code, request.Code)
                .With(r => r.Price, request.Price)
                .With(r => r.Id, Guid.NewGuid())
                .Create();
            _mediator.Setup(m => m.Send(request, default)).Returns(Task.FromResult(response));

            //Act
            var actionResult = new ProductController(_mediator.Object).Create(request).Result;
            var result = actionResult.Result as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(((int)HttpStatusCode.OK), result.StatusCode);
            Assert.IsType<CreateProductResponse>(result.Value);
            Assert.Equal(response.Id, ((CreateProductResponse)result.Value).Id);
        }

    }
}

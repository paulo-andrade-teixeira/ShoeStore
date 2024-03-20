using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.Product.CreateProduct;
using CleanArchitecture.Application.UseCases.Product.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Create (CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("name")]
        public async Task<ActionResult<GetProductByNameResponse>> GetByName(GetProductByNameRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllProductsResponse>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new GetAllProductsRequest(), cancellationToken);
            return Ok(response);
        }
    }
}

using Application.Contracts.Services.Poducts;
using Application.Dtos.Products;
using Application.Features.Products.Requests.Commands;
using Application.Features.Products.Requests.Queries;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rayanbourse.Api.Controllers.Base;
using System.Threading;

namespace Rayanbourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("AddProduct")]
        [Authorize]
        public async Task<OperationResult<bool>> AddProduct(CreateProductDto createProductDto, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new CreateProductCommand() { CreateProduct = createProductDto }, cancellationToken);

        }
        [HttpPut("UpdateProduct")]
        [Authorize]
        public async Task<OperationResult<bool>> UpdateProduct(UpdateProductDto updateProduct, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new UpdateProductCommand() { UpdateProduct = updateProduct }, cancellationToken);
        }
        [HttpDelete("DeleteProduct")]
        [Authorize]
        public async Task<OperationResult<bool>> DeleteProduct(DeleteProductDto deleteProduct, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new DeleteProductCommand() { DeleteProduct = deleteProduct }, cancellationToken);
        }
        [HttpGet("GetAll")]
        public async Task<List<ProductDto>> GetAll([FromQuery] Guid? id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllProductByCreatorQuery() { CreatorId = id });
        }
    }
}

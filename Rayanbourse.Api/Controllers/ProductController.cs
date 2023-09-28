using Application.Contracts.Services.Poducts;
using Application.Dtos.Products;
using Application.Response;
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
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("AddProduct")]
        [Authorize]
        public async Task<OperationResult<bool>> AddProduct(CreateProductDto createProductDto, CancellationToken cancellationToken)
        {
            return await _productService.Add(createProductDto, cancellationToken);
        }
        [HttpPut("UpdateProduct")]
        [Authorize]
        public async Task<OperationResult<bool>> UpdateProduct(UpdateProductDto updateProduct, CancellationToken cancellationToken)
        {
            return await _productService.Update(updateProduct, cancellationToken);

        }
        [HttpDelete("DeleteProduct")]
        [Authorize]
        public async Task<OperationResult<bool>> DeleteProduct(DeleteProductDto deleteProduct, CancellationToken cancellationToken)
        {
            return await _productService.Delete(deleteProduct, cancellationToken);

        }
        [HttpGet("GetAll")]
        public async Task<List<ProductDto>> GetAll([FromQuery] Guid? id, CancellationToken cancellationToken)
        {
            var result = await _productService.GetAllbyCreatorId(id, cancellationToken);
            return result.ToList();
        }
    }
}

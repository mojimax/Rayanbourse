using Application.Contracts.Services.Poducts;
using Application.Features.Products.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, OperationResult<bool>>
    {
        private readonly IProductService _productService;
        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<OperationResult<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.Delete(request.DeleteProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

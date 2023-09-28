using Application.Contracts.Services.Poducts;
using Application.Features.Products.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.Products.Handlers.Commands
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, OperationResult<bool>>
    {
        private readonly IProductService _productService;
        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<OperationResult<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.Update(request.UpdateProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

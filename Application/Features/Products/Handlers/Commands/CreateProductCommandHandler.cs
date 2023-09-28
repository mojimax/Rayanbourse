using Application.Contracts.Services.Poducts;
using Application.Features.Products.Requests.Commands;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, OperationResult<bool>>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<OperationResult<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.Add(request.CreateProduct, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

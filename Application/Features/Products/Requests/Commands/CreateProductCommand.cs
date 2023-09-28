using Application.Dtos.Products;
using Application.Response;
using MediatR;

namespace Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand : IRequest<OperationResult<bool>>
    {
        public CreateProductDto CreateProduct { get; set; }
    }
}

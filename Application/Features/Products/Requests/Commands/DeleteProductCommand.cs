using Application.Dtos.Products;
using Application.Response;
using MediatR;

namespace Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest<OperationResult<bool>>
    {
        public DeleteProductDto DeleteProduct { get; set; }

    }
}

using Application.Dtos.Products;
using Application.Response;
using MediatR;

namespace Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommand:IRequest<OperationResult<bool>> 
    {
        public UpdateProductDto UpdateProduct { get; set; }

    }
}

using Application.Dtos.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Requests.Queries
{
    public class GetAllProductByCreatorQuery : IRequest<List<ProductDto>>
    {
        public Guid? CreatorId { get; set; }

    }
}

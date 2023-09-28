using Application.Contracts.Services.Poducts;
using Application.Dtos.Products;
using Application.Features.Products.Requests.Queries;
using MediatR;

namespace Application.Features.Products.Handlers.Queries
{
    public class GetAllProductByCreatorQueryHandler : IRequestHandler<GetAllProductByCreatorQuery, List<ProductDto>>
    {
        private readonly IProductService _productService;

        public GetAllProductByCreatorQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductByCreatorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productService.GetAllbyCreatorId(request.CreatorId);
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

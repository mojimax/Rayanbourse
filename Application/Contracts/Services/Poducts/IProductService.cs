using Application.Dtos.Products;
using Application.Response;

namespace Application.Contracts.Services.Poducts
{
    public interface IProductService
    {
        Task<OperationResult<bool>> Add(CreateProductDto createproduct,CancellationToken cancellationToken=default);
        Task<OperationResult<bool>> Update(UpdateProductDto updateProduct, CancellationToken cancellationToken = default);
        Task<OperationResult<bool>> Delete(DeleteProductDto deleteproduct, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetAllbyCreatorId(Guid? creatorId, CancellationToken cancellationToken = default);
    }
}

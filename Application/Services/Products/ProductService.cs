using Application.Contracts.General;
using Application.Contracts.Persistence.Products;
using Application.Contracts.Services.Poducts;
using Application.Dtos.Products;
using Application.Response;
using AutoMapper;
using Common.Enums;
using Domain.Products;
using FluentValidation;

namespace Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IResponseHelperService _responseHelperService;
        private readonly IValidator<CreateProductDto> _productValidator;
        private readonly IValidator<UpdateProductDto> _updateproductValidator;
        private readonly IValidator<DeleteProductDto> _deleteproductValidator;
        public ProductService(IProductRepository repository, IMapper mapper, IResponseHelperService responseHelperService, IValidator<CreateProductDto> productValidator, IValidator<UpdateProductDto> updateproductValidator, IValidator<DeleteProductDto> deleteproductValidator)
        {
            _productRepository = repository;
            _mapper = mapper;
            _responseHelperService = responseHelperService;
            _productValidator = productValidator;
            _updateproductValidator = updateproductValidator;
            _deleteproductValidator = deleteproductValidator;
        }
        public async Task<IEnumerable<ProductDto>> GetAllbyCreatorId(Guid? creatorId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _productRepository.GetAllAsync(x =>
                x.IsAvailable
                && (creatorId != null && x.CreateById == creatorId.ToString())
                || (creatorId == null) && true,cancellationToken);
                return _mapper.Map<List<ProductDto>>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResult<bool>> Add(CreateProductDto product, CancellationToken cancellationToken = default)
        {
            var response = await _responseHelperService.CreateInstance<bool>(ResultStatusCodeEnum.Success);
            response.Data = false;
            try
            {
                var validationResult = await _productValidator.ValidateAsync(product);
                if (validationResult.IsValid)
                {
                    var model = _mapper.Map<Product>(product);
                    await _productRepository.AddAsync(model, cancellationToken);
                    response.Data = true;
                }
                else
                {
                    response = await _responseHelperService.HandleValidation(response, validationResult);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        public async Task<OperationResult<bool>> Update(UpdateProductDto product, CancellationToken cancellationToken = default)
        {
            var response = await _responseHelperService.CreateInstance<bool>(ResultStatusCodeEnum.Success);
            response.Data = false;
            try
            {
                var validationResult = await _updateproductValidator.ValidateAsync(product);
                if (validationResult.IsValid)
                {
                    var model = _mapper.Map<Product>(product);
                    var result = await _productRepository.UpdateAsync(model, cancellationToken);
                    response.Data = true;
                }
                else
                {
                    response = await _responseHelperService.HandleValidation(response, validationResult);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        public async Task<OperationResult<bool>> Delete(DeleteProductDto deleteproduct, CancellationToken cancellationToken = default)
        {
            var response = await _responseHelperService.CreateInstance<bool>(ResultStatusCodeEnum.Success);
            response.Data = false;
            try
            {
                var validationResult = await _deleteproductValidator.ValidateAsync(deleteproduct);
                if (validationResult.IsValid)
                {
                    await _productRepository.DeleteAsync(deleteproduct.Id, cancellationToken);
                    response.Data = true;
                }
                else
                {
                    response = await _responseHelperService.HandleValidation(response, validationResult);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }
    }
}

using Application.Response;
using Common.Enums;
using FluentValidation.Results;
namespace Application.Contracts.General
{
    public interface IResponseHelperService
    {
        Task<OperationResult<TData>> CreateInstance<TData>(ResultStatusCodeEnum resultStatusCodeEnum = ResultStatusCodeEnum.Success);
        Task<OperationResult<TData>> HandleException<TData>(OperationResult<TData> response, Exception exception);
        Task<OperationResult<TData>> HandleValidation<TData>(OperationResult<TData> response, ValidationResult validationResult);
    }
}

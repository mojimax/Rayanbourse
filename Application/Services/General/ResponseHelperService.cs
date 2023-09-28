using Application.Contracts.General;
using Application.Response;
using Common.Enums;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.General
{
    public class ResponseHelperService : IResponseHelperService
    {
        private readonly ILogger<ResponseHelperService> _logger;
        public ResponseHelperService(ILogger<ResponseHelperService> logger)
        {
            _logger = logger;
        }
        public async Task<OperationResult<TData>> CreateInstance<TData>(ResultStatusCodeEnum resultStatusCodeEnum = ResultStatusCodeEnum.Success)
        {
            return new OperationResult<TData>
            {
                IsSuccess = true,
                ResultStatusList = new List<ResultStatusModel>
                {
                    new ResultStatusModel(resultStatusCodeEnum){}
                },
            };
        }

        public async Task<OperationResult<TData>> HandleValidation<TData>(OperationResult<TData> response, ValidationResult validationResult)
        {
            try
            {
                var errors = new List<ResultStatusModel>();
                foreach (var error in validationResult.Errors)
                {
                    var res = (ResultStatusCodeEnum)Enum.Parse(typeof(ResultStatusCodeEnum), error.ErrorMessage, true);
                    errors.Add(new ResultStatusModel(res));
                }
                response.ResultStatusList = errors;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<OperationResult<TData>> HandleException<TData>(OperationResult<TData> response, Exception exception)
        {
            _logger.LogError(exception.Message);
            response.Exception = exception;
            response.ResultStatusList = new List<ResultStatusModel>()
            {
                new ResultStatusModel(Common.Enums.ResultStatusCodeEnum.Exception){}
            };
            response.IsSuccess = false;
            return response;
        }
    }
}

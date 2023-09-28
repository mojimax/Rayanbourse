using Common.Enums;
using System.Diagnostics;

namespace Application.Response
{
    public class OperationResult<TData>
    {
        public OperationResult()
        {
            var stackTrace = new StackTrace();
            Location = stackTrace.GetFrame(1).GetMethod().ReflectedType.FullName;
        }
        public OperationResult(bool isSuccess, List<ResultStatusModel> resultStatusList, TData data) : this()
        {
            IsSuccess = isSuccess;
            ResultStatusList = resultStatusList;
            Data = data;
        }
        public OperationResult(bool isSuccess, List<ResultStatusModel> resultStatusList, TData data, string? message, Exception? exception) : this(isSuccess, resultStatusList, data)
        {
            Message = message;
        }

        #region Property
        /// <summary>
        /// نتیجه عملیات یک متد 
        /// در صورت استثنا =false
        /// در صورت درست اجرا شدن=true
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// لیستی از وضعیت ها اتفاق افتاده
        /// </summary>
        public List<ResultStatusModel> ResultStatusList { get; set; }
        /// <summary>
        /// در صورت بروز اتفاق افتادن استثنا
        /// </summary>
        public Exception? Exception { get; set; }
        /// <summary>
        /// مکان فعلی مقدار بازگشتی
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// پیغام 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// نوع داده خروجی(به صورت داینامیک)
        /// </summary>
        public TData Data { get; set; }

        #endregion
    }

    public class ResultStatusModel
    {

        public ResultStatusCodeEnum StatusCode { get; set; }
        public string StatusCodeKey { get; }


        public ResultStatusModel(ResultStatusCodeEnum StatusCode)
        {
            this.StatusCode = StatusCode;
            StatusCodeKey = StatusCode.ToString();
        }
    }
}

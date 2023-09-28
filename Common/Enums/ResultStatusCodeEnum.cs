using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ResultStatusCodeEnum
    {
        Success = 0,
        ServerError = 1,
        BadRequest = 2,
        NotFound = 3,
        Exception = 4,
        UserNotExsist = 5,
        UserNameInvalid = 6,
        PasswordNotNull = 7,
        PhoneNumberInvalid = 8,
        EmailInvalid = 9,
        UserNameExsist = 10,
        PasswordInvalid = 11,
        Unauthorized = 12,
        UserPassInvalid = 13,
        CreateUserError = 14,
        SuccessRegister = 15,
        SuccessLogin = 16,
        SuccessSendCode = 17,
        NameRequired = 18,
        UserNotAccess = 19,
        DuplicateProduct = 20,
        ProductIdInvalid = 21,
    }
}

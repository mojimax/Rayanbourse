using Application.Contracts.General;
using Application.Contracts.Services.Users;
using Application.Response;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users
{
    public class UserService : IUserSerive
    {
        #region Fields
        private readonly IResponseHelperService _responseHelper;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Ctor
        public UserService(IResponseHelperService responseHelper, UserManager<User> userManager)
        {
            _responseHelper = responseHelper;
            _userManager = userManager;
        }
        #endregion
        #region Method
        public async Task<OperationResult<bool>> ExsistEmail(string email)
        {
            var response = await _responseHelper.CreateInstance<bool>();
            response.Data = false;

            var user = await _userManager.FindByEmailAsync(email);
            response.Data = user != null;

            return response;
        }
        #endregion

    }
}

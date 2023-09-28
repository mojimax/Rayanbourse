using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services.Users
{
    public interface IUserSerive
    {
        Task<OperationResult<bool>> ExsistEmail(string email);

    }
}

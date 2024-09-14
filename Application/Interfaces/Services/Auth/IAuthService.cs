using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<Result> ValidateUser(UserLogin userLogin);

        string GenerateJwtToken(User user);
    }
}

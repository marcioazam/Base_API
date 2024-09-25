using Application.Security;
using Domain.Entities;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Security
{
    public interface IAuthService
    {
        Task<Result> ValidateUser(Login userLogin);

        Tuple<string, DateTime> GenerateJwtToken(User user);

        RefreshToken GenerateRefreshToken(long userId);
    }
}

using Application.DTOs.Filters;
using Application.Interfaces.Services.Base;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITokenService : IServiceBase
    {
        Task<Result> RefreshTokenValidate(RefreshTokenFilterDTO filter);
    }
}

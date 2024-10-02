using Application.DTOs.Filters;
using Application.Interfaces.Services;
using Application.Security;
using Application.Services.Base;
using Domain.Entities;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    #pragma warning disable CS9107 // O parâmetro é capturado no estado do tipo delimitador e seu valor também é passado para o construtor base. O valor também pode ser capturado pela classe base.
    public class TokenService(ITokenRepository repository, IConfiguration configuration) : ServiceBase<ITokenRepository, Token>(repository), ITokenService
    #pragma warning restore CS9107 // O parâmetro é capturado no estado do tipo delimitador e seu valor também é passado para o construtor base. O valor também pode ser capturado pela classe base.
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<Result> RefreshTokenValidate(TokenRequest tokenRequest)
        {
            Result result = new(null, []);

            RefreshTokenFilterDTO filter = new() { RefreshToken = tokenRequest.RefreshToken };

            var token = await repository.Get<Token, RefreshTokenFilterDTO>(filter);

            if (token == null)
            {
                result.AddError(GlobalError.NotFound);

                return result;
            }

            if (DateTime.UtcNow >= token.Expiry)
            {
                result.AddError(GlobalError.RefreshTokenExpired);

                return result;
            }

            if (token.IsTokenExpired(SecurityHelper.GetExpiryToken(_configuration["Jwt:ExpiryHours"])) == false || token.IsRevoked)
            {
                result.AddError(GlobalError.RequestMalicious);

                return result;
            }

            result = new(token, []);

            return result;
        }
    }
}

using Application.DTOs.Filters;
using Application.Interfaces.Services;
using Application.Services.Base;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService(ITokenRepository repository) : ServiceBase<ITokenRepository, Token>(repository), ITokenService
    {
        public async Task<Result> RefreshTokenValidate(RefreshTokenFilterDTO filter) 
        {
            var token = await repository.Get<Token, RefreshTokenFilterDTO>(filter);

            if (token != null)
            {
                if(token.AcessTokenExpiry > DateTime.UtcNow)
                {
                    if(token.RefreshTokenExpiry > DateTime.UtcNow)
                    {

                    }
                    else
                    {
                        // Refreshtoken expirado
                    }
                }
                else
                {
                    // Pedido de token antes do tempo, possivel tentativa de invasao
                }

                // Token nao encontrado 
            }

            return null;
        }
    }
}

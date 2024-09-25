using Domain.Abstracts.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.TokensCommands
{
    public class TokenInsertCommand(string refreshToken, long userId, DateTime acessTokenExpiry, DateTime refreshTokenExpiry, bool isRevoked) : BaseInsertCommand, IRequest<Result>
    {
        public string RefreshToken { get; set; } = refreshToken;

        public long UserId { get; set; } = userId;

        public DateTime AcessTokenExpiry { get; set; } = acessTokenExpiry;

        public DateTime RefreshTokenExpiry { get; set; } = refreshTokenExpiry;

        public bool IsRevoked { get; set; } = isRevoked;
    }
}

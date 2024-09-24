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
    public class TokenInsertCommand(string token, long userId, DateTime expiryDate, bool isRevoked) : BaseInsertCommand, IRequest<Result>
    {
        public string RefreshToken { get; set; } = token;

        public long UserId { get; set; } = userId;

        public DateTime ExpiryDate { get; set; } = expiryDate;

        public bool IsRevoked { get; set; } = isRevoked;
    }
}

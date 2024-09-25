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
    public class TokenUpdateRevokedCommand(long id) : BaseUpdateCommand(id), IRequest<Result>
    {
        public bool IsRevoked { get; set; } = true;
    }
}

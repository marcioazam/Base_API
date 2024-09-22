using Domain.Abstracts.Command.Base;
using Domain.EnumTypes;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.UsersCommands
{
    public class UserUpdateCommand(long id, bool active) : BaseUpdateCommand(id), IRequest<Result>
    {
        public bool Active { get; set; } = active;
    }
}

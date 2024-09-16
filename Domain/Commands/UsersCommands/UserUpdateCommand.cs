using Domain.Interfaces.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.UsersCommands
{
    public class UserUpdateCommand(long id, bool active) : IRequest<Result>, IBaseUpdateCommand
    {
        public long Id { get; set; } = id;

        public bool Active { get; set; } = active;
    }
}

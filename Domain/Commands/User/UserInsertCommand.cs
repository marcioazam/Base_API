using Domain.Interfaces.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User
{
    public class UserInsertCommand(string username, string password, bool active) : IRequest<Result>, IBaseInsertCommand
    {
        public string Username { get; set; } = username;

        public string Password { get; set; } = password;

        public bool Active { get; set; } = active;
    }
}

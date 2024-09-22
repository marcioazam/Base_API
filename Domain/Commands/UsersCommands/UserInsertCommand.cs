using BCrypt.Net;
using Domain.Abstracts.Command.Base;
using Domain.Entities;
using Domain.EnumTypes;
using Domain.Interfaces.Entities.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Commands.UsersCommands
{
    public class UserInsertCommand(string username, string passwordNoHash, bool active) : BaseInsertCommand, IRequest<Result>
    {
        public required string Username { get; set; } = username;

        public required string PasswordNoHash { get; set; } = passwordNoHash;

        public required bool Active { get; set; } = active;
    }
}

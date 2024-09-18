using BCrypt.Net;
using Domain.Entities;
using Domain.Interfaces.Command.Base;
using Domain.Interfaces.Entities.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.UsersCommands
{
    public class UserInsertCommand(string username, string passwordNoHash, bool active) : IRequest<Result>, IBaseInsertCommand<User>
    {
        public required string Username { get; set; } = username;

        public required string PasswordNoHash { get; set; } = passwordNoHash;

        public required bool Active { get; set; } = active;

        public async Task<ResultError> ExecuteBusinnesRulesBeforeOperations(User entity)
        {
            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordNoHash);

            return null;
        }

        public async Task<ResultError> ExecuteBusinnesRuleAfterOperations(User entity)
        {
            return null;
        }
    }
}

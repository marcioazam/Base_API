using Domain.Commands.Base;
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

namespace Domain.Commands.ClientesCommands
{
    public class ClienteInsertCommand(string nome, string email, char sexo, string? endereco = null) : IRequest<Result>, IBaseInsertCommand<Cliente>
    {
        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;

        public Task<ResultError> ExecuteBusinnesRulesBeforeOperations(Cliente entity)
        {
            return null;
        }

        public Task<ResultError> ExecuteBusinnesRuleAfterOperations(Cliente entity)
        {
            return null;
        }
    }
}

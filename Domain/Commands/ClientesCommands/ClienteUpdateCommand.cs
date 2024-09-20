using Domain.Commands.Base;
using Domain.Interfaces.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.ClientesCommands
{
    public class ClienteUpdateCommand(long id, string nome, string email, char sexo, string? endereco = null) : IBaseUpdateCommand(id), IRequest<Result>
    {
        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;
    }
}

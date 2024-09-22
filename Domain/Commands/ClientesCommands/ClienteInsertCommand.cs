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

namespace Domain.Commands.ClientesCommands
{
    public class ClienteInsertCommand(string nome, string email, char sexo, string? endereco = null) : BaseInsertCommand, IRequest<Result>
    {
        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;
    }
}

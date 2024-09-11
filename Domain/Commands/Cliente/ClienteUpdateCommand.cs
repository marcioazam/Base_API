using Domain.Commands.Base;
using Domain.Interfaces.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Cliente
{
    public class ClienteUpdateCommand(long id, string nome, string email, char sexo, string? endereco = null) : IRequest<Result>, IBaseUpdateCommand
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;
    }
}

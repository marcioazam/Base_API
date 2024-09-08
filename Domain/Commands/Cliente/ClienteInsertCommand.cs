﻿using Domain.Commands.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Cliente
{
    public class ClienteInsertCommand(string nome, string email, char sexo, string? endereco = null) : IRequest<CommandResult>
    {
        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereço { get; set; } = endereco;
    }
}

﻿using Domain.Abstracts.Command.Base;
using Domain.EnumTypes;
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
    public class ClienteUpdateCommand(long id, string nome, string email, char sexo, string? endereco = null) : BaseUpdateCommand(id), IRequest<Result>
    {
        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;
    }
}

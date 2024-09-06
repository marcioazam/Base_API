﻿using Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.EnumTypes;
using FluentValidation.Results;
using Domain.Validators;

namespace Domain.Commands.Supplier
{
    public class SupplierUpdateCommand(long id, string nome, string apiUrl, string apiKey) : IRequest<CommandResult>
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;

        public string ApiUrl { get; set; } = apiUrl;

        public string ApiKey { get; set; } = apiKey;
    }
}

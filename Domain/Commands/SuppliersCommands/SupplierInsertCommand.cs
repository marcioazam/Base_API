﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.EnumTypes;
using FluentValidation.Results;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;
using Domain.Interfaces.Entities.Base;
using Domain.Entities;
using Domain.Abstracts.Command.Base;

namespace Domain.Commands.SuppliersCommands
{
    public class SupplierInsertCommand(string nome, string apiUrl, string apiKey) : BaseInsertCommand, IRequest<Result>
    {
        public string Nome { get; set; } = nome;

        public string ApiUrl { get; set; } = apiUrl;

        public string ApiKey { get; set; } = apiKey;
    }
}

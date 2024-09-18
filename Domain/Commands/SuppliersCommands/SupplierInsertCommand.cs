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
using Domain.ValueObjects.ResultInfo;
using Domain.Interfaces.Command.Base;
using Domain.Interfaces.Entities.Base;
using Domain.Entities;

namespace Domain.Commands.SuppliersCommands
{
    public class SupplierInsertCommand(string nome, string apiUrl, string apiKey) : IRequest<Result>, IBaseInsertCommand<Supplier>
    {
        public string Nome { get; set; } = nome;

        public string ApiUrl { get; set; } = apiUrl;

        public string ApiKey { get; set; } = apiKey;

        public Task<ResultError> ExecuteBusinnesRulesBeforeOperations(Supplier entity) 
        {
            return null;
        }

        public Task<ResultError> ExecuteBusinnesRuleAfterOperations(Supplier entity) 
        {
            return null;
        }
    }
}

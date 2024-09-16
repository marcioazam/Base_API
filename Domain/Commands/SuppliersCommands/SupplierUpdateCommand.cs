using Domain.Commands.Base;
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

namespace Domain.Commands.SuppliersCommands
{
    public class SupplierUpdateCommand(long id, string nome, string apiUrl, string apiKey) : IRequest<Result>, IBaseUpdateCommand
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;

        public string ApiUrl { get; set; } = apiUrl;

        public string ApiKey { get; set; } = apiKey;
    }
}

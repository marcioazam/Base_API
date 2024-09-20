using Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;

namespace Domain.Entities
{
    public class Supplier(long id, string apiUrl, string nome, string apiKey) : IEntity
    {
        public long Id { get; set; } = id;

        public string ApiUrl { get; set; } = apiUrl;

        public string Nome { get; set; } = nome;

        public string ApiKey { get; set; } = apiKey;

        public Task ExecuteBusinnesRuleAfterOperations<IBaseInsertCommand>()
        {
            return Task.CompletedTask;
        }

        public Task<Result> ExecuteBusinnesRulesBeforeOperations<IBaseInsertCommand>(Result result)
        {
            return Task.FromResult(result);
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new SupplierValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

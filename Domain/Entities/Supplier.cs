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

        public async Task<Result> ExecuteBusinnesRuleAfterOperations(Result result)
        {
            return result;
        }

        public async Task<Result> ExecuteBusinnesRulesBeforeOperations(Result result)
        {
            return result;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new SupplierValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

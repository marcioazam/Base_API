using Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;
using Domain.Interfaces.Command.Base;

namespace Domain.Entities
{
    public class Supplier(long id, string apiUrl, string nome, string apiKey) : IEntity
    {
        public long Id { get; set; } = id;

        public string ApiUrl { get; set; } = apiUrl;

        public string Nome { get; set; } = nome;

        public string ApiKey { get; set; } = apiKey;

        public Task ExecuteBusinnesRulesAfterOperations(IBaseInsertCommand insertCommand)
        {
            return Task.CompletedTask;
        }

        public Task ExecuteBusinnesRulesAfterOperations(IBaseUpdateCommand insertCommand)
        {
            return Task.CompletedTask;
        }

        public Task ExecuteBusinnesRulesAfterOperations(IBaseDeleteCommand deleteCommand)
        {
            return Task.CompletedTask;
        }

        public Task<Result> ExecuteBusinnesRulesBeforeOperations(IBaseInsertCommand insertCommand)
        {
            Result result = new(null, []);

            return Task.FromResult(result);
        }

        public Task<Result> ExecuteBusinnesRulesBeforeOperations(IBaseUpdateCommand insertCommand)
        {
            Result result = new(null, []);

            return Task.FromResult(result);
        }

        public Task<Result> ExecuteBusinnesRulesBeforeOperations(IBaseDeleteCommand deleteCommand)
        {
            Result result = new(null, []);

            return Task.FromResult(result);
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new SupplierValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

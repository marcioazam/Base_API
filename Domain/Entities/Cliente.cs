using Domain.Interfaces.Command.Base;
using Domain.Interfaces.Entities.Base;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente(long id, string nome, string email, char sexo, string? endereco = null) : IEntity
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;

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
            var validator = new ClienteValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

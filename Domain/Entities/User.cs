using Domain.Interfaces.Command.Base;
using Domain.Interfaces.Entities.Base;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public User() { }

        public User(long id, string username, bool active, string passwordHash)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Active = active;
        }

        public required long Id { get; set; }

        public required string Username { get; set; }

        public required string PasswordHash { get; set; }   

        public required bool Active { get; set; }

        [JsonIgnore]
        public string? PasswordNoHash { get; set; }

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

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordNoHash);

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
            var validator = new UserValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

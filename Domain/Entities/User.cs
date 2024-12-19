using Domain.Abstracts.Command.Base;
using Domain.Entities.Base;
using Domain.EnumTypes;
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
    public class User : EntityBusinessRules, IEntity
    {
        public required long Id { get; set; }

        public required string Username { get; set; }

        public required string PasswordHash { get; set; }

        public required bool Active { get; set; }

        public List<int> Roles { get; set; }

        [JsonIgnore]
        public string? PasswordNoHash { get; set; }

        private protected override Result InsertCommandBeforeOperation(Result result)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(PasswordNoHash);

            return result;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UserValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

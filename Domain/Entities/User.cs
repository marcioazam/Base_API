using Domain.Entities.Base;
using Domain.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User(string userName, string passwordHash, bool active) : EntityBase
    {
        public string Username { get; set; } = userName;

        public string PasswordNoHash { get; set; } = passwordHash;

        public bool Active { get; set; } = active;

        public override Task<ValidationResult> Validate()
        {
            var validator = new UserValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

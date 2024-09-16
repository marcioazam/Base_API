using Domain.Interfaces.Entities.Base;
using Domain.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User(long id, string userName, string passwordHash, bool active) : IEntity
    {
        public long Id { get; set; } = id;

        public string Username { get; set; } = userName;

        public string PasswordHash { get; set; } = passwordHash;      

        public bool Active { get; set; } = active;

        public string? PasswordNoHash { get; set; }

        public Task<ValidationResult> Validate()
        {
            var validator = new UserValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

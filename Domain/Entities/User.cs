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
    public class User : IEntity
    {
        public User(string username, bool active, string passwordHash, string? passwordNoHash = null)
        {
            Username = username;
            PasswordHash = passwordHash;
            Active = active;
            PasswordNoHash = passwordNoHash;
        }

        public long Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }   

        public bool Active { get; set; }

        public string? PasswordNoHash { get; set; }

        public Task<ValidationResult> Validate()
        {
            var validator = new UserValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

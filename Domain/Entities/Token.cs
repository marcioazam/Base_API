using Domain.Entities.Base;
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
    public class Token : EntityBusinessRules, IEntity
    {
        public required long Id { get; set; }

        public required string RefreshToken { get; set; }

        public required long UserId { get; set; }

        public required DateTime ExpiryDate { get; set; }

        public required bool IsRevoked { get; set; }

        public Task<ValidationResult> Validate()
        {
            var validator = new TokenValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

using Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;
using Domain.Abstracts.Command.Base;
using Domain.EnumTypes;
using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Supplier : BaseEntity, IEntity
    {
        public required long Id { get; set; } 

        public required string ApiUrl { get; set; } 

        public required string Nome { get; set; } 

        public required string ApiKey { get; set; } 

        public Task<ValidationResult> Validate()
        {
            var validator = new SupplierValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

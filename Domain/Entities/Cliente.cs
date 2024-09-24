using Domain.Abstracts.Command.Base;
using Domain.Entities.Base;
using Domain.EnumTypes;
using Domain.Interfaces.Entities.Base;
using Domain.Validators;
using Domain.ValueObjects.ResultInfo;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : EntityBusinessRules, IEntity
    {
        public required long Id { get; set; } 

        public required string Nome { get; set; } 

        public required string Email { get; set; } 

        public required char Sexo { get; set; }

        public string? Endereco { get; set; } 

        public Task<ValidationResult> Validate()
        {
            var validator = new ClienteValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

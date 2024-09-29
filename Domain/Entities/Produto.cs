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
    public class Produto : EntityBusinessRules, IEntity
    {
        public required long Id { get; set; }

        public required string Nome { get; set; }

        public required decimal Valor { get; set; }

        public required bool Ativo { get; set; }

        public Task<ValidationResult> Validate()
        {
            var validator = new ProdutoValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

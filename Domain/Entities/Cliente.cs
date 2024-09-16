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
    public class Cliente(long id, string nome, string email, char sexo, string? endereco = null) : IEntity
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;

        public string Email { get; set; } = email;

        public char Sexo { get; set; } = sexo;

        public string? Endereco { get; set; } = endereco;     

        public Task<ValidationResult> Validate()
        {
            var validator = new ClienteValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

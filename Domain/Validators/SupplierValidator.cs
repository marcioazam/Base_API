using Domain.Commands.Supplier;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(command => command.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

            RuleFor(command => command.ApiUrl)
                .NotEmpty().WithMessage("A URL da API é obrigatória.")
                .Length(20, 50).WithMessage("A URL da API deve ter entre 20 e 50 caracteres.");

            RuleFor(command => command.ApiKey)
                .NotEmpty().WithMessage("A chave da API é obrigatória.")
                .MinimumLength(3).WithMessage("A chave da API deve ter no mínimo 3 caracteres.");
        }
    }
}

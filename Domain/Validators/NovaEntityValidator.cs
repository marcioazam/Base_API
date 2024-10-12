using Domain.Entities;
using FluentValidation;
using Domain.EnumTypes;
using Domain.Helpers;

namespace Domain.Validators
{
    public class NovaEntityValidator : AbstractValidator<NovaEntity>
    {
        public NovaEntityValidator()
        {
            RuleFor(entity => entity.Id)
                .NotEmpty().WithMessage(BuildErrorHelper.BuildError(GlobalError.RequiredProperty, "Id"));

            RuleFor(entity => entity.Nome)
                .NotEmpty().WithMessage(BuildErrorHelper.BuildError(GlobalError.RequiredProperty, "Nome"));

            RuleFor(entity => entity.Preco)
                .NotEmpty().WithMessage(BuildErrorHelper.BuildError(GlobalError.RequiredProperty, "Preco"));

            RuleFor(entity => entity.Quantidade)
                .NotEmpty().WithMessage(BuildErrorHelper.BuildError(GlobalError.RequiredProperty, "Quantidade"));
        }
    }
}
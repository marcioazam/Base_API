using Application.DTOs.Validation;
using Application.Interfaces.Factories;
using Domain.Helpers;
using Domain.Interfaces.Entities.Base;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Application.Factories
{
    public class ValidationFactory(IServiceProvider serviceProvider) : IValidationFactory
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public List<ValidationRuleDTO> ExtractValidationRules<T>() where T : IEntity
        {
            var validationRules = new List<ValidationRuleDTO>();

            var validator = _serviceProvider.GetRequiredService<IValidator<T>>();

            // Obtém todas as regras de validação para a entidade
            var descriptor = validator.CreateDescriptor();

            // Percorre cada propriedade e suas respectivas regras
            foreach (var propertyRules in descriptor.GetMembersWithValidators())
            {
                var propertyName = propertyRules.Key;
                var rules = propertyRules;

                foreach (var rule in rules)
                {
                    var validatorInstance = rule.Validator;
                    var errorMessage = rule.Options.GetUnformattedErrorMessage();

                    var ruleDTO = new ValidationRuleDTO(
                        propertyName,
                        RegexHelper.CleanTypeName(validatorInstance.GetType().Name).Replace("Validator", ""),
                        errorMessage,
                        ExtractRuleValue(validatorInstance)
                    );

                    validationRules.Add(ruleDTO);
                }
            }

            return validationRules;
        }

        private object? ExtractRuleValue(IPropertyValidator validator)
        {
            // Identifica tipos específicos de validação e extrai o valor da regra, se aplicável.
            if (validator is ILengthValidator lengthValidator)
            {
                return new { Min = lengthValidator.Min, Max = lengthValidator.Max };
            }
            else if (validator is IComparisonValidator comparisonValidator)
            {
                return new { ValueToCompare = comparisonValidator.ValueToCompare };
            }

            return null;
        }
    }
}

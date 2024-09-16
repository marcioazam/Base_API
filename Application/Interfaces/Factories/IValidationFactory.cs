using Application.DTOs.Validations;
using Domain.Interfaces.Entities.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Factories
{
    public interface IValidationFactory
    {
        public List<ValidationRuleDTO> ExtractValidationRules<T>() where T : IEntity;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Validation
{
    public class ValidationRuleDTO(string propertyName, string validationType, string errorMessage, object? parameters)
    {
        public string PropertyName { get; set; } = propertyName;

        public string ValidationType { get; set; } = validationType;

        public string ErrorMessage { get; set; } = errorMessage;

        public object? Parameter { get; set; } = parameters;
    }
}

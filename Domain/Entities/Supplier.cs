using Domain.Models.Base;
using Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Domain.Validators;

namespace Domain.Models
{
    public class Supplier(string apiUrl, string nome, string apiKey) : EntityBase
    {
        public string ApiUrl { get; set; } = apiUrl;

        public string Nome { get; set; } = nome;

        public string ApiKey { get; set; } = apiKey;

        public override Task<ValidationResult> Validate() 
        {
            var validator = new SupplierValidator();

            return Task.FromResult(validator.Validate(this));
        }
    }
}

using Domain.Interfaces.Entities.Base;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class EntityBase : IEntity
    {
        [JsonPropertyOrder(0)]
        public int Id { get; set; }

        private bool IDValid => Id > 0;

        public bool IsIDValid() => IDValid;

        public virtual Task<ValidationResult> Validate() => Task.FromResult(new ValidationResult());
    }
}

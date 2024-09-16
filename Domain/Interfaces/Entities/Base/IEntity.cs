using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Interfaces.Entities.Base
{
    public interface IEntity
    {
        long Id { get; set; }

        bool IDValid => Id > 0;

        bool IsIDValid() => IDValid;

        Task<ValidationResult> Validate() => Task.FromResult(new ValidationResult());
    }
}

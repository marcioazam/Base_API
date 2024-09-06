using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Entities.Base
{
    public interface IEntity
    {
        public long Id { get; set; }

        public bool IsIDValid();

        public Task<ValidationResult> Validate();
    }
}

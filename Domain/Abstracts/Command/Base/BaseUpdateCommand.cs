using Domain.EnumTypes;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Command.Base
{
    public abstract class BaseUpdateCommand(long id)
    {
        public required long Id { get; set; } = id;
    }
}

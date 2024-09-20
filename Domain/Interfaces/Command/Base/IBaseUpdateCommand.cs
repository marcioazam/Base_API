using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Command.Base
{
    public abstract class IBaseUpdateCommand(long id)
    {
        public required long Id { get; set; } = id;
    }
}

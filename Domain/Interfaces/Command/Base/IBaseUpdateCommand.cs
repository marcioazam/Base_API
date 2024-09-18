using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Command.Base
{
    public interface IBaseUpdateCommand
    {
        public long Id { get; set; }
    }
}

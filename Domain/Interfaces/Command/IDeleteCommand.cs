using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Command
{
    public interface IDeleteCommand
    {
        public long Id { get; set; }
    }
}

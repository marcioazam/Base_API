using Domain.Interfaces.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Base
{
    public class BaseDeleteCommand(long id) : IRequest<CommandResult>, IDeleteCommand
    {
        public long Id { get; set; } = id;
    }
}

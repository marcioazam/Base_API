using Domain.Commands.Base;
using Domain.Interfaces.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Cliente
{
    public class ClienteDeleteCommand(long id) : BaseDeleteCommand(id), IRequest<Result>, IBaseDeleteCommand
    {
    }
}

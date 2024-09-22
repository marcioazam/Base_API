using Domain.Abstracts.Command.Base;
using Domain.EnumTypes;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Commands.ClientesCommands
{
    public class ClienteDeleteCommand(long id) : BaseDeleteCommand(id), IRequest<Result>
    {
    }
}

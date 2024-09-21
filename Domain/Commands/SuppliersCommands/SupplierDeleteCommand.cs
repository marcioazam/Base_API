using Domain.Abstracts.Command.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.SuppliersCommands
{
    public class SupplierDeleteCommand(long id) : BaseDeleteCommand(id), IRequest<Result>
    {
    }
}

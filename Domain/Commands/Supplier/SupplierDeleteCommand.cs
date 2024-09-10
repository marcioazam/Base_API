using Domain.Commands.Base;
using Domain.Interfaces.Command;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Supplier
{
    public class SupplierDeleteCommand(long id) : BaseDeleteCommand(id), IRequest<Result>
    {
    }
}

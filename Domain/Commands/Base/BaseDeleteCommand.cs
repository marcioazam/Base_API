using Domain.Interfaces.Command;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Base
{
    public class BaseDeleteCommand(long id) : IDeleteCommand
    {
        public long Id { get; set; } = id;
    }
}

using Domain.Commands.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Supplier
{
    public class SupplierDeleteCommand(long id) : IRequest<CommandResult>
    {
        [Required]
        public long Id { get; set; } = id;
    }
}

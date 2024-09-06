using Domain.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Tables
{
    public class SupplierTable : ITable
    {
        public long Id { get; set; }

        public required string Nome { get; set; }

        public required string ApiUrl { get; set; }

        public required string ApiKey { get; set; }
    }
}

using Domain.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Tables
{
    public class ClienteTable : ITable
    {
        public required long Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required char Sexo { get; set; }

        public string? Endereco { get; set; }
    }
}

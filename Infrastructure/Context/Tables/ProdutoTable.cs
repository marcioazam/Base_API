using Domain.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Tables
{
    public class ProdutoTable : ITable
    {
        public required long Id { get; set; }

        public required string Nome { get; set; }

        public required decimal Valor { get; set; }

        public required bool Ativo { get; set; }

    }
}

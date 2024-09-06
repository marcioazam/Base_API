using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Supplier
{
    public class SupplierListDTO(int? id, string nome)
    {
        public int? Id { get; set; } = id;

        public string Nome { get; set; } = nome;
    }
}

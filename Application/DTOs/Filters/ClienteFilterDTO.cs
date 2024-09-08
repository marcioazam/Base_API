using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Filters
{
    public class ClienteFilterDTO
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public char? Sexo { get; set; }

        public string? Endereço { get; set; }
    }
}

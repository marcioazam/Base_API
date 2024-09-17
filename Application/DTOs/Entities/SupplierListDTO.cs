using Application.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entities
{
    public class SupplierListDTO(long id, string nome) : IEntityDTO
    {
        public long Id { get; set; } = id;

        public string Nome { get; set; } = nome;
    }
}

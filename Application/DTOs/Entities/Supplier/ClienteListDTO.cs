using Application.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entities.Supplier
{
    public class ClienteListDTO(string nome, char sexo) : IEntityDTO
    {
        public string Nome { get;set; } = nome;

        public char Sexo { get; set; } = sexo;
    }
}

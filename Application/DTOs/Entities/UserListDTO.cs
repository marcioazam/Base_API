using Application.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entities
{
    public class UserListDTO(int? id, string nome) : IEntityDTO
    {
        public int? Id { get; set; } = id;

        public string Username { get; set; } = nome;
    }
}

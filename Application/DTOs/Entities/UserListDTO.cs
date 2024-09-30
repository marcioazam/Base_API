using Application.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Entities
{
    public class UserListDTO : IEntityDTO
    {
        public long Id { get; set; }

        public required string Username { get; set; }
    }
}

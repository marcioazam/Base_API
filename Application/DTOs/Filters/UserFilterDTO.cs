using Application.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Filters
{
    public class UserFilterDTO(string? userName) : IFilter
    {
        public string? Username { get; set; } = userName;
    }
}

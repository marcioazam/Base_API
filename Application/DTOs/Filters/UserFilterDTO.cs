using Application.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Filters
{
    public class UserFilterDTO() : IFilter
    {
        public string? Username { get; set; }
    }
}

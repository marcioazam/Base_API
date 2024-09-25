using Application.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Filters
{
    public class RefreshTokenFilterDTO : IFilter
    {
        public long? Id { get; set; }

        public long? UserId { get; set; }

        public string? RefreshToken { get; set; }
    }
}

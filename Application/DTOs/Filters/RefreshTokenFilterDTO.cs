using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Filters
{
    public class RefreshTokenFilterDTO(string refreshToken)
    {
        public string RefreshToken { get; set; } = refreshToken;
    }
}

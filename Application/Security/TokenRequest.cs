using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Security
{
    public class TokenRequest(string acessToken, string refreshToken)
    {
        public string AcessToken { get; set; } = acessToken;

        public string RefreshToken { get; set; } = refreshToken;
    }
}

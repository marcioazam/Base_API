using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public class RefreshToken
    {
        public required string RefreshTokenGuid { get; set; }

        public required long UserId { get; set; }

        public required DateTime Expiry { get; set; }

        public required bool IsRevoked { get; set; }
    }
}

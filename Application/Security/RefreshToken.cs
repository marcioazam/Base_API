using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public class RefreshToken
    {
        public required string Token { get; set; }

        public required string UserId { get; set; }

        public required DateTime ExpiryDate { get; set; }

        public required bool IsRevoked { get; set; }
    }
}

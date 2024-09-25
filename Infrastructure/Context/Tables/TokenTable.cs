using Domain.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Tables
{
    public class TokenTable : ITable
    {
        public required long Id { get; set; }

        public required string RefreshToken { get; set; }

        public required DateTime Expiry { get; set; }

        public required DateTime CreationDate { get; set; }

        public required long UserId { get; set; }

        public required bool IsRevoked { get; set; }
    }
}

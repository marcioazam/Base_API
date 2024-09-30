using Domain.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Tables
{
    public class UserTable : ITable
    {
        public long Id { get; set; }

        public required string Username { get; set; }

        public required string PasswordHash { get; set; }

        public bool Active { get; set; }
    }
}

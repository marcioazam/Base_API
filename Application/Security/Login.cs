using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public class Login(string username, string password)
    {
        public required string Username { get; set; } = username;

        public required string Password { get; set; } = password;

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password);
        }
    }
}

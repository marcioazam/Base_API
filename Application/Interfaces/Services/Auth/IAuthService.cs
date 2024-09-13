using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        bool ValidateUser(string password, User user);

        string GenerateJwtToken(User user);
    }
}

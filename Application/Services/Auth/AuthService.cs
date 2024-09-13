using Domain.Entities;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces.Services.Auth;

namespace Application.Services.Auth
{
    public class AuthService(IConfiguration configuration) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;

        // Método para validar usuário e senha
        public bool ValidateUser(string password, User user)
        {
            return user != null && VerifyPassword(password, user.PasswordHash);
        }

        // Função para verificar o hash da senha
        private bool VerifyPassword(string password, string storedHash) => BCrypt.Net.BCrypt.Verify(password, storedHash);

        // Método para gerar JWT
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Secret key for JWT is not configured.");
            }

            var key = Encoding.ASCII.GetBytes(secretKey);  // Chave secreta

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Username),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),  // Expira em 30 minutos
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
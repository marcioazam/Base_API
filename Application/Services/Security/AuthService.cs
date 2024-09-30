using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Domain.Interfaces.Repositories;
using Domain.EnumTypes;
using Domain.ValueObjects.ResultInfo;
using Domain.Entities;
using Domain.Helpers;
using Application.DTOs.Filters;
using Application.Interfaces.Services.Security;
using Application.Security;

namespace Application.Services.Security
{
    public class AuthService(IConfiguration configuration, IUserRepository userRepository) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserRepository _userRepository = userRepository;

        Result result = new(null, []);

        // Método para validar usuário e senha
        public async Task<Result> ValidateUser(Login sendUser)
        {
            if (string.IsNullOrEmpty(sendUser.Username))
            {
                result.AddError(GlobalError.RequiredUsername, "Username", sendUser.Username);

                return result;
            }

            if (string.IsNullOrEmpty(sendUser.Password))
            {
                result.AddError(GlobalError.RequiredPassword, "Password", sendUser.Password);

                return result;
            }

            User? userFromBD = await _userRepository.Get<User, UserFilterDTO>(new UserFilterDTO { Username = sendUser.Username });

            if (userFromBD == null)
            {
                result.AddError(GlobalError.UserNotFound);

                return result;
            }

            if (VerifyPassword(sendUser.Password, userFromBD.PasswordHash))
            {
                result = new(userFromBD, []);

                return result;
            }
            else
            {
                result.AddError(GlobalError.InvalidPassword, "Password", sendUser.Password);

                return result;
            }
        }

        // Função para verificar o hash da senha
        private bool VerifyPassword(string password, string storedHash) => BCrypt.Net.BCrypt.Verify(password, storedHash);

        // Método para gerar JWT
        public Tuple<string, DateTime> GenerateJwtToken(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            DateTime expires;
            double expiryHours;
            DateTime dataAtual = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("A chave secreta para o JWT não está configurada.");
            }

            expiryHours = SecurityHelper.GetExpiryToken(_configuration["Jwt:ExpiryHours"]);

            var key = Encoding.UTF8.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            expires = DateTime.UtcNow.AddHours(expiryHours);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = dataAtual,
                NotBefore = dataAtual,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Tuple<string, DateTime>(tokenHandler.WriteToken(token), dataAtual);
        }

        public RefreshToken GenerateRefreshToken(long userId)
        {
            return new RefreshToken
            {
                RefreshTokenGuid = Guid.NewGuid().ToString(),
                UserId = userId,
                Expiry = DateTime.UtcNow.AddHours(6),
                IsRevoked = false
            };
        }
    }
}
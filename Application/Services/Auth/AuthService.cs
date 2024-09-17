using Domain.Entities;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces.Services.Auth;
using Domain.ValueObjects;
using Domain.Interfaces.Repositories;
using Application.DTOs.Filters;
using Domain.ValueObjects.ResultInfo;
using Domain.EnumTypes;
using Domain.Helpers;

namespace Application.Services.Auth
{
    public class AuthService(IConfiguration configuration, IUserRepository userRepository) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserRepository _userRepository = userRepository;

        Result result = new(null, []);

        // Método para validar usuário e senha
        public async Task<Result> ValidateUser(UserLogin sendUser)
        {
            if (string.IsNullOrEmpty(sendUser.Username))
            {
                result.AddError(GlobalError.RequiredUsername, sendUser.Password);

                return result;
            }

            if (string.IsNullOrEmpty(sendUser.Password))
            {
                result.AddError(GlobalError.RequiredPassword, sendUser.Password);

                return result;
            }

            User? userFromBD = await _userRepository.Get<User, UserFilterDTO>(new UserFilterDTO { Username = sendUser.Username });

            if (userFromBD == null)
            {
                result.AddError(GlobalError.UserNotFound, sendUser.Password);

                return result;
            }

            if(VerifyPassword(sendUser.Password, userFromBD.PasswordHash))
            {
                result = new(userFromBD, []);

                return result;
            }
            else
            {
                result.AddError(GlobalError.InvalidPassword, sendUser.Password);

                return result;
            }
        }

        // Função para verificar o hash da senha
        private bool VerifyPassword(string password, string storedHash) => BCrypt.Net.BCrypt.Verify(password, storedHash);

        // Método para gerar JWT
        public string GenerateJwtToken(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("A chave secreta para o JWT não está configurada.");
            }

            var key = Encoding.UTF8.GetBytes(secretKey);  // Chave secreta

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"] ?? "30")),  // Expiração configurável
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
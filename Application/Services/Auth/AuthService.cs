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
        public async Task<Result> ValidateUser(UserLogin userLogin)
        {
            if (string.IsNullOrEmpty(userLogin.Username))
            {
                result.AddError(ErrorMessage.RequiredUsername, userLogin.Password);

                return result;
            }

            if (string.IsNullOrEmpty(userLogin.Password))
            {
                result.AddError(ErrorMessage.RequiredPassword, userLogin.Password);

                return result;
            }

            User? user = await _userRepository.Get<User, UserFilterDTO>(new UserFilterDTO(userLogin.Username));

            if (user == null)
            {
                result.AddError(ErrorMessage.UserNotFound, userLogin.Password);

                return result;
            }

            if(!VerifyPassword(userLogin.Password, user.PasswordHash))
            {
                result.AddError(ErrorMessage.InvalidPassword, userLogin.Password);

                return result; 
            }

            return result;
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
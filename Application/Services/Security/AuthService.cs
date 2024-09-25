﻿using Domain.Entities;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces.Services.Security;
using Domain.Interfaces.Repositories;
using Application.DTOs.Filters;
using Domain.ValueObjects.ResultInfo;
using Domain.EnumTypes;
using Domain.Helpers;
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
        public Tuple<string, DateTime> GenerateJwtToken(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            DateTime expires;
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("A chave secreta para o JWT não está configurada.");
            }

            if (!double.TryParse(_configuration["Jwt:ExpiryHours"], out double expiryHours) || expiryHours <= 0)
            {
                expiryHours = 2; 
            }

            var key = Encoding.UTF8.GetBytes(secretKey);  // Chave secreta

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
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Tuple<string, DateTime>(tokenHandler.WriteToken(token), expires);
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
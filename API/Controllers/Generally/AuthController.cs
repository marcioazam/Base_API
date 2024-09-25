using API.Helpers;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Security;
using Application.Security;
using Application.Services;
using Domain.Commands.TokensCommands;
using Domain.Entities;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers.Generally
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public AuthController(IAuthService authService, IUserService userService, IMediator mediator, ITokenService tokenService)
        {
            _authService = authService;
            _userService = userService;
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> TokenAsync([FromBody] Login login)
        {
            Result result = await _authService.ValidateUser(login);

            if (result.Failed())
            {
                return ResponseHelper.BuildResult(this, result, ResponseStatus.Unauthorized);
            }

            var user = result.Data as User;

            if (user == null)
            {
                result.AddError(GlobalError.InternalError, user);

                return ResponseHelper.BuildResult(this, result, ResponseStatus.InternalServerError);
            };

            var tokenInfo = _authService.GenerateJwtToken(user);
            var refreshToken = _authService.GenerateRefreshToken(user.Id);

            TokenInsertCommand command = new(refreshToken.RefreshTokenGuid, refreshToken.UserId, tokenInfo.Item2, refreshToken.Expiry, refreshToken.IsRevoked);

            result = await _mediator.Send(command);

            TokenRequest tokenRequest = new(tokenInfo.Item1, refreshToken.RefreshTokenGuid);

            if (result.Failed())
            {
                return ResponseHelper.BuildResult(this, result, ResponseStatus.BadRequest);
            }

            return Ok(tokenRequest);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenRequest request)
        {
            var refreshToken = await _tokenService.GetRefreshToken(request.RefreshToken);

            if (refreshToken == null || refreshToken.IsRevoked || refreshToken.ExpiryDate <= DateTime.UtcNow)
                return Unauthorized("Invalid or expired refresh token");

            var user = await _userService.GetUserById(refreshToken.UserId);
            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken(user.Id);

            // Revogar o Refresh Token antigo
            refreshToken.IsRevoked = true;
            await _tokenService.UpdateRefreshToken(refreshToken);

            // Salvar o novo Refresh Token no banco de dados
            await _tokenService.SaveRefreshToken(newRefreshToken);

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            });
        }
    }
}
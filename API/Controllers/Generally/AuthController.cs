using API.Helpers;
using Application.DTOs.Entities;
using Application.DTOs.Filters;
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
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                result.AddError(GlobalError.InternalError);

                return ResponseHelper.BuildResult(this, result, ResponseStatus.InternalServerError);
            };

            result = await GenerateTokenAndSaveRefreshToken(user);

            if (result.Failed())
            {
                return ResponseHelper.BuildResult(this, result, ResponseStatus.BadRequest);
            }

            return Ok(result.Data);
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenRequest request)
        {
            Result result;

            result = await _tokenService.RefreshTokenValidate(request);

            if (result.Failed())
            {
                return Unauthorized();
            }

            var token = result.Data as Token;

            if (token == null)
            {
                result.AddError(GlobalError.InternalError);

                return ResponseHelper.BuildResult(this, result, ResponseStatus.InternalServerError);
            };

            var userResult = await _userService.GetById<User>(token.UserId);

            if (result.Failed())
            {
                return Unauthorized();
            }

            var user = userResult.Data as User;

            if (user == null)
            {
                result.AddError(GlobalError.InternalError);

                return ResponseHelper.BuildResult(this, result, ResponseStatus.InternalServerError);
            };

            result = await GenerateTokenAndSaveRefreshToken(user);

            if (result.Failed())
            {
                return ResponseHelper.BuildResult(this, result, ResponseStatus.BadRequest);
            }

            return Ok(result.Data);
        }

        [NonAction]
        public async Task<Result> GenerateTokenAndSaveRefreshToken(User user)
        {
            Result result = new(null, []);

            var tokenDetail = _authService.GenerateJwtToken(user);
            var refreshToken = _authService.GenerateRefreshToken(user.Id);

            result = await RevokedOldTokens(user);

            if (result.Failed())
            {
                return result;
            }

            result = await CreateNewToken(refreshToken, tokenDetail.Item2);

            result.Data = new TokenRequest(tokenDetail.Item1, refreshToken.RefreshTokenGuid);

            return result;
        }

        [NonAction]
        private async Task<Result> CreateNewToken(RefreshToken refreshToken, DateTime tokenCreationDate)
        {
            TokenInsertCommand command = new(refreshToken.RefreshTokenGuid, refreshToken.UserId, refreshToken.Expiry, tokenCreationDate, refreshToken.IsRevoked);

            Result result = await _mediator.Send(command);

            return result;
        }

        [NonAction]
        public async Task<Result> RevokedOldTokens(User user)
        {
            Result result = new(null, []);

            var TokensResult = await _tokenService.List<TokenRevogedListDTO, RefreshTokenFilterDTO>(new RefreshTokenFilterDTO { UserId = user.Id });

            if (TokensResult.Failed())
            {
                return TokensResult;
            }

            var TokensNotRevokedList = TokensResult.Data as List<TokenRevogedListDTO>;

            if (TokensNotRevokedList == null)
            {
                result.AddError(GlobalError.InternalError);

                return result;
            };

            foreach (var token in TokensNotRevokedList)
            {
                await _mediator.Send(new TokenUpdateRevokedCommand(token.Id));
            }

            return result;
        }
    }
}
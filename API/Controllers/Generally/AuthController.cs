using API.Helpers;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Security;
using Application.Security;
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
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public AuthController(IAuthService authService, IUserService userService, IMediator mediator)
        {
            _authService = authService;
            _userService = userService;
            _mediator = mediator;
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

            var token = _authService.GenerateJwtToken(user);
            var refreshToken = _authService.GenerateRefreshToken(user.Id);

            TokenInsertCommand command = new TokenInsertCommand(refreshToken.Token, refreshToken.UserId, refreshToken.ExpiryDate, refreshToken.IsRevoked);

            result = await _mediator.Send(command);

            if (result.Failed())
            {
                return ResponseHelper.BuildResult(this, result, ResponseStatus.BadRequest);
            }

            return Ok(new { AcessToken = token, RefreshToken = refreshToken.Token });
        }
    }
}
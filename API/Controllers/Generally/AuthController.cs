using API.Helpers;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Auth;
using Application.Services.Auth;
using Domain.Entities;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.ValueObjects;
using Domain.ValueObjects.ResultInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Generally
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService; 

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("Token")]
        public async Task<IActionResult> TokenAsync([FromBody] UserLogin userLogin)
        {
            Result result = await _authService.ValidateUser(userLogin);

            if (result.Failed())
            {
                return ResponseHelper.BuildResult(this, result, ResponseStatus.Ok);
            }

            var user = result.Data as User;

            if (user == null)
            {
                result.AddError(GlobalError.InternalError, user);

                return ResponseHelper.BuildResult(this, result, ResponseStatus.InternalServerError);
            };

            var token = _authService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
    }
}
using Application.Interfaces.Services;
using Application.Interfaces.Services.Auth;
using Application.Services.Auth;
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

            //if(result.Status != ResultStatus.Success)
            //{
            //    return BadRequest(result);
            //}
            //// Gere o token JWT
            //var token = _authService.GenerateJwtToken(user);
            //return Ok(new { Token = token });
        }
    }

}

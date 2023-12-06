using BookShelf.Application.Services.Authentication;
using BookShelf.Application.Services.Jwt;
using BookShelf.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<TokenInfo>> Login([FromBody] LoginModel loginInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var token = await _authenticationService.AuthenticateUser(loginInfo);

            return Ok(token);
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<TokenInfo>> RegisterUser([FromBody] LoginModel loginInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var token = await _authenticationService.RegisterUser(loginInfo);

            return Ok(token);
        }
    }
}

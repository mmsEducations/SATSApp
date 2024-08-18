using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ozz.Core.Authorization;

namespace SATSApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthorizationController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public IActionResult SingIn([FromBody] SATSApp.Business.Models.LoginRequest request)
        {
            if (request.UserName == "1" && request.Password == "1")
            {
                var token = _tokenService.GenerateToken(userId: "1", userEmail: "1");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}

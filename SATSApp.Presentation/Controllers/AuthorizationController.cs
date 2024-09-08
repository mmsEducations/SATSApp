using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ozz.Core.Authorization;
using SATSApp.Business.Models;

namespace SATSApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthorizationController(TokenService tokenService, UserManager<IdentityUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public IActionResult SingIn([FromBody] LoginRequest request)
        {
            if (request.UserName == "1" && request.Password == "1")
            {
                var token = _tokenService.GenerateToken(userId: "1", userEmail: "1");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]//User Register 
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            //IdenetiyUser nesnesinin oluşturulur 
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.UserName,
            };

            //Kullanıcının Oluşturulması
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                //Kullanıcı'ya token üret 
                var token = _tokenService.GenerateToken(userId: user.Id, userEmail: user.Email);
                Ok(new { Token = token });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(new { Error = ModelState });
        }
    }
}

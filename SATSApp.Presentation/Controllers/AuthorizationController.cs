using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SATSApp.Business.Queries.Users;

namespace SATSApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : SATSBaseController
    {
        public AuthorizationController(ISender mediator) : base(mediator)
        {
        }


        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SingIn([FromBody] SignInQuery request)
        {
            //Sistemem giriş yapan kullanıcı sistemde mevcut ise Token üretmemiz gerekir.Kullanıcı bu token sayesinde mevcut sistem içerisinde işlemler yapar

            try
            {
                var token = await _mediator.Send(request);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
            catch (ArithmeticException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        ////[Authorize]//401
        //[Authorize(Roles = "Admin")]//403
        //[HttpPost("sign-up")]//User Register 
        //public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        //{
        //    //IdenetiyUser nesnesinin oluşturulur 
        //    var user = new IdentityUser
        //    {
        //        UserName = request.UserName,
        //        Email = request.UserName,
        //    };

        //    //Kullanıcının Oluşturulması
        //    var result = await _userManager.CreateAsync(user, request.Password);

        //    if (result.Succeeded)
        //    {
        //        //Kullanıcı'ya token üret 
        //        var token = _tokenService.GenerateToken(userId: user.Id, userEmail: user.Email);
        //        Ok(new { Token = token });
        //    }

        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }

        //    return BadRequest(new { Error = ModelState });
        //}
    }
}
/*
 1)Tüm Controllerları ve içlerindeki endpointleri içeren şekilde kod yazma,Ara bir sınıf yapılır ve bu sınıf tüm ednpointleri etkileyeceköşekilde yazılır
 2)Controlller
 3)Endpoint
 
 */
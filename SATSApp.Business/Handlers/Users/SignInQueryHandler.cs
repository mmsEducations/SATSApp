using Microsoft.AspNetCore.Identity;
using Ozz.Core.Authorization;
using SATSApp.Business.Queries.Users;

namespace SATSApp.Business.Handlers.Users
{
    public class SignInQueryHandler : IRequestHandler<SignInQuery, string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        public SignInQueryHandler(UserManager<IdentityUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentException("Username and password must not be emty");
            }

            //Find user by username 
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            //check oassword
            var passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
            if (passwordCheck == false)
            {
                throw new UnauthorizedAccessException("Invalid Password");
            }


            var token = _tokenService.GenerateToken(userId: user.Id, userEmail: user.Email);
            return token;
        }
    }
}

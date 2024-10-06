using Microsoft.AspNetCore.Identity;
using SATSApp.Business.Command.Auth;

namespace SATSApp.Business.Handlers.Auth
{
    internal class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Role))
                return "Role name can not be emty";

            if (await _roleManager.RoleExistsAsync(request.Role))
                return "Role name is exist,please change role name";

            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(request.Role));

            return result.Succeeded ? $"{request.Role} created successfully" : $"error occured , {request.Role} is  not created";
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SATSApp.Business.Infrustructure
{
    public static class SeedRoleService
    {
        //Database'de Varsayılan olarak verdiğim Rolleri oluşturacak 
        public static async Task SeedRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();//RoleManager için İnstance oluşturma işlemi

            //Get roles from configuration 
            string[] roleNames = configuration.GetSection("RoleSettings:Roles").Get<string[]>();

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))//Role yoksa ekle
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}

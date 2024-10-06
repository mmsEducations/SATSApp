using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SATSApp.Business.Infrustructure
{
    public static class SeedUserService
    {
        //Appsettingste yazılan kullanıcı için kullanıcı tablosuna kayıt ve kullanıcıya role eklenecek(role db de varsa eklenece)
        public static async Task SeedUser(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();//RoleManager için İnstance oluşturma işlemi
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();//RoleManager için İnstance oluşturma işlemi

            //Get UserSettings from configuration 
            var userSetting = configuration.GetSection("UserSettings");
            var userEmail = userSetting["Email"];
            var userPassword = userSetting["Password"];
            var userRoleName = userSetting["RoleName"];

            IdentityUser existingUser = await userManager.FindByEmailAsync(userEmail);
            if (existingUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                };

                var result = await userManager.CreateAsync(user, userPassword);

                if (result.Succeeded)
                {
                    if (await roleManager.RoleExistsAsync(userRoleName))//Role yoksa ekle
                    {
                        await userManager.AddToRoleAsync(user, userRoleName);
                    }
                }
            }

        }
    }
}

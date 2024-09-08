using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SATSApp.Data.Extensions
{

    public static class IdentityConfigurationExtensions
    {
        public static void RenameIntityConfigurationTables(this ModelBuilder modelBuilder)
        {
            //Rename Table names 
            modelBuilder.Entity<IdentityUser>(entity => //Authentication
            {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<IdentityRole>(entity => //Authorization,Kullanıcı rollerinin tanımlandığı yer //Admin,PlatformUser,ApiUser
            {
                entity.ToTable(name: "Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity => //Kullanıcıya rollerin tanımlandığı yer 
            {
                entity.ToTable(name: "UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => //Kullanıcı bazlı Değişken tutulan tablo
            {
                entity.ToTable(name: "UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => //Kullanıcı login bilgileri tutulur
            {
                entity.ToTable(name: "UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => //Role bazlı Değişken tutulan tablo
            {
                entity.ToTable(name: "RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity => //Kullanıcı tokenlarının tutulduğu yer 
            {
                entity.ToTable(name: "UserTokens");
            });
        }
    }
}

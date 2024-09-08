using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SATSApp.Data.Entities;
using SATSApp.Data.Extensions;

namespace SATSApp.Data
{
    public class SATSAppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public SATSAppDbContext() { }
        public SATSAppDbContext(DbContextOptions<SATSAppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1-Configurasyon ayarlarına göre tablo oluştur(kolon adı,tipi,ilişkiler..)
            //2-Seed dataların oluşturulması
            base.OnModelCreating(modelBuilder); //Kullanıcı tablolarının otomatik oluşması için önemli
            modelBuilder.AddEntityConfiguration();
            modelBuilder.CreateSeedData();
            modelBuilder.RenameIntityConfigurationTables(); //Rename Creating Identity Tables 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=postgres;Username=postgres;Password=mms;Search Path=satsapp");
        }
    }
}

/*
   XOptions<T>
 */



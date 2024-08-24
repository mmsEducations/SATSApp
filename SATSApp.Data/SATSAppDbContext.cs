using Microsoft.EntityFrameworkCore;
using SATSApp.Data.Entities;
using SATSApp.Data.Extensions;

namespace SATSApp.Data
{
    public class SATSAppDbContext : DbContext
    {
        public SATSAppDbContext() { }
        public SATSAppDbContext(DbContextOptions<SATSAppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfiguration();
            modelBuilder.CreateSeedData();
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



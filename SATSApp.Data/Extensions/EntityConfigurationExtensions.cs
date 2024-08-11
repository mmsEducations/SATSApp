using Microsoft.EntityFrameworkCore;
using SATSApp.Data.Configurations;

namespace SATSApp.Data.Extensions
{
    public static class EntityConfigurationExtensions
    {

        public static void AddEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}

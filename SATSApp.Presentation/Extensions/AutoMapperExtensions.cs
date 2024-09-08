using SATSApp.Business.Mappings;
using System.Reflection;

namespace SATSApp.Presentation.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            //DI Container added.
            services.AddAutoMapper(typeof(CourseProfile));
            services.AddAutoMapper(typeof(StudentProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

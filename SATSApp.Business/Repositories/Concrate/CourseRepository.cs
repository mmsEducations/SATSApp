using Ardalis.Specification.EntityFrameworkCore;
using SATSApp.Business.Repositories.Abstract;
using SATSApp.Data;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Repositories.Concrate
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(SATSAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

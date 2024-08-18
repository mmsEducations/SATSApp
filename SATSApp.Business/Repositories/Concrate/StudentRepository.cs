using Ardalis.Specification.EntityFrameworkCore;
using SATSApp.Business.Repositories.Abstract;
using SATSApp.Data;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Repositories.Concrate
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(SATSAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

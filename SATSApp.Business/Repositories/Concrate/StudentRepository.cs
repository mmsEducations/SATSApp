
namespace SATSApp.Business.Repositories.Concrate
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(SATSAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

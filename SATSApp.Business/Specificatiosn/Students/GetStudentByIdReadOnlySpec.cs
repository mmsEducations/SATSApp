namespace SATSApp.Business.Specificatiosn.Students
{
    public class GetStudentByIdReadOnlySpec : Specification<Student>
    {
        public GetStudentByIdReadOnlySpec(int id)
        {
            Query.Where(x => x.StudentId == id)
                 .AsNoTracking();
        }
    }
}

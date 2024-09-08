namespace SATSApp.Business.Specificatiosn.Students
{
    public class GetStudentsPaginationReadOnlySpec : Specification<Student>
    {
        public GetStudentsPaginationReadOnlySpec(int skip,int take)
        {
            Query.Where(x => x.IsDeleted == false)
                 .Skip(skip)
                 .Take(take)
                 .AsNoTracking();
        }
    }
}

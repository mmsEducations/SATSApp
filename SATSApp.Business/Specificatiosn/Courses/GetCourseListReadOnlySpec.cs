namespace SATSApp.Business.Specificatiosn.Courses
{
    public class GetCourseListReadOnlySpec : Specification<Course>
    {
        public GetCourseListReadOnlySpec()
        {
            Query.Where(x => x.IsDeleted == false)
                 .AsNoTracking();
        }
    }
}

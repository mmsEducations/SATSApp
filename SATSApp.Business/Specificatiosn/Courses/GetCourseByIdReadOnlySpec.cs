namespace SATSApp.Business.Specificatiosn.Courses
{
    public class GetCourseByIdReadOnlySpec : Specification<Course>
    {
        public GetCourseByIdReadOnlySpec(int id)
        {
            Query.Where(x => x.CourseId == id)
                 .AsNoTracking();
        }
    }
}

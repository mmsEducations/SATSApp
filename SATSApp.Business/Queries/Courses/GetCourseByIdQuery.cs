namespace SATSApp.Business.Queries.Courses
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int CourseId { get; set; }
    }
}


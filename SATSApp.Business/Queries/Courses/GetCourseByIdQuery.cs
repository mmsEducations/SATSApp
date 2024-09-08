using SATSApp.Business.Dtos;

namespace SATSApp.Business.Queries.Courses
{
    public class GetCourseByIdQuery : IRequest<CourseDto>
    {
        public int CourseId { get; set; }
    }
}


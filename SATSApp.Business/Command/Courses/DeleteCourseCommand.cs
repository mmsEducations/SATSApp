namespace SATSApp.Business.Command.Courses
{
    public class DeleteCourseCommand : IRequest
    {
        public int CourseId { get; set; }
    }
}

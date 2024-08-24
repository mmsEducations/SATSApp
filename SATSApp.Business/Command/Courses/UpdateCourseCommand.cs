namespace SATSApp.Business.Command.Courses
{
    public class UpdateCourseCommand : IRequest<int>
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
    }
}

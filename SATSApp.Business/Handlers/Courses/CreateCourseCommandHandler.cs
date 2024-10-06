using SATSApp.Business.Command.Courses;

namespace SATSApp.Business.Handlers.Courses
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var _course = await _courseRepository.AddAsync(Course.Create(request.CourseName, request.CourseDescription), cancellationToken);
            return _course.CourseId;
        }
    }

}

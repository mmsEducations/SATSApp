
using SATSApp.Business.Command.Courses;

namespace SATSApp.Business.Handlers.Courses
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var _course = await _courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
            if (_course == null)
            {

            }
            await _courseRepository.UpdateAsync(Course.Update(request.CourseName, request.CourseDescription),cancellationToken);
            return _course.CourseId;
        }
    }
}

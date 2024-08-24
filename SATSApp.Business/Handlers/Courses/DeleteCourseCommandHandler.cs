using SATSApp.Business.Command.Courses;

namespace SATSApp.Business.Handlers.Courses
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var _course = await _courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
            if (_course == null)
            {

            }
            await _courseRepository.DeleteAsync(_course);
        }
    }



}

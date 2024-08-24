namespace SATSApp.Business.Handlers.Courses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<Course>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.ListAsync(new GetCourseListReadOnlySpec(), cancellationToken);
            return courses;
        }
    }
}

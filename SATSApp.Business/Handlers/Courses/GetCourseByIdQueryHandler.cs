namespace SATSApp.Business.Handlers.Courses
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseRepository _courseRepository;


        public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetBySpecAsync(new GetCourseByIdReadOnlySpec(request.CourseId), cancellationToken);
            if (course == null)
            {
                //throw new NotFoundException
            }
            return course;
        }
    }

}

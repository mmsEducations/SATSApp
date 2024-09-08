using AutoMapper;
using SATSApp.Business.Dtos;

namespace SATSApp.Business.Handlers.Courses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.ListAsync(new GetCourseListReadOnlySpec(), cancellationToken);

            return _mapper.Map<List<CourseDto>>(courses); //map 'Course' to CourseDto
        }
    }
}

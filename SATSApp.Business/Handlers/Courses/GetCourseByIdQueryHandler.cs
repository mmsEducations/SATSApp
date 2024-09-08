using AutoMapper;
using SATSApp.Business.Dtos;

namespace SATSApp.Business.Handlers.Courses
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetBySpecAsync(new GetCourseByIdReadOnlySpec(request.CourseId), cancellationToken);
            if (course == null)
            {
                //throw new NotFoundException
            }
            return _mapper.Map<CourseDto>(course); //map 'Course' to CourseDto
        }
    }

}

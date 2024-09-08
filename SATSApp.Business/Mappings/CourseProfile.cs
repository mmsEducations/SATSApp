using AutoMapper;
using SATSApp.Business.Dtos;

namespace SATSApp.Business.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //Source -> Destination
            CreateMap<Course, CourseDto>();
        }
    }

}

using AutoMapper;
using SATSApp.Business.Dtos;

namespace SATSApp.Business.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //Source -> Destination
            CreateMap<Student, StudentDto>();

            //Reverse Mapping
            CreateMap<StudentDto, Student>();

        }
    }

}

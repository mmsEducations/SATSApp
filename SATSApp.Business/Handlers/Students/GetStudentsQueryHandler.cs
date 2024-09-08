using AutoMapper;
using Ozz.Core.ApiReponses;
using SATSApp.Business.Dtos;
using System.Net;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, Response<List<StudentDto>>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var studentDtos = _mapper.Map<List<StudentDto>>(await _studentRepository.ListAsync(new GetStudentListReadOnlySpec(), cancellationToken));
                return new Response<List<StudentDto>>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Message = "Students retrived succesfully",
                    Error = null,
                    Data = studentDtos
                };
            }
            catch (Exception ex)
            {
                return new Response<List<StudentDto>>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occured while retrieving students.",
                    Error = ex.Message,
                    Data = null
                };
            }
        }
    }
}

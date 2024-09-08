using AutoMapper;
using Ozz.Core.ApiReponses;
using SATSApp.Business.Dtos;
using System.Net;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentsPaginationQueryHandler : IRequestHandler<GetStudentsPaginationQuery, Response<List<StudentDto>>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentsPaginationQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<StudentDto>>> Handle(GetStudentsPaginationQuery request, CancellationToken cancellationToken)
        {
            int skip = (request.PageNumber - 1) * request.PageSize;
            int take = request.PageSize;
            var studentDtos = _mapper.Map<List<StudentDto>>(await _studentRepository.ListAsync(new GetStudentsPaginationReadOnlySpec(skip, take), cancellationToken));
            return new Response<List<StudentDto>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
                Message = "Students retrived succesfully",
                Error = null,
                Data = studentDtos
            };
        }
    }
}

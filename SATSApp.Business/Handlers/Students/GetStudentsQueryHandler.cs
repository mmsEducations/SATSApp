using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, Response<List<Student>>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Response<List<Student>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var students = await _studentRepository.ListAsync(new GetStudentListReadOnlySpec(), cancellationToken);
                return new Response<List<Student>>
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "Students retrived succesfully",
                    Error = null,
                    Data = students
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Student>>
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

using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Response<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Response<Student>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            //1:Custom validation Control 
            if (request.StudentId <= 0)
            {
                return new Response<Student>
                {
                    StatusCode = 400,
                    IsSuccess = false,
                    Message = "Invalid StudentId",
                    Error = "InvalidStudentId",
                    Data = null
                };
            }
            try
            {

                var spec = new GetStudentByIdReadOnlySpec(request.StudentId);
                var student = await _studentRepository.GetBySpecAsync(spec, cancellationToken);
                if (student == null)
                {
                    return new Response<Student>
                    {
                        StatusCode = 404,
                        IsSuccess = false,
                        Message = "Student not found",
                        Error = "Notfound",
                        Data = null
                    };
                }


                return new Response<Student>
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "Student retrived successfully",
                    Error = null,
                    Data = student
                };
            }
            catch (Exception ex)
            {

                return new Response<Student>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occured while retrieving student",
                    Error = ex.Message,
                    Data = null
                };
            }
        }
    }
}
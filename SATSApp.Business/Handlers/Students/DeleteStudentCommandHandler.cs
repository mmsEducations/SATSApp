using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Handlers.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Response<bool>>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Response<bool>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //1:Custom validation Control 
            if (request.StudentId <= 0)
            {
                return new Response<bool>
                {
                    StatusCode = 400,
                    IsSuccess = false,
                    Message = "Invalid StudentId",
                    Error = "InvalidStudentId",
                    Data = false
                };
            }

            var student = await _studentRepository.GetByIdAsync(request.StudentId, cancellationToken);
            if (student == null)
            {
                return new Response<bool>
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    Message = "Student not found",
                    Error = "Notfound",
                    Data = false
                };
            }

            try
            {
                await _studentRepository.DeleteAsync(student);

                return new Response<bool>
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "Students deleted succesfully",
                    Error = null,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occured while retrieving students.",
                    Error = ex.Message,
                    Data = false
                };
            }
        }
    }
}

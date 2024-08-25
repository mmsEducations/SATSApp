using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Handlers.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Response<int>>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Response<int>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            //1:Custom validation Control 
            if (request.StudentId <= 0)
            {
                return new Response<int>
                {
                    StatusCode = 400,
                    IsSuccess = false,
                    Message = "Invalid StudentId",
                    Error = "InvalidStudentId",
                    Data = 0
                };
            }

            var student = await _studentRepository.GetByIdAsync(request.StudentId, cancellationToken);
            if (student == null)
            {
                return new Response<int>
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    Message = "Student not found",
                    Error = "Notfound",
                    Data = 0
                };
            }

            try
            {
                await _studentRepository.UpdateAsync(Student.Update(request.FirstName, request.LastName, request.BirthDate, request.Email, request.City), cancellationToken);

                return new Response<int>
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "Students updated succesfully",
                    Error = null,
                    Data = 1
                };
            }
            catch (Exception ex)
            {
                return new Response<int>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occured while retrieving students.",
                    Error = ex.Message,
                    Data = 0
                };
            }
        }


    }
}

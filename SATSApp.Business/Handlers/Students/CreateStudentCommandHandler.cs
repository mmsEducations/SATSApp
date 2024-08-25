using FluentValidation;
using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Handlers.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Response<int>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<CreateStudentCommand> _validator;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IValidator<CreateStudentCommand> validator)
        {
            _studentRepository = studentRepository;
            _validator = validator;
        }

        //
        public async Task<Response<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //Todo 
            //var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            //if (!validationResult.IsValid)
            //{
            //    return new Response<int>
            //    {
            //        StatusCode = 400,
            //        IsSuccess = false,
            //        Message = "Validation failed",
            //        Error = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)),
            //        Data = 0
            //    };
            //}

            try
            {
                var _student = await _studentRepository.AddAsync(Student.Create(request.FirstName, request.LastName, request.BirthDate.Value, request.Email, request.City), cancellationToken);

                return new Response<int>
                {
                    StatusCode = 201, //Created
                    IsSuccess = true,
                    Message = "Student created successfullt",
                    Error = null,
                    Data = _student.StudentId
                };
            }
            catch (Exception ex)
            {
                return new Response<int>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    Message = "An error occured while creating student",
                    Error = ex.Message,
                    Data = 0
                };
            }
        }
    }
}


//Fluent Validation 
//Data Annotation 
//Custom Validation
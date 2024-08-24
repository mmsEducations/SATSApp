namespace SATSApp.Business.Handlers.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            var _student = await _studentRepository.AddAsync(Student.Create(request.FirstName, request.LastName, request.BirthDate, request.Email, request.City), cancellationToken);
            return _student.StudentId;
        }
    }
}

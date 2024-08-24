namespace SATSApp.Business.Handlers.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            var student = await _studentRepository.GetByIdAsync(request.StudentId, cancellationToken);
            if (student == null)
            {

            }

            await _studentRepository.UpdateAsync(Student.Update(request.FirstName, request.LastName, request.BirthDate, request.Email, request.City), cancellationToken);
            return student.StudentId;
        }


    }
}

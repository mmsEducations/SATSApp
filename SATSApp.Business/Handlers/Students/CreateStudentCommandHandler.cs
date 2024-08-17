using MediatR;
using SATSApp.Business.Command.Students;
using SATSApp.Data;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Handlers.Students
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly SATSAppDbContext _context;

        public CreateStudentCommandHandler(SATSAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            int maxStudentId = _context.Students.Max(x => x.StudentId) + 1;
            var student = new Student
            {
                StudentId = maxStudentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                City = request.City,
            };

            await _context.Students.AddAsync(student, cancellationToken);
            await _context.SaveChangesAsync();
            return maxStudentId;
        }
    }
}

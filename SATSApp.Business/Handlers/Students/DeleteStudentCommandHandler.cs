using MediatR;
using Microsoft.EntityFrameworkCore;
using SATSApp.Business.Command.Students;
using SATSApp.Data;

namespace SATSApp.Business.Handlers.Students
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly SATSAppDbContext _context;

        public DeleteStudentCommandHandler(SATSAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);
            if (student == null)
            {

            }
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}

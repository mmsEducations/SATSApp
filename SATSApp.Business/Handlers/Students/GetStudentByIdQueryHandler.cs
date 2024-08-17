using MediatR;
using Microsoft.EntityFrameworkCore;
using SATSApp.Business.Queries.Students;
using SATSApp.Data;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly SATSAppDbContext _context;

        public GetStudentByIdQueryHandler(SATSAppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);
            return student;
        }
    }
}
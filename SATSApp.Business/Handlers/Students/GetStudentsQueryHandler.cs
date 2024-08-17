using MediatR;
using Microsoft.EntityFrameworkCore;
using SATSApp.Business.Queries.Students;
using SATSApp.Data;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly SATSAppDbContext _context;

        public GetStudentsQueryHandler(SATSAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students.ToListAsync(cancellationToken);
            return students;
        }
    }
}


//Handler 
/*
  handler : IRequestHandler<QueryRequest,Response>
  GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>>
 
 */
using MediatR;
using SATSApp.Business.Queries.Students;
using SATSApp.Business.Repositories.Abstract;
using SATSApp.Business.Specificatiosn.Students;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.ListAsync(new GetStudentListReadOnlySpec(), cancellationToken);
            return students;
        }
    }
}


//Handler 
/*
  handler : IRequestHandler<QueryRequest,Response>
  GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>>
 
 */
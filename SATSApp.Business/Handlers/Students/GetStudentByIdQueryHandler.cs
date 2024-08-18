using MediatR;
using SATSApp.Business.Queries.Students;
using SATSApp.Business.Repositories.Abstract;
using SATSApp.Business.Specificatiosn.Students;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Handlers.Students
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetStudentByIdReadOnlySpec(request.StudentId);
            var student = await _studentRepository.GetBySpecAsync(spec, cancellationToken);
            if (student == null)
            {
                //throw new NotFoundException
            }
            return student;
        }
    }
}
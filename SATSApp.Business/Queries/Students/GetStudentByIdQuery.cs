using MediatR;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Queries.Students
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int StudentId { get; set; }
    }
}


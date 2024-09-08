using Ozz.Core.ApiReponses;
using SATSApp.Business.Dtos;

namespace SATSApp.Business.Queries.Students
{
    public class GetStudentsPaginationQuery : IRequest<Response<List<StudentDto>>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}

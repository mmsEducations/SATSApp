using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Queries.Students
{
    public class GetStudentByIdQuery : IRequest<Response<Student>>
    {

        //[Required]//Data Annotation
        public int StudentId { get; set; }
    }
}


using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Command.Students
{
    public class DeleteStudentCommand : IRequest<Response<bool>>
    {
        public int StudentId { get; set; }
    }
}
//DeleteStudentCommand-> request 
//public int StudentId { get; set; } request paramter
//Response -> IRequest

namespace SATSApp.Business.Command.Students
{
    public class DeleteStudentCommand : IRequest
    {
        public int StudentId { get; set; }
    }
}
//DeleteStudentCommand-> request 
//public int StudentId { get; set; } request paramter
//Response -> IRequest

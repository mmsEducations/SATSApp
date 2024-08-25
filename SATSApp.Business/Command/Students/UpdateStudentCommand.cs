using Ozz.Core.ApiReponses;

namespace SATSApp.Business.Command.Students
{
    public class UpdateStudentCommand : IRequest<Response<int>>
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}


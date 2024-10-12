namespace SATSApp.Business.Queues.EventModels
{
    public class CreateStudentCommandEventModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

namespace SATSApp.Data.Entities
{
    public class Student : BaseEntity
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public static Student Create(string firstName, string lastName, DateTime birthDate, string email, string city)
        {
            return new Student
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Email = email,
                City = city,
            };
        }

        public static Student Update(string firstName, string lastName, DateTime birthDate, string email, string city)
        {
            return new Student
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Email = email,
                City = city,
            };
        }
    }

}

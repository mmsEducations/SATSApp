namespace SATSApp.Data.Entities
{
    public class Course : BaseEntity
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }


        public static Course Create(string courseName, string courseDescription)
        {
            return new Course
            {
                CourseName = courseName,
                CourseDescription = courseDescription
            };
        }

        public static Course Update(string courseName, string courseDescription)
        {
            return new Course
            {
                CourseName = courseName,
                CourseDescription = courseDescription
            };
        }


    }

}

namespace SATSApp.Presentation.Common
{
    public class ApiConstant
    {
        //Base 
        public const string BaseRoute = "api/";
        public const string Version = "v1/";


        //Routing 
        public const string RouteStudent = $"{BaseRoute}{Version}student";//api/v1/student
        public const string RouteCourse = $"{BaseRoute}{Version}course";//api/v1/course
    }
}

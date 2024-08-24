﻿namespace SATSApp.Business.Specificatiosn.Students
{
    public class GetStudentListReadOnlySpec : Specification<Student>
    {
        public GetStudentListReadOnlySpec()
        {
            Query.Where(x => x.IsDeleted == false)
                 .AsNoTracking();
        }
    }
}

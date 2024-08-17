﻿using MediatR;

namespace SATSApp.Business.Command.Students
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}


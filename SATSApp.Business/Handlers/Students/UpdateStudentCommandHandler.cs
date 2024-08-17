using MediatR;
using Microsoft.EntityFrameworkCore;
using SATSApp.Business.Command.Students;
using SATSApp.Data;

namespace SATSApp.Business.Handlers.Students
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly SATSAppDbContext _context;

        public UpdateStudentCommandHandler(SATSAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == request.StudentId, cancellationToken);
            if (student == null)
            {

            }
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.City = request.City;
            student.BirthDate = request.BirthDate;
            return await _context.SaveChangesAsync();


        }

        //public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        //{
        //    int maxStudentId = _context.Students.Max(x => x.StudentId) + 1;
        //    var student = new Student
        //    {
        //        StudentId = maxStudentId,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        BirthDate = request.BirthDate,
        //        Email = request.Email,
        //        City = request.City,
        //    };

        //    await _context.Students.AddAsync(student, cancellationToken);
        //    await _context.SaveChangesAsync();
        //    return maxStudentId;
        //}
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SATSApp.Business.Command.Students;
using SATSApp.Business.Queries.Students;
using SATSApp.Data.Entities;
using SATSApp.Presentation.Common;

namespace SATSApp.Presentation.Controllers
{
    [Route($"{ApiConstant.RouteStudent}")]
    [ApiController]
    [Authorize]
    public class StudentController : SATSBaseController
    {
        public StudentController(ISender mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _mediator.Send(new GetStudentsQuery());
            return Ok(students);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var students = await _mediator.Send(new GetStudentByIdQuery() { StudentId = id });
            return Ok(students);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _mediator.Send(new DeleteStudentCommand() { StudentId = id });
            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<int>> CreateStudent(CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateStudent), id);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<int>> UpdateStudent(UpdateStudentCommand command)
        {
            if (command.StudentId <= 0)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}

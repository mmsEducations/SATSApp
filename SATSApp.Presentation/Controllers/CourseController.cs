using MediatR;
using Microsoft.AspNetCore.Mvc;
using SATSApp.Business.Command.Courses;
using SATSApp.Business.Queries.Courses;
using SATSApp.Data.Entities;
using SATSApp.Presentation.Common;

namespace SATSApp.Presentation.Controllers
{
    [Route($"{ApiConstant.RouteCourse}")]
    [ApiController]
    public class CourseController : SATSBaseController
    {
        public CourseController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            var students = await _mediator.Send(new GetCoursesQuery());
            return Ok(students);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var students = await _mediator.Send(new GetCourseByIdQuery() { CourseId = id });
            return Ok(students);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _mediator.Send(new DeleteCourseCommand() { CourseId = id });
            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<int>> CreateCourse(CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateCourse), id);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<int>> UpdateStudent(UpdateCourseCommand command)
        {
            if (command.CourseId <= 0)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}

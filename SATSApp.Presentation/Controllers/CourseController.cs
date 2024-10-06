using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SATSApp.Business.Command.Courses;
using SATSApp.Business.Dtos;
using SATSApp.Business.Infrustructure.Constant;
using SATSApp.Business.Queries.Courses;
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

        [HttpGet("courses")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Authorize(Roles = $"{RoleName.ViewUser},{RoleName.EditUser}")]
        public async Task<ActionResult<List<CourseDto>>> GetCourses()
        {
            var students = await _mediator.Send(new GetCoursesQuery());
            return Ok(students);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Authorize(Roles = $"{RoleName.ViewUser},{RoleName.EditUser}")]

        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            var students = await _mediator.Send(new GetCourseByIdQuery() { CourseId = id });
            return Ok(students);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Authorize(Roles = $"{RoleName.EditUser}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _mediator.Send(new DeleteCourseCommand() { CourseId = id });
            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Authorize(Roles = $"{RoleName.EditUser}")]
        public async Task<ActionResult<int>> CreateCourse(CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateCourse), id);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Authorize(Roles = $"{RoleName.EditUser}")]
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

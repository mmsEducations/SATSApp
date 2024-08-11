using MediatR;
using Microsoft.AspNetCore.Mvc;
using SATSApp.Business.Queries;
using SATSApp.Data.Entities;
using SATSApp.Presentation.Common;

namespace SATSApp.Presentation.Controllers
{
    [Route($"{ApiConstant.RouteStudent}")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}

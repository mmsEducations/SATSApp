using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ozz.Core.ApiReponses;
using SATSApp.Business.Command.Students;
using SATSApp.Business.Queries.Students;
using SATSApp.Data.Entities;
using SATSApp.Presentation.Common;

namespace SATSApp.Presentation.Controllers
{
    [Route($"{ApiConstant.RouteStudent}")]
    [ApiController]
    //[Authorize]
    public class StudentController : SATSBaseController
    {
        public StudentController(ISender mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<List<Student>>), 200)]
        [ProducesResponseType(typeof(Response<List<Student>>), 400)]
        [ProducesResponseType(typeof(Response<List<Student>>), 401)]
        [ProducesResponseType(typeof(Response<List<Student>>), 500)]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _mediator.Send(new GetStudentsQuery());
            return Ok(students);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<Student>), 200)]
        [ProducesResponseType(typeof(Response<Student>), 400)]
        [ProducesResponseType(typeof(Response<Student>), 401)]
        [ProducesResponseType(typeof(Response<Student>), 404)]
        [ProducesResponseType(typeof(Response<Student>), 500)]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            var students = await _mediator.Send(new GetStudentByIdQuery() { StudentId = id });
            return Ok(students);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<bool>), 204)]
        [ProducesResponseType(typeof(Response<bool>), 400)]
        [ProducesResponseType(typeof(Response<bool>), 401)]
        [ProducesResponseType(typeof(Response<bool>), 404)]
        [ProducesResponseType(typeof(Response<bool>), 500)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _mediator.Send(new DeleteStudentCommand() { StudentId = id });
            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(typeof(Response<int>), 201)]
        [ProducesResponseType(typeof(Response<int>), 400)]
        [ProducesResponseType(typeof(Response<int>), 401)]
        [ProducesResponseType(typeof(Response<int>), 500)]

        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateStudent), id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response<int>), 200)]
        [ProducesResponseType(typeof(Response<int>), 400)]
        [ProducesResponseType(typeof(Response<int>), 401)]
        [ProducesResponseType(typeof(Response<int>), 404)]
        [ProducesResponseType(typeof(Response<int>), 500)]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

/*
 Ardalis Specification 
 İş kruallları ve SORGULAMALARI daha düzenli ve yeniden Kullanılabilir bir şekilde yapmak için kullanılır 
 Test edilebilir ve sürdürülebilir 

 Specification Patternı sorgulamalrın ve işkurallarının nesne yönelimli bir şekilde ifade edilemsini sağlar
 
 1)Specification(Spesifikasyon)  : Belirli bir iş kuralı yani sorgu kriterleri tanımlanır 
 2)Criteria (kriter)             : ne  tür sonuçlar döndürecek 
 3)Expression (ifade)            : sorgu ve iş kurallarını dinamik olarak oluşturmak için kullanılır 
 */

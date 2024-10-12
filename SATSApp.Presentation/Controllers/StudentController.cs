using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SATSApp.Business.Command.Students;
using SATSApp.Business.Dtos;
using SATSApp.Business.Infrustructure.Constant;
using SATSApp.Business.Queries.Students;
using SATSApp.Business.Queues.EventModels;
using SATSApp.Data.Entities;
using SATSApp.Presentation.Common;

namespace SATSApp.Presentation.Controllers
{
    [Route($"{ApiConstant.RouteStudent}")]
    [ApiController]

    public class StudentController : SATSBaseController
    {
        private readonly IBus _bus;
        public StudentController(ISender mediator, IBus bus) : base(mediator)
        {
            _bus = bus;
        }

        [Authorize(Roles = $"{RoleName.ViewUser},{RoleName.EditUser}")]
        [HttpGet("students")]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 200)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 400)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 401)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 403)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 500)]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _mediator.Send(new GetStudentsQuery());
            return Ok(students);
        }

        [Authorize(Roles = $"{RoleName.ViewUser},{RoleName.EditUser}")]
        [HttpGet("studentsPagination")]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 200)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 400)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 401)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 403)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<List<StudentDto>>), 500)]
        public async Task<IActionResult> GetStudentsPagination([FromQuery] GetStudentsPaginationQuery query)
        {
            var students = await _mediator.Send(query);
            return Ok(students);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<Student>), 200)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<Student>), 400)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<Student>), 401)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<Student>), 403)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<Student>), 404)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<Student>), 500)]
        [Authorize(Roles = $"{RoleName.ViewUser},{RoleName.EditUser}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            var students = await _mediator.Send(new GetStudentByIdQuery() { StudentId = id });
            return Ok(students);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<bool>), 204)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<bool>), 400)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<bool>), 401)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<bool>), 403)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<bool>), 404)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<bool>), 500)]
        [Authorize(Roles = $"{RoleName.ViewUser},{RoleName.EditUser}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _mediator.Send(new DeleteStudentCommand() { StudentId = id });
            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 201)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 400)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 401)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 403)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 500)]
        //[Authorize(Roles = $"{RoleName.EditUser}")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            await _bus.Publish(new CreateStudentCommandEventModel
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                BirthDate = command.BirthDate
            });

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateStudent), id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 200)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 400)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 401)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 403)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 404)]
        [ProducesResponseType(typeof(Ozz.Core.ApiReponses.Response<int>), 500)]
        [Authorize(Roles = $"{RoleName.EditUser}")]
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

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SATSApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SATSBaseController : ControllerBase
    {
        public readonly ISender _mediator;

        public SATSBaseController(ISender mediator)
        {
            _mediator = mediator;
        }
    }
}

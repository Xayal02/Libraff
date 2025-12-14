using Libraff.Application.CQRS.Commands.Organization.CreateEmployee;
using Libraff.Application.CQRS.Commands.Organization.TransferEmployee;

namespace Libraff.Api.Controllers
{
    [ApiController]
    [Route("api/v1/employees")]
    public class OrganizationController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }

        [HttpPut("transfer")]
        public async Task<IActionResult> TransferEmployee(TransferEmployeeCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return NoContent();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }
    }
}

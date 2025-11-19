using Libraff.Application.CQRS.Commands.Warehouse.AddSupply;

namespace Libraff.Api.Controllers
{
    [ApiController]
    [Route("api/warehouse")]
    public class WarehouseController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddSupply(AddSupplyCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }
    }
}
